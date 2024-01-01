﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("processStatus")]
    //공정 진행 상황(Process progress status)
    public class ProcessStatusController : Controller
    {
        // Pps 저장(Pps와함께), 수정,
        // 불러오기(Pps정보를 include 해서 ppsVo에 담아서 Json으로)
        private readonly MyDbContext _context;
        private readonly IProcessStatusService _PpsInterface;
        public ProcessStatusController(MyDbContext context,
            IProcessStatusService PpsInterface)
        {
            _context = context;
            _PpsInterface = PpsInterface;
        }

        // Pps 저장, 수정, 불러오기
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // PpsModel을 pi저정보와 함께 모두 불러온다
            var ProcessStatusModels = await _context.ProcessStatusModels
                .Include(ProcessStatusModels => ProcessStatusModels.ProdInfoModel)
                .ToListAsync();
            List<ProcessStatusVo> voList = await _PpsInterface.ReadAll(ProcessStatusModels);
            if (ProcessStatusModels.Count() == 0) { return View(); }

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
        public async Task<IActionResult> Create(ProcessStatusDto requestDto)
        {
            try
            {
                // pi model을 requestDto.prodName 찾는다
                ProdInfoModel ProdInfoModel = await _context.ProdInfoModels
                    .FirstOrDefaultAsync(ProdInfoModel => ProdInfoModel.ProdName == requestDto.prodName);
                if (ProdInfoModel == null) { return BadRequest("Not Found Pi"); }
                // Operator를 requestDto.operatorName으로 찾는다
                UserIdentity Operator = await _context.UserIdentitys
                    .FirstOrDefaultAsync(UserIdentity => UserIdentity.UserName == requestDto.operatorName);
                if (Operator == null) { return BadRequest("Not Found Operator"); }
                ProcessStatusModel ProcessStatusModel = await _PpsInterface.Create(requestDto, ProdInfoModel, Operator);
                var result = await _context.ProcessStatusModels.AddAsync(ProcessStatusModel);
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
                List<ProcessStatusModel> ProcessStatusModels = await _context.ProcessStatusModels
                    .Where(ProcessStatusModel => ProcessStatusModel.Date == dateTime)
                    .Include(ProcessStatusModel => ProcessStatusModel.ProdInfoModel)
                    .ToListAsync();
                List<ProcessStatusVo> voList = await _PpsInterface.ReadAll(ProcessStatusModels);
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

                List<ProcessStatusModel> ProcessStatusModels = await _context.ProcessStatusModels
                    .Where(ProcessStatusModel => ProcessStatusModel.Date == dateTime)
                    .Include(ProcessStatusModel => ProcessStatusModel.ProdInfoModel)
                    .Include(ProcessStatusModel => ProcessStatusModel.Operator)
                    .ToListAsync();
                if (ProcessStatusModels == null) { return BadRequest("Not Found Pps"); }
                List<ProcessStatusUpdateDateAllVo> voList = await _PpsInterface.UpdateDateAll(ProcessStatusModels);
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
                ProcessStatusModel ProcessStatusModel = await _context.ProcessStatusModels.FindAsync(requestDto.id);
                if (ProcessStatusModel == null) { return "Not Found Pps"; }
                ProdInfoModel prodInfoModel = await _context.ProdInfoModels
                    .FirstOrDefaultAsync(PiModel => PiModel.ProdName == requestDto.prodName);
                if (prodInfoModel == null) { return "Not Found Pi"; }
                UserIdentity Operator = await _context.UserIdentitys
                    .FirstOrDefaultAsync(UserIdentity => UserIdentity.UserName == requestDto.operatorName);
                if (Operator == null) { return "Not Found Operator"; }
                ProcessStatusModel updateModel = await _PpsInterface.Update(ProcessStatusModel, prodInfoModel, Operator, requestDto);
                if (updateModel == null) { return "Not Changed"; }
                if (prodInfoModel == null) { return "Not Found Pi"; }

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
