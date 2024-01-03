using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Prod;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Service.Interface.Prod;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Controllers
{
    public class ProdCtrlNoController : Controller
    {
        private readonly IProdCtrlNoService _prodCtrlNoService;
        private readonly MyDbContext _context;

        public ProdCtrlNoController(IProdCtrlNoService prodCtrlNoService,
            MyDbContext context)
        {
            _prodCtrlNoService = prodCtrlNoService;
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
        public async Task<IActionResult> Create(ProdCtrlNoDto requestDto)
        {
            try
            {
                //InspEquipModel InspEquip, ProdCtrlNoModel ProdCtrlNo
                ProdInfoModel ProdInfo = await _context.ProdInfoModels.FirstOrDefaultAsync(x => x.ProdName == requestDto.ProdName);
                if (ProdInfo == null) { BadRequest("No ProdInfo"); }
                await _prodCtrlNoService.AddAsync(requestDto.ToModel(ProdInfo));
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
            var ieList = await _prodCtrlNoService.GetAllAsync();
            return View(ieList);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _prodCtrlNoService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(ProdCtrlNoDto requestDto)
        {
            try
            {
                var model = await _prodCtrlNoService.GetByIdAsync(requestDto.Id);
                ProdInfoModel ProdInfo = await _context.ProdInfoModels.FirstOrDefaultAsync(x => x.ProdName == requestDto.ProdName);
                if (ProdInfo == null) { BadRequest("No ProdInfo"); }
                await _prodCtrlNoService.UpdateAsync(requestDto.Id, _prodCtrlNoService.UpdateModel(model, requestDto, ProdInfo));
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
                await _prodCtrlNoService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
