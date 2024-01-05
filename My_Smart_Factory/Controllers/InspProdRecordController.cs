using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Insp;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Vo.Insp;
using NuGet.Packaging.Signing;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Controllers
{
    [Route("InspProdRecord")]
    public class InspProdRecordController : Controller
    {
        private readonly IInspProdRecordService _inspProdRecordService;
        private readonly MyDbContext _context;

        public InspProdRecordController(IInspProdRecordService inspProdRecordService,
            MyDbContext context)
        {
            _inspProdRecordService = inspProdRecordService;
            _context = context;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var isList = await _context.InspProdRecordModels
                .Include(x => x.InspSpec).Include(x => x.InspSpec.InspEquip)
                .Include(x => x.ProdCtrlNo).Include(x => x.ProdCtrlNo.ProdInfo)
                .Include(x => x.FullInspRecord)
                .ToListAsync();
            var voList = new List<InspProdRecordVo>();
            foreach (var item in isList)
            {
                voList.Add(_inspProdRecordService.ModelToVo(item));
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
        public async Task<IActionResult> Create(InspProdRecordDto requestDto)
        {
            try
            {
                InspSpecModel? InspSpec = await _context.InspSpecModels
                    .Include(x => x.InspEquip)
                    .FirstOrDefaultAsync(x => x.InspSpecName == requestDto.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspEquip"); }
                ProdCtrlNoModel? ProdCtrlNo = await _context.ProdCtrlNoModels
                    .Include(x => x.ProdInfo)
                    .FirstOrDefaultAsync(x => x.ProdCtrlNo == requestDto.ProdCtrlNo);
                if (ProdCtrlNo == null) { BadRequest("No ProdCtrlNo"); }
                FullInspRecordModel? FullInspRecord = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspNo == requestDto.FullInspNo);
                if (FullInspRecord == null) { BadRequest("No FullInspRecord"); }
                decimal Accuracy = ((decimal)requestDto.MeasuredValue / (decimal)ProdCtrlNo.ProdInfo.ProdWeight) * 100;
                bool IsPassed = true;
                if (Math.Abs(Accuracy / 100) > InspSpec.ETR) { IsPassed = false; }
                await _inspProdRecordService.AddAsync(requestDto.ToModel(InspSpec, ProdCtrlNo, FullInspRecord, Accuracy, IsPassed));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
        #region edit
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.InspProdRecordModels
                .Include(x => x.InspSpec).Include(x => x.InspSpec.InspEquip)
                .Include(x => x.ProdCtrlNo).Include(x => x.ProdCtrlNo.ProdInfo)
                .Include(x => x.FullInspRecord)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var dto = _inspProdRecordService.ModelToDto(model);
            return View(dto);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(InspProdRecordDto requestDto)
        {
            try
            {
                var model = await _inspProdRecordService.GetByIdAsync(requestDto.Id);
                InspSpecModel? InspSpec = await _context.InspSpecModels
                    .Include(x => x.InspEquip)
                    .FirstOrDefaultAsync(x => x.InspSpecName == requestDto.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspSpec"); }

                ProdCtrlNoModel? ProdCtrlNo = await _context.ProdCtrlNoModels
                    .Include(x => x.ProdInfo)
                    .FirstOrDefaultAsync(x => x.ProdCtrlNo == requestDto.ProdCtrlNo);
                if (ProdCtrlNo == null) { BadRequest("No ProdCtrlNo"); }

                FullInspRecordModel? FullInspRecord = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspNo == requestDto.FullInspNo);
                if (FullInspRecord == null) { BadRequest("No FullInspRecord"); }
                decimal Accuracy = ((decimal)requestDto.MeasuredValue / (decimal)ProdCtrlNo.ProdInfo.ProdWeight) * 100;
                bool IsPassed = true;
                if (Math.Abs(Accuracy/100) > InspSpec.ETR) { IsPassed = false; }
                await _inspProdRecordService.UpdateAsync(requestDto.Id, _inspProdRecordService.UpdateModel(model, requestDto, InspSpec, ProdCtrlNo, FullInspRecord, Accuracy, IsPassed));
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
                await _inspProdRecordService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}
