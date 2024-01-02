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
    public class InspSpecController : Controller
    {
        private readonly IInspSpecService _inspSpecService;
        private readonly MyDbContext _context;

        public InspSpecController(IInspSpecService inspSpecService,
            MyDbContext context)
        {
            _inspSpecService = inspSpecService;
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
        public async Task<IActionResult> Create(InspSpecDto requestDto)
        {
            try
            {
                //InspEquipModel InspEquip, InspSpecModel InspSpec
                ProdInfoModel ProdInfo = await _context.ProdInfoModels.FirstOrDefaultAsync(x => x.ProdName == requestDto.ProdName);
                if (ProdInfo == null) { BadRequest("No ProdInfo"); }
                InspEquipModel InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == requestDto.InspEquipName);
                if (InspEquip == null) { BadRequest("No InspEquip"); }
                await _inspSpecService.AddAsync(requestDto.ToModel(ProdInfo, InspEquip));
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
            var ieList = await _inspSpecService.GetAllAsync();
            return View(ieList);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _inspSpecService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(InspSpecDto requestDto)
        {
            try
            {
                var model = await _inspSpecService.GetByIdAsync(requestDto.Id);
                ProdInfoModel ProdInfo = await _context.ProdInfoModels.FirstOrDefaultAsync(x => x.ProdName == requestDto.ProdName);
                if (ProdInfo == null) { BadRequest("No ProdInfo"); }
                InspEquipModel InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == requestDto.InspEquipName);
                if (InspEquip == null) { BadRequest("No InspEquip"); }
                await _inspSpecService.UpdateAsync(requestDto.Id, _inspSpecService.UpdateModel(model, requestDto, ProdInfo, InspEquip));
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
                await _inspSpecService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
