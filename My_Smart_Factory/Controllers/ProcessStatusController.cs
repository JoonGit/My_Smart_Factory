using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.ProcessStatus;
using My_Smart_Factory.Data;
using My_Smart_Factory.Models;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Dto.ProcessStatus;
using System;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Controllers
{
    //진행 상황(progress status)
    [Route("processStatus")]
    public class ProcessStatusController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IProcessStatusService _psService;

        public ProcessStatusController(MyDbContext context,
            IProcessStatusService psService)
        {
            _context = context;
            _psService = psService;
        }

        // ps 저장, 수정, 불러오기
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // psModel을 pi저정보와 함께 모두 불러온다
            var psModels = await _context.ProcessStatusModels
                .Include(psModels => psModels.ProdInfoModel)
                .ToListAsync();
            List<ProcessStatusVo> voList = await _psService.ReadAll(psModels);
            if (psModels.Count() == 0) { return View(); }

            return View();
        }

        #region Create
        // ps 생성
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(ProcessStatusDto requestDto)
        {
            try
            {
                ProdInfoModel? piModel = await _context.ProdInfoModels
                    .FirstOrDefaultAsync(piModel => piModel.ProdName == requestDto.prodName);
                if (piModel == null) { return BadRequest("Not Found ProdInfo"); }

                UserIdentity? Operator = await _context.UserIdentitys
                    .FirstOrDefaultAsync(UserIdentity => UserIdentity.UserName == requestDto.operatorName);
                if (Operator == null) { return BadRequest("Not Found Operator"); }

                ProcessStatusModel psModel = await _psService.Create(requestDto, piModel, Operator);
                var result = await _context.ProcessStatusModels.AddAsync(psModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
        #region Read
        // ps를 psDto.date로 모두 찾는다
        [HttpGet("readbydate")]
        public async Task<IActionResult> ReadByDate(string date)
        {
            try
            {
                // string date를 DateTime으로 변환
                DateTime dateTime = Convert.ToDateTime(date);

                List<ProcessStatusModel> psModels = await _context.ProcessStatusModels
                    .Where(psModel => psModel.Date == dateTime)
                    .Include(psModel => psModel.ProdInfoModel)
                    .ToListAsync();

                List<ProcessStatusVo>? voList = await _psService.ReadAll(psModels);

                if (voList == null) { return BadRequest("Not Found ProcessStatus"); }

                return Json(voList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
        #region update
        [HttpGet("update")]
        public async Task<IActionResult> Update()
        {
            return View();
        }
        [HttpGet("updatedateall")]
        public async Task<IActionResult> UpdateDateAll(string date)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(date);

                List<ProcessStatusModel> psModels = await _context.ProcessStatusModels
                    .Where(psModel => psModel.Date == dateTime)
                    .Include(psModel => psModel.ProdInfoModel)
                    .Include(psModel => psModel.Operator)
                    .ToListAsync();
                if (psModels == null) { return BadRequest("Not Found ProcessStatus"); }
                List<ProcessStatusUpdateDateAllVo>? voList = await _psService.UpdateDateAll(psModels);
                return Json(voList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("update")]
        public async Task<string> Update(ProcessStatusDto requestDto)
        {
            try
            {
                ProcessStatusModel? psModel = await _context.ProcessStatusModels.FindAsync(requestDto.id);
                if (psModel == null) { return "Not Found ProcessStatus"; }

                ProdInfoModel? piModel = await _context.ProdInfoModels
                    .FirstOrDefaultAsync(PiModel => PiModel.ProdName == requestDto.prodName);
                if (piModel == null) { return "Not Found ProdInfo"; }

                UserIdentity? Operator = await _context.UserIdentitys
                    .FirstOrDefaultAsync(UserIdentity => UserIdentity.UserName == requestDto.operatorName);
                if (Operator == null) { return "Not Found Operator"; }

                ProcessStatusModel? updateModel = await _psService.Update(psModel, piModel, Operator, requestDto);
                if (updateModel == null) { return "Not Changed"; }

                _context.ProcessStatusModels.Update(updateModel);
                await _context.SaveChangesAsync();
                return "success";
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
