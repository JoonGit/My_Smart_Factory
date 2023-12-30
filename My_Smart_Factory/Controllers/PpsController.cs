using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.Pps;
using My_Smart_Factory.Data;
using My_Smart_Factory.Models;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Dto.Pps;
using System;

namespace My_Smart_Factory.Controllers
{
    [Route("pps")]
    //공정 진행 상황(Process progress status)
    public class PpsController : Controller
    {
        // Pps 저장(Pps와함께), 수정,
        // 불러오기(Pps정보를 include 해서 ppsVo에 담아서 Json으로)
        private readonly MyDbContext _context;
        private readonly IPpsService _PpsInterface;
        public PpsController(MyDbContext context,
            IPpsService PpsInterface)
        {
            _context = context;
            _PpsInterface = PpsInterface;
        }

        // Pps 저장, 수정, 불러오기
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // PpsModel을 pi저정보와 함께 모두 불러온다
            var PpsModels = await _context.PpsModels
                .Include(PpsModel => PpsModel.PiModel)
                .ToListAsync();
            List<PpsVo> voList = await _PpsInterface.ReadAll(PpsModels);
            if (PpsModels.Count() == 0) { return View(); }

            return View();
        }

        #region Create
        // Pps 생성
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(PpsDto requestDto)
        {
            try
            {
                // pi model을 requestDto.controlNumber로 찾는다
                PiModel piModel = await _context.PiModels
                    .FirstOrDefaultAsync(PiModel => PiModel.ControlNumber == requestDto.controlNumber);
                if (piModel == null) { return BadRequest("Not Found Pi"); }
                // Operator를 requestDto.operatorName으로 찾는다
                UserIdentity Operator = await _context.UserIdentitys
                    .FirstOrDefaultAsync(UserIdentity => UserIdentity.UserName == requestDto.operatorName);
                if (Operator == null) { return BadRequest("Not Found Operator"); }
                PpsModel PpsModel = await _PpsInterface.Create(requestDto, piModel, Operator);
                var result = await _context.PpsModels.AddAsync(PpsModel);
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
        // pps를 PpsDto.date로 모두 찾는다
        [HttpGet("readbydate")]
        public async Task<IActionResult> ReadByDate(string date)
        {
            try
            {
                // string date를 DateTime으로 변환

                DateTime dateTime = Convert.ToDateTime(date);
                List<PpsModel> PpsModels = await _context.PpsModels
                    .Where(PpsModel => PpsModel.Date == dateTime)
                    .Include(PpsModel => PpsModel.PiModel)
                    .ToListAsync();
                List<PpsVo> voList = await _PpsInterface.ReadAll(PpsModels);
                if (voList == null) { return BadRequest("Not Found Pps"); }
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

                List<PpsModel> PpsModels = await _context.PpsModels
                    .Where(PpsModel => PpsModel.Date == dateTime)
                    .Include(PpsModel => PpsModel.PiModel)
                    .Include(PpsModel => PpsModel.Operator)
                    .ToListAsync();
                if (PpsModels == null) { return BadRequest("Not Found Pps"); }
                List<PpsUpdateDateAllVo> voList = await _PpsInterface.UpdateDateAll(PpsModels);
                return Json(voList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("update")]
        public async Task<string> Update(PpsDto requestDto)
        {
            try
            {
                PpsModel ppsModel = await _context.PpsModels.FindAsync(requestDto.id);
                if (ppsModel == null) { return "Not Found Pps"; }
                PiModel piModel = await _context.PiModels
                    .FirstOrDefaultAsync(PiModel => PiModel.ControlNumber == requestDto.controlNumber);
                if (piModel == null) { return "Not Found Pi"; }
                UserIdentity Operator = await _context.UserIdentitys
                    .FirstOrDefaultAsync(UserIdentity => UserIdentity.UserName == requestDto.operatorName);
                if (Operator == null) { return "Not Found Operator"; }
                PpsModel updateModel = await _PpsInterface.Update(ppsModel, piModel, Operator, requestDto);
                if (updateModel == null) { return "Not Changed"; }
                if (piModel == null) { return "Not Found Pi"; }

                _context.PpsModels.Update(updateModel);
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
