using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Dto.Prod;
using My_Smart_Factory.Data.Service.Interface.Prod;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Controllers
{
    [Route("workorder")]
    public class WorkOrderController : Controller
    {
        private readonly IWorkOrderService _workOrderService;
        private readonly MyDbContext _context;

        public WorkOrderController(IWorkOrderService workOrderService,
            MyDbContext context)
        {
            _workOrderService = workOrderService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(WorkOrderVo requestDto)
        {
            try
            {
                //InspEquipModel InspEquip, WorkOrderModel WorkOrder
                ProdInfoModel ProdInfo = await _context.ProdInfoModels.FirstOrDefaultAsync(x => x.ProdName == requestDto.ProdName);
                if (ProdInfo == null) { BadRequest("No ProdInfo"); }
                UserIdentity WorkOrderIssuer = await _context.UserIdentitys.FirstOrDefaultAsync(x => x.UserName == requestDto.WorkOrderIssuer);
                if (WorkOrderIssuer == null) { BadRequest("No WorkOrderIssuer"); }
                FullInspRecordModel FullInspection = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspectionNumber == requestDto.FullInspectionNumber);
                if (FullInspection == null) { BadRequest("No FullInspection"); }
                await _workOrderService.AddAsync(requestDto.ToModel(ProdInfo, WorkOrderIssuer, FullInspection));
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
            var model = await _workOrderService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(WorkOrderVo requestDto)
        {
            try
            {
                var model = await _workOrderService.GetByIdAsync(requestDto.Id);
                ProdInfoModel ProdInfo = await _context.ProdInfoModels.FirstOrDefaultAsync(x => x.ProdName == requestDto.ProdName);
                if (ProdInfo == null) { BadRequest("No ProdInfo"); }
                UserIdentity WorkOrderIssuer = await _context.UserIdentitys.FirstOrDefaultAsync(x => x.UserName == requestDto.WorkOrderIssuer);
                if (WorkOrderIssuer == null) { BadRequest("No WorkOrderIssuer"); }
                FullInspRecordModel FullInspection = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspectionNumber == requestDto.FullInspectionNumber);
                if (FullInspection == null) { BadRequest("No FullInspection"); }
                await _workOrderService.UpdateAsync(requestDto.Id, _workOrderService.UpdateModel(model, requestDto, ProdInfo, WorkOrderIssuer, FullInspection));
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
