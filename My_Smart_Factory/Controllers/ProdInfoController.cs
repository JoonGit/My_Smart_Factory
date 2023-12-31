using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Pi;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Models;
using System.Threading.Tasks;

namespace My_Smart_Factory.Controllers
{
    // 제품정보(Product Informaction)
    [Route("pi")]
    public class PiController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IPiService _piInterface;
        public PiController(MyDbContext context,
            IPiService piInterface)
        {
            _context = context;
            _piInterface = piInterface;
        }

        // PI 저장, 수정, 불러오기
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // piModel을 모두 불러온다
            var piModels = await _context.ProdInfoModels.ToListAsync();
            List<PiVo> voList = await _piInterface.ReadAll(piModels);
            if (piModels.Count() == 0) { return View(); }

            return View(voList);
        }

        #region Create
        // PI 생성
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(PiDto requestDto)
        {
            try
            {
                ProdInfoModel piModel = await _piInterface.Create(requestDto);
                var result = await _context.ProdInfoModels.AddAsync(piModel);
                await _context.SaveChangesAsync();
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
        public async Task<string> Update(PiDto requestDto)
        {
            try
            {
                ProdInfoModel piModel = await _context.ProdInfoModels.FindAsync(requestDto.id);
                if (piModel == null) { return "Not Found Pi";}
                else
                {
                    ProdInfoModel updateModel = await _piInterface.Update(piModel, requestDto);
                    if (updateModel == null) { return "Not Changed"; }

                    _context.ProdInfoModels.Update(piModel);
                    await _context.SaveChangesAsync();
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
