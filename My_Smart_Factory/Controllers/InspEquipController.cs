using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Service;
using My_Smart_Factory.Data.Service.Interface;

namespace My_Smart_Factory.Controllers
{
    [Route("inspEquip")]
    public class InspEquipController : Controller
    {
        private readonly IInspEquipService _inspEquipService;

        public InspEquipController(IInspEquipService inspEquipService)
        {
            _inspEquipService = inspEquipService;
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
        public async Task<IActionResult> Create(InspEquipDto requestDto)
        {
            try
            {
                await _inspEquipService.AddAsync(requestDto.ToModel());
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
            var ieList = await _inspEquipService.GetAllAsync();
            return View(ieList);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _inspEquipService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(InspEquipDto requestDto)
        {
            try
            {
                var model = await _inspEquipService.GetByIdAsync(requestDto.Id);
                await _inspEquipService.UpdateAsync(requestDto.Id, _inspEquipService.UpdateModel(model, requestDto));
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
                await _inspEquipService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
