using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Data.Service;

namespace My_Smart_Factory.Controllers
{
    [Route("workorder")]
    public class WorkOrderController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWorkOrderService _workOrderService;
        private readonly QrCodeService _qrCodeService;

        public WorkOrderController(IWorkOrderService workOrderService
            , QrCodeService qrCodeService,
            MyDbContext context)
        {
            _workOrderService = workOrderService;
            _qrCodeService = qrCodeService;
            _context = context;
        }
        [HttpGet("index")]
        public IActionResult Index()
        {
            var models = _context.WorkOrderModels
                .Include(x => x.ProdInfo)
                .Include(x => x.WorkOrderIssuer)
                .Include(x => x.FullInspection)
                .ToList();
            List<WorkOrderVo> voList = new List<WorkOrderVo>();
            foreach (var item in models)
            {
                voList.Add(_workOrderService.ModelToVo(item));
            }
            return View(voList);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(WorkOrderDto requestDto)
        {
            try
            {
                //InspEquipModel InspEquip, WorkOrderModel WorkOrder
                ProdInfoModel ProdInfo = await _context.ProdInfoModels.FirstOrDefaultAsync(x => x.ProdName == requestDto.ProdName);
                if (ProdInfo == null) { BadRequest("No ProdInfo"); }
                UserIdentity WorkOrderIssuer = await _context.UserIdentitys.FirstOrDefaultAsync(x => x.UserName == requestDto.WorkOrderIssuer);
                if (WorkOrderIssuer == null) { BadRequest("No WorkOrderIssuer"); }
                // requestDto정보를 json으로 변환
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestDto);
                string qrUrl = _qrCodeService.SaveQrCode(jsonString, requestDto.WorkOrderNo);
                WorkOrderModel model = requestDto.ToModel(ProdInfo, WorkOrderIssuer, qrUrl);
                await _workOrderService.AddAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("read")]
        public async Task<IActionResult> Read()
        {
            var ieList = await _workOrderService.GetAllAsync();
            return View(ieList);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.WorkOrderModels
                .Include(x => x.ProdInfo)
                .Include(x => x.WorkOrderIssuer)
                .Include(x => x.FullInspection)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var dto = _workOrderService.ModelToDto(model);
            return View(dto);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(WorkOrderDto requestDto)
        {
            try
            {
                var model = await _workOrderService.GetByIdAsync(requestDto.Id);
                ProdInfoModel ProdInfo = await _context.ProdInfoModels.FirstOrDefaultAsync(x => x.ProdName == requestDto.ProdName);
                if (ProdInfo == null) { BadRequest("No ProdInfo"); }
                UserIdentity WorkOrderIssuer = await _context.UserIdentitys.FirstOrDefaultAsync(x => x.UserName == requestDto.WorkOrderIssuer);
                if (WorkOrderIssuer == null) { BadRequest("No WorkOrderIssuer"); }
                FullInspRecordModel FullInspection = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspNo == requestDto.FullInspNo);
                if (FullInspection == null) { BadRequest("No FullInspection"); }
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(requestDto);
                string qrUrl = _qrCodeService.SaveQrCode(jsonString, requestDto.WorkOrderNo);
                await _workOrderService.UpdateAsync(requestDto.Id, _workOrderService.UpdateModel(model, requestDto, ProdInfo, WorkOrderIssuer, FullInspection, qrUrl));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _workOrderService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
