using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Pi;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Models.Prod;
using System.Threading.Tasks;

namespace My_Smart_Factory.Controllers
{
    // 제품정보(Product Informaction)
    [Route("prodInfo")]
    public class ProdInfoController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IProdInfoService _piService;
        public ProdInfoController(MyDbContext context,
            IProdInfoService piService)
        {
            _context = context;
            _piService = piService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var piModels = await _piService.GetAllAsync();
            if (piModels.Count() == 0) { return View(); }
            IEnumerable<ProdInfoVo>? voList = await _piService.ToVo(piModels);

            return View(voList);
        }

        #region Create
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(ProdInfoDto requestDto)
        {
            try
            {
                await _piService.AddAsync(requestDto.ToModel());
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
        #region update
        [HttpPost("update")]
        public async Task<string> Update(ProdInfoDto requestDto)
        {
            try
            {
                ProdInfoModel? piModel = await _piService.GetByIdAsync(requestDto.id);
                if (piModel == null) { return "Not Found ProdInfo";}
                else
                {
                    await _piService.UpdateAsync(requestDto.id, await _piService.Update(piModel, requestDto));
                    return "success";
                }
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return "false";
            }
        }
        #endregion

    }
}
