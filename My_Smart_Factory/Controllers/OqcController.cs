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

        #region Create
        [HttpPost("create")]
        public async Task<string> Create(OqcDto requestDto)
        {
            // 입력받은 inspector가 회원가입되어 있는 사람인지 확인
            var inspector = await _userManager.FindByNameAsync(requestDto.inspector);
            if (inspector == null) { return "Not Found Inspector"; }
            // 입력받은 confirmor가 회원가입되어 있는 사람인지 확인
            var confirmor = await _userManager.FindByNameAsync(requestDto.confirmor);
            if (confirmor == null) { return "Not Found Confirmor"; }

            // DB에 저장하기 위해 Model 생성
            var result = await _oqcService.Create(requestDto, inspector, confirmor);
            await _dbContext.OqcModels.AddAsync(result);
            await _dbContext.SaveChangesAsync();
            return "success";
        }
        #endregion

        #region Update
        [HttpPost("update")]
        public async Task<string> Update(OqcDto requestDto)
        {
            // 관리번호가 동일한게 여러개 있으니 Id 값으로 구분하여 데이터를 불러온다
            var oqc = await _dbContext.OqcModels
                .Include(o => o.Inspector)
                .Include(o => o.Confirmor)
                .Where(o => o.Id == requestDto.oqcId)
                .FirstOrDefaultAsync();

            // 제대로 값을 찾았는지 확인
            if (oqc == null) { return "Not Found Data"; }

            // update한 inspector가 가입되어 있는지 확인
            var inspector = await _userManager.FindByNameAsync(requestDto.inspector);
            if (inspector == null) { return "Not Found Inspector"; }

            // update한 confirmor가 가입되어 있는지 확인
            var confirmor = await _userManager.FindByNameAsync(requestDto.confirmor);
            if (confirmor == null) { return "Not Found Confirmor"; }

            // DB에 저장하기 위해 Model update
            await _oqcService.Update(requestDto, oqc, inspector, confirmor);
            await _dbContext.SaveChangesAsync();

            return "success";
        }
        #endregion

        #region Read
        [HttpGet("read")]
        public async Task<IActionResult> Read(string controlnumber)
        {
            // controlnumber의 정보들과 유저의 정보를 생성날짜 기준으로 내림차순하여 불러온다
            var oqcList = await _dbContext.OqcModels
                    .Include(o => o.Inspector)
                    .Include(o => o.Confirmor)
                    .Where(o => o.Controlnumber == controlnumber)
                    .OrderByDescending(o => o.InspectionTime)
                    .ToListAsync();

            // controlnumber가 없을 경우 신규 데이터를 추가해 준다
            if (oqcList.Count == 0) {
                // 유저 초깃값
                var inspector = await _userManager.FindByNameAsync("member");
                var confirmor = await _userManager.FindByNameAsync("member");

                List<OqcVo> oqcVos = new List<OqcVo>();
                OqcModel model = await _oqcService.CreateDefultModel(controlnumber, inspector, confirmor);
                if(model != null) {
                    await _dbContext.OqcModels.AddAsync(model);
                    await _dbContext.SaveChangesAsync();
                }
                // db의 저장된 데이터를 전송
                // 저장 전 보내면 Id값이 저장된 후에 만들어 지기 때문에
                // db 수정 과정에서 에러 발행한다
                model = await _dbContext.OqcModels.Where(o => o.Controlnumber == controlnumber).FirstOrDefaultAsync();
                oqcVos.Add(_oqcService.CreateOqcVo(model));
                return Json(oqcVos);
            }
            var result = await _oqcService.Read(oqcList);
            return Json(result);

        }
        #endregion

    }
}
