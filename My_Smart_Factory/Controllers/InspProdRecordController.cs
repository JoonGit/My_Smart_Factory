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

namespace My_Smart_Factory.Controllers
{
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
        public async Task<IActionResult> Create(InspProdRecordDto requestDto)
        {
            try
            {
                //InspEquipModel InspEquip, InspSpecModel InspSpec
                InspSpecModel? InspSpec = await _context.InspSpecModels.FirstOrDefaultAsync(x => x.InspSpecName == requestDto.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspEquip"); }
                ProdCtrlNoModel? ProdCtrlNo = await _context.ProdCtrlNoModels.FirstOrDefaultAsync(x => x.ProdCtrlNo == requestDto.ProdCtrlNo);
                if (ProdCtrlNo == null) { BadRequest("No ProdCtrlNo"); }
                decimal Accuracy = ((decimal)requestDto.MeasuredValue / (decimal)ProdCtrlNo.ProdInfo.ProdWeight) * 100;
                bool IsPassed = true;
                if (Math.Abs(Accuracy)  > InspSpec.ETR) { IsPassed = false; }
                await _inspProdRecordService.AddAsync(requestDto.ToModel(InspSpec, ProdCtrlNo, Accuracy, IsPassed));
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
            var ieList = await _inspProdRecordService.GetAllAsync();
            return View(ieList);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _inspProdRecordService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(InspProdRecordDto requestDto)
        {
            try
            {
                var model = await _inspProdRecordService.GetByIdAsync(requestDto.Id);
                InspSpecModel? InspSpec = await _context.InspSpecModels.FirstOrDefaultAsync(x => x.InspSpecName == requestDto.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspSpec"); }
                ProdCtrlNoModel? ProdCtrlNo = await _context.ProdCtrlNoModels.FirstOrDefaultAsync(x => x.ProdCtrlNo == requestDto.ProdCtrlNo);
                if (ProdCtrlNo == null) { BadRequest("No ProdCtrlNo"); }
                decimal Accuracy = ((decimal)requestDto.MeasuredValue / (decimal)ProdCtrlNo.ProdInfo.ProdWeight) * 100;
                bool IsPassed = true;
                if (Math.Abs(Accuracy) > InspSpec.ETR) { IsPassed = false; }
                await _inspProdRecordService.UpdateAsync(requestDto.Id, _inspProdRecordService.UpdateModel(model, requestDto, InspSpec, ProdCtrlNo, Accuracy, IsPassed));
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
                await _inspProdRecordService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
