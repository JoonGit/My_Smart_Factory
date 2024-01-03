using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Models;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Controllers
{
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
        public IActionResult Index()
        {
            return View();
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
                WorkOrderModel? WorkOrder = await _context.WorkOrderModels.FirstOrDefaultAsync(x => x.WorkOrderNumber == requestDto.WorkOrderNumber);
                if (WorkOrder == null) { BadRequest("No WorkOrder"); }
                List<InspEquipSettingRecordModel>? InspEquipSettingRecordModels = await CreateListInspEquipSettingRecordModel(requestDto);
                if (InspEquipSettingRecordModels.Count == 0) { BadRequest("No InspEquipSettingRecord"); }
                List<InspProdRecordModel>? InspProdRecordModels = await CreateListInspProdRecordModel(requestDto);
                if (InspProdRecordModels.Count == 0) { BadRequest("No InspProdRecord"); }

                await _fullInspRecordService.AddAsync(requestDto.ToModel(WorkOrder, InspEquipSettingRecordModels, InspProdRecordModels));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
            var model = await _fullInspRecordService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(FullInspRecordDto requestDto)
        {
            try
            {
                var model = await _fullInspRecordService.GetByIdAsync(requestDto.Id);
                WorkOrderModel? WorkOrder = await _context.WorkOrderModels.FirstOrDefaultAsync(x => x.WorkOrderNumber == requestDto.WorkOrderNumber);
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
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _fullInspRecordService.DeleteAsync(id);
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
                decimal Accuracy = ((decimal)item.IES / (decimal)InspSpec.ProdInfo.ProdWeight) * 100;

                InspEquipSettingRecordModels.Add(item.ToModel(InspEquip, InspSpec, Accuracy));
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
                decimal Accuracy = ((decimal)item.MeasuredValue / (decimal)ProdCtrlNo.ProdInfo.ProdWeight) * 100;
                bool IsPassed = true;
                if (Math.Abs(Accuracy) > InspSpec.ETR) { IsPassed = false; }
                InspProdRecordModels.Add(item.ToModel(InspSpec, ProdCtrlNo, Accuracy, IsPassed));
            }
            return InspProdRecordModels;
        }
        #endregion

    }
}


