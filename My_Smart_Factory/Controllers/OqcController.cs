using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using My_Smart_Factory.Data;
using My_Smart_Factory.Data.Dto.Oqc;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Migrations;
using My_Smart_Factory.Models;
using System.Text;

namespace My_Smart_Factory.Controllers
{
    [Route("oqc")]
    public class OqcController : Controller
    {
        private readonly MyDbContext _dbContext;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly IOqcService _oqcService;
        public OqcController(
            MyDbContext dbContext
            , UserManager<UserIdentity> userManager
            , IOqcService oqcService
            )
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _oqcService = oqcService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<string> Create(OqcDto requestDto)
        {
            var inspector = await _userManager.FindByNameAsync(requestDto.inspector);
            if (inspector == null) { return "Not Found Inspector"; }
            var confirmor = await _userManager.FindByNameAsync(requestDto.confirmor);
            if (confirmor == null) { return "Not Found Confirmor"; }
            var result = await _oqcService.Create(requestDto, inspector, confirmor);
            await _dbContext.OqcModels.AddAsync(result);
            await _dbContext.SaveChangesAsync();
            return "success";
        }

        [HttpPost("update")]
        public async Task<string> Update(OqcDto requestDto)
        {
            var oqc = await _dbContext.OqcModels
                .Include(o => o.Inspector)
                .Include(o => o.Confirmor)
                .Where(o => o.Id == requestDto.oqcId)
                .FirstOrDefaultAsync();
            if (oqc == null) { return "Not Found Data"; }
            var inspector = await _userManager.FindByNameAsync(requestDto.inspector);
            if (inspector == null) { return "Not Found Inspector"; }
            var confirmor = await _userManager.FindByNameAsync(requestDto.confirmor);
            if (confirmor == null) { return "Not Found Confirmor"; }
            await _oqcService.Update(requestDto, oqc, inspector, confirmor);
            await _dbContext.SaveChangesAsync();

            return "success";
        }

        [HttpGet("read")]
        public async Task<IActionResult> Read(string controlnumber)
        {
            var oqcList = await _dbContext.OqcModels
                    .Include(o => o.Inspector)
                    .Include(o => o.Confirmor)
                    .Where(o => o.Controlnumber == controlnumber)
                    .OrderByDescending(o => o.InspectionTime)
                    .ToListAsync();
            var inspector = await _userManager.FindByNameAsync("member");
            var confirmor = await _userManager.FindByNameAsync("member");
            if (oqcList.Count == 0) {
                List<OqcVo> oqcVos = new List<OqcVo>();
                OqcModel model = await _oqcService.CreateDefultModel(controlnumber, inspector, confirmor);
                if(model != null) {
                    oqcVos.Add(_oqcService.CreateOqcVo(model));
                    await _dbContext.OqcModels.AddAsync(model);
                    await _dbContext.SaveChangesAsync();
                }
                return Json(oqcVos);
            }
            var result = await _oqcService.Read(oqcList, inspector, confirmor);
            return Json(result);

        }
    }
}
