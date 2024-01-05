using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Prod;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Service.Interface.Prod;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Data.Vo.Prod;

namespace My_Smart_Factory.Controllers
{
    [Route("ProdCtrlNo")]
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
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var ieList = await _context.ProdCtrlNoModels
                .Include(x => x.ProdInfo)
                .ToListAsync();
            var voList = new List<ProdCtrlNoVo>();
            foreach (var item in ieList)
            {
                voList.Add(_prodCtrlNoService.ModelToVo(item));
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
        #endregion
        #region edit

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.ProdCtrlNoModels
                .Include(x => x.ProdInfo)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var dto = _prodCtrlNoService.ModelToDto(model);
            return View(dto);
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
        #endregion
        #region Delete
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
        #endregion
    }
}
