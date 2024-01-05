using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Models;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Data.Vo.FullInsp;

namespace My_Smart_Factory.Controllers
{
    [Route("fullInsprecord")]
    public class FullInspRecordController : Controller
    {
        private readonly IFullInspRecordService _fullInspRecordService;
        private readonly MyDbContext _context;

        public FullInspRecordController(IFullInspRecordService fullInspRecordService,
            MyDbContext _context)
        {
            _fullInspRecordService = fullInspRecordService;
            this._context = _context;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var model = await _context.FullInspRecordModels
                .Include(x => x.WorkOrder)
                .ToListAsync();
            List<FullInspRecordVo> voList = new List<FullInspRecordVo>();
            foreach (var item in model)
            {
                voList.Add(_fullInspRecordService.ModelToVo(item));
            }
            return View(voList);
        }
        #region create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(FullInspRecordDto requestDto)
        {
            try
            {
                WorkOrderModel? WorkOrder = await _context.WorkOrderModels
                    .Include(x => x.ProdInfo)
                    .Include(x => x.WorkOrderIssuer)
                    .FirstOrDefaultAsync(x => x.WorkOrderNo == requestDto.WorkOrderNo);
                await _fullInspRecordService.AddAsync(requestDto.ToModel(WorkOrder));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
        #region Detail
        [HttpGet("detail")]
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _context.FullInspRecordModels
                .Include(x => x.WorkOrder)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            FullInspRecordVo vo = _fullInspRecordService.ModelToVo(model);

            return View(vo);
        }
        [HttpGet("proddetail")]
        public async Task<IActionResult> ProdDetail(int id)
        {
            var model = await _context.FullInspRecordModels
                            .Include(x => x.WorkOrder)
                            .Include(x => x.InspProdRecords).ThenInclude(x => x.InspSpec).ThenInclude(x => x.InspEquip)
                            .Include(x => x.InspProdRecords).ThenInclude(x => x.ProdCtrlNo).ThenInclude(x => x.ProdInfo)
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
            var dto = _fullInspRecordService.ModelToProdVo(model);
            return View(dto);
        }
        [HttpGet("equipdetail")]
        public async Task<IActionResult> EquipDetail(int id)
        {
            var model = await _context.FullInspRecordModels
                            .Include(x => x.WorkOrder)
                            .Include(x => x.InspEquipSettingRecords).ThenInclude(x => x.InspEquip)
                            .Include(x => x.InspEquipSettingRecords).ThenInclude(x => x.InspSpec).ThenInclude(x => x.ProdInfo)
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
            var dto = _fullInspRecordService.ModelToEquipVo(model);
            return View(dto);
        }

        #endregion
        #region Read
        [HttpGet("read")]
        public async Task<IActionResult> Read()
        {
            var ieList = await _fullInspRecordService.GetAllAsync();
            return View(ieList);
        }
        #endregion
        #region Edit
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.FullInspRecordModels
                .Include(x => x.WorkOrder)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var dto = _fullInspRecordService.ModelToDto(model);
            return View(dto);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(FullInspRecordDto requestDto)
        {
            try
            {
                var model = await _fullInspRecordService.GetByIdAsync(requestDto.Id);
                WorkOrderModel? WorkOrder = await _context.WorkOrderModels.FirstOrDefaultAsync(x => x.WorkOrderNo == requestDto.WorkOrderNo);
                if (WorkOrder == null) { BadRequest("No WorkOrder"); }
                List<InspEquipSettingRecordModel>? InspEquipSettingRecordModels = await CreateListInspEquipSettingRecordModel(requestDto);
                if (InspEquipSettingRecordModels.Count == 0) { BadRequest("No InspEquipSettingRecord"); }
                List<InspProdRecordModel>? InspProdRecordModels = await CreateListInspProdRecordModel(requestDto);
                if (InspProdRecordModels.Count == 0) { BadRequest("No InspProdRecord"); }
                await _fullInspRecordService.UpdateAsync(requestDto.Id, _fullInspRecordService.UpdateModel(model, requestDto, WorkOrder, InspEquipSettingRecordModels, InspProdRecordModels));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
        #region Delete
        [HttpGet("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fullInspRecord = await _context.FullInspRecordModels
                    .Include(x => x.WorkOrder)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
                _context.FullInspRecordModels.Remove(fullInspRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region function
        public async Task<List<InspEquipSettingRecordModel>?> CreateListInspEquipSettingRecordModel(FullInspRecordDto requestDto)
        {
            List<InspEquipSettingRecordModel> InspEquipSettingRecordModels = new List<InspEquipSettingRecordModel>();
            foreach (var item in requestDto.InspEquipSettingRecordDtos)
            {
                InspEquipModel? InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == item.InspEquipName);
                if (InspEquip == null)
                {
                    BadRequest("No InspEquip " + item.InspEquipName.ToString());
                }
                InspSpecModel? InspSpec = await _context.InspSpecModels.FirstOrDefaultAsync(x => x.InspSpecName == item.InspSpecName);
                if (InspSpec == null)
                {
                    BadRequest("No InspSpec " + item.InspSpecName.ToString());
                }
                FullInspRecordModel? FullInspRecord = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspNo == item.FullInspNo);
                if (FullInspRecord == null) { BadRequest("No FullInspRecord"); }
                decimal Accuracy = ((decimal)item.IES / (decimal)InspSpec.ProdInfo.ProdWeight) * 100;

                InspEquipSettingRecordModels.Add(item.ToModel(InspEquip, InspSpec, FullInspRecord, Accuracy));
            }
            return InspEquipSettingRecordModels;
        }

        public async Task<List<InspProdRecordModel>?> CreateListInspProdRecordModel(FullInspRecordDto requestDto)
        {
            List<InspProdRecordModel>? InspProdRecordModels = new List<InspProdRecordModel>();
            foreach (var item in requestDto.InspProdRecordDtos)
            {
                InspSpecModel? InspSpec = await _context.InspSpecModels.FirstOrDefaultAsync(x => x.InspSpecName == item.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspEquip " + item.InspSpecName); }
                ProdCtrlNoModel? ProdCtrlNo = await _context.ProdCtrlNoModels.FirstOrDefaultAsync(x => x.ProdCtrlNo == item.ProdCtrlNo);
                if (ProdCtrlNo == null) { BadRequest("No ProdCtrlNo " + item.ProdCtrlNo); }
                FullInspRecordModel? FullInspRecord = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspNo == item.FullInspNo);
                if (FullInspRecord == null) { BadRequest("No FullInspRecord"); }
                decimal Accuracy = ((decimal)item.MeasuredValue / (decimal)ProdCtrlNo.ProdInfo.ProdWeight) * 100;
                bool IsPassed = true;
                if (Math.Abs(Accuracy) > InspSpec.ETR) { IsPassed = false; }
                InspProdRecordModels.Add(item.ToModel(InspSpec, ProdCtrlNo, FullInspRecord, Accuracy, IsPassed));
            }
            return InspProdRecordModels;
        }
        #endregion

    }
}


