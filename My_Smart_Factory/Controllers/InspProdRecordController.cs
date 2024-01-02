using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Insp;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

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
                InspEquipModel? InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == requestDto.InspEquipName);
                if (InspEquip == null) { BadRequest("No InspEquip"); }
                ProdCtrlNoModel? ProdCtrlNo = await _context.ProdCtrlNoModels.FirstOrDefaultAsync(x => x.ProdCtrlNo == requestDto.ProdCtrlNo);
                if (ProdCtrlNo == null) { BadRequest("No ProdCtrlNo"); }
                await _inspProdRecordService.AddAsync(requestDto.ToModel(InspEquip, ProdCtrlNo));
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
                InspEquipModel? InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == requestDto.InspEquipName);
                if (InspEquip == null) { BadRequest("No InspEquip"); }
                ProdCtrlNoModel? ProdCtrlNo = await _context.ProdCtrlNoModels.FirstOrDefaultAsync(x => x.ProdCtrlNo == requestDto.ProdCtrlNo);
                if (ProdCtrlNo == null) { BadRequest("No ProdCtrlNo"); }
                await _inspProdRecordService.UpdateAsync(requestDto.Id, _inspProdRecordService.UpdateModel(model, requestDto, InspEquip, ProdCtrlNo));
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
