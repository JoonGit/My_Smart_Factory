using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Service.Interface;

namespace My_Smart_Factory.Controllers
{
    public class CaseLotController : Controller
    {
        private readonly ICaseLotService _caseLotService;

        public CaseLotController(ICaseLotService caseLotService)
        {
            _caseLotService = caseLotService;
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
        public async Task<IActionResult> Create(CaseLotVo requestDto)
        {
            try
            {
                await _caseLotService.AddAsync(requestDto.ToModel());
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
            var ieList = await _caseLotService.GetAllAsync();
            return View(ieList);
        }
        #endregion
        #region Edit
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _caseLotService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(CaseLotVo requestDto)
        {
            try
            {
                var model = await _caseLotService.GetByIdAsync(requestDto.Id);
                await _caseLotService.UpdateAsync(requestDto.Id, _caseLotService.UpdateModel(model, requestDto));
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
                await _caseLotService.DeleteAsync(id);
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
