using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Controllers
{
    [Route("InspEquipSettingRecord")]
    public class InspEquipSettingRecordController : Controller
    {
        private readonly IInspEquipSettingRecordService _inspEquipSettingRecordService;
        private readonly MyDbContext _context;

        public InspEquipSettingRecordController(IInspEquipSettingRecordService inspEquipSettingRecordService,
            MyDbContext context)
        {
            _inspEquipSettingRecordService = inspEquipSettingRecordService;
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
        public async Task<IActionResult> Create(InspEquipSettingRecordDto requestDto)
        {
            try
            {
                //InspEquipModel InspEquip, InspSpecModel InspSpec
                InspEquipModel? InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == requestDto.InspEquipName);
                if (InspEquip == null) { BadRequest("No InspEquip"); }
                InspSpecModel? InspSpec = await _context.InspSpecModels.FirstOrDefaultAsync(x => x.InspSpecName == requestDto.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspSpec"); }
                await _inspEquipSettingRecordService.AddAsync(requestDto.ToModel(InspEquip, InspSpec));
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
            var ieList = await _inspEquipSettingRecordService.GetAllAsync();
            return View(ieList);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _inspEquipSettingRecordService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(InspEquipSettingRecordDto requestDto)
        {
            try
            {
                var model = await _inspEquipSettingRecordService.GetByIdAsync(requestDto.Id);
                InspEquipModel? InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == requestDto.InspEquipName);
                if (InspEquip == null) { BadRequest("No InspEquip"); }
                InspSpecModel? InspSpec = await _context.InspSpecModels.FirstOrDefaultAsync(x => x.InspSpecName == requestDto.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspSpec"); }
                await _inspEquipSettingRecordService.UpdateAsync(requestDto.Id, _inspEquipSettingRecordService.UpdateModel(model, requestDto, InspEquip, InspSpec));
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
                await _inspEquipSettingRecordService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
