using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Insp;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Vo.Insp;

namespace My_Smart_Factory.Controllers
{
    [Route("inspspec")]
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
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            // inclue 해서 모두 가져오기
            var isList = await _context.InspSpecModels
                .Include(x => x.ProdInfo)
                .Include(x => x.InspEquip)
                .ToListAsync();
            var voList = new List<InspSpecVo>();
            foreach (var item in isList)
            {
                voList.Add(_inspSpecService.ModelToVo(item));
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
        #endregion
        #region edit
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.InspSpecModels
                .Include(x => x.ProdInfo)
                .Include(x => x.InspEquip)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var dto = _inspSpecService.ModelToDto(model);
            return View(dto);
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
        #endregion
        #region delete
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
        #endregion
    }
}
