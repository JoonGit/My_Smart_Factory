using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Service;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Vo.Insp;

namespace My_Smart_Factory.Controllers
{
    [Route("inspequip")]
    public class InspEquipController : Controller
    {
        private readonly IInspEquipService _inspEquipService;

        public InspEquipController(IInspEquipService inspEquipService)
        {
            _inspEquipService = inspEquipService;
        }
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var ieList = await _inspEquipService.GetAllAsync();
            var voList = new List<InspEquipVo>();
            foreach (var item in ieList)
            {
                voList.Add(_inspEquipService.ModelToVo(item));
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
        #endregion
        #region Edit
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _inspEquipService.GetByIdAsync(id);
            var dto = _inspEquipService.ModelToDto(model);
            return View(dto);
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
        #endregion
        #region Delete
        [HttpGet("delete")]
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
        #endregion
    }
}
