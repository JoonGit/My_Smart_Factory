using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models;

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
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            // inclue 해서 모두 가져오기
            var iesrList = await _context.InspEquipSettingRecordModels
                .Include(x => x.InspEquip)
                .Include(x => x.InspSpec).Include(x => x.InspSpec.ProdInfo)
                .Include(x => x.FullInspRecord)
                .ToListAsync();
            var voList = new List<InspEquipSettingRecordVo>();

            foreach (var item in iesrList)
            {
                voList.Add(_inspEquipSettingRecordService.ModelToVo(item));
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
        public async Task<IActionResult> Create(InspEquipSettingRecordDto requestDto)
        {
            try
            {
                //InspEquipModel InspEquip, InspSpecModel InspSpec
                InspEquipModel? InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == requestDto.InspEquipName);
                if (InspEquip == null) { BadRequest("No InspEquip"); }
                // InspSpec에 ProdInfo를 포함 시킨다
                InspSpecModel? InspSpec = await _context.InspSpecModels
                    .Include(x => x.ProdInfo)
                    .FirstOrDefaultAsync(x => x.InspSpecName == requestDto.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspSpec"); }
                FullInspRecordModel? FullInspRecord = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspNo == requestDto.FullInspNo);
                if (FullInspRecord == null) { BadRequest("No FullInspRecord"); }
                decimal Accuracy = ((decimal)requestDto.IES / (decimal)InspSpec.ProdInfo.ProdWeight) * 100;
                await _inspEquipSettingRecordService.AddAsync(requestDto.ToModel(InspEquip, InspSpec, FullInspRecord, Accuracy));
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
            var model = await _context.InspEquipSettingRecordModels
                .Include(x => x.InspEquip)
                .Include(x => x.InspSpec).Include(x => x.InspSpec.ProdInfo)
                .Include(x => x.FullInspRecord)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var dto = _inspEquipSettingRecordService.ModelToDto(model);
            return View(dto);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(InspEquipSettingRecordDto requestDto)
        {
            try
            {
                var model = await _inspEquipSettingRecordService.GetByIdAsync(requestDto.Id);
                InspEquipModel? InspEquip = await _context.InspEquipModels.FirstOrDefaultAsync(x => x.InspEquipName == requestDto.InspEquipName);
                if (InspEquip == null) { BadRequest("No InspEquip"); }
                InspSpecModel? InspSpec = await _context.InspSpecModels
                    .Include(x => x.ProdInfo)
                    .FirstOrDefaultAsync(x => x.InspSpecName == requestDto.InspSpecName);
                if (InspSpec == null) { BadRequest("No InspSpec"); }
                FullInspRecordModel? FullInspRecord = await _context.FullInspRecordModels.FirstOrDefaultAsync(x => x.FullInspNo == requestDto.FullInspNo);
                if (FullInspRecord == null) { BadRequest("No FullInspRecord"); }
                decimal Accuracy = ((decimal)requestDto.IES / (decimal)InspSpec.ProdInfo.ProdWeight) * 100;
                await _inspEquipSettingRecordService.UpdateAsync(requestDto.Id, _inspEquipSettingRecordService.UpdateModel(model, requestDto, InspEquip, InspSpec, FullInspRecord, Accuracy));
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
                await _inspEquipSettingRecordService.DeleteAsync(id);
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
