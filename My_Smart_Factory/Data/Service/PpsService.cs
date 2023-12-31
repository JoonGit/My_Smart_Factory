﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Pps;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.Pps;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service
{
    public class PpsService : EntityBaseRepository<ProcessStatusModel>, IPpsService
    {
        public PpsService(MyDbContext context) : base(context)
        {
        }



        #region Create
        private async Task<ProcessStatusModel> Create(PpsDto requestDto, ProdInfoModel piModel, UserIdentity Operator)
        {
            try
            {
                ProcessStatusModel ppsModel = new ProcessStatusModel();
                ppsModel.PiModel = piModel;
                ppsModel.Date = requestDto.date;
                ppsModel.Quantity = requestDto.quantity;
                ppsModel.Operator = Operator;
                ppsModel.DefectiveQuantity = requestDto.defectiveQuantity;
                return ppsModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        #endregion
        #region Read
        private async Task<List<PpsVo>?> ReadAll(List<ProcessStatusModel> PpsModels)
        {
            try
            {
                List<PpsVo> voList = new List<PpsVo>();
                foreach (var PpsModel in PpsModels)
                {
                    PpsVo ppsVo = new PpsVo();
                    ppsVo.id = PpsModel.Id;
                    ppsVo.specification = PpsModel.PiModel.Specification;
                    ppsVo.lotNumber = PpsModel.PiModel.LotNumber;
                    ppsVo.quantity = PpsModel.Quantity;
                    ppsVo.defectiveQuantity = PpsModel.DefectiveQuantity;

                    if (PpsModel.Quantity != 0)
                    {
                        double defectRate = (PpsModel.DefectiveQuantity / (double)PpsModel.Quantity) * 100;
                        ppsVo.defectRate = Math.Round(defectRate, 5);
                    }
                    else
                    {
                        ppsVo.defectRate = 0;
                    }

                    voList.Add(ppsVo);
                }
                return voList;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        private async Task<List<PpsUpdateDateAllVo>?> UpdateDateAll(List<ProcessStatusModel> PpsModels)
        {
            try
            {
                List<PpsUpdateDateAllVo> voList = new List<PpsUpdateDateAllVo>();
                foreach (var PpsModel in PpsModels)
                {
                    PpsUpdateDateAllVo ppsVo = new PpsUpdateDateAllVo();
                    ppsVo.id = PpsModel.Id;
                    ppsVo.controlNumber = PpsModel.PiModel.ControlNumber;
                    ppsVo.date = PpsModel.Date;
                    ppsVo.quantity = PpsModel.Quantity;
                    ppsVo.operatorName = PpsModel.Operator.UserName;
                    ppsVo.defectiveQuantity = PpsModel.DefectiveQuantity;


                    voList.Add(ppsVo);
                }
                return voList;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        #endregion
        #region Update
        private async Task<ProcessStatusModel?> Update(ProcessStatusModel oldModel, ProdInfoModel piModel, UserIdentity Operator, PpsDto UpdateModel)
        {
            ProcessStatusModel saveModel = oldModel;
            try

                // 새로운 psModel을 생성한다
                {
                    oldModel.PiModel = piModel;
                    oldModel.Date = UpdateModel.date;
                    oldModel.Quantity = UpdateModel.quantity;
                    oldModel.Operator = Operator;
                    oldModel.DefectiveQuantity = UpdateModel.defectiveQuantity;


                    return oldModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion

        Task<ProcessStatusModel> IPpsService.Create(PpsDto requestDto, ProdInfoModel piModel, UserIdentity Operator)
        {
            return Create(requestDto, piModel, Operator);
        }
        Task<List<PpsVo>?> IPpsService.ReadAll(List<ProcessStatusModel> piModels)
        {
            return ReadAll(piModels);
        }

        Task<ProcessStatusModel?> IPpsService.Update(ProcessStatusModel oldModel, ProdInfoModel piModel, UserIdentity Operator, PpsDto UpdateModel)
        {
            return Update(oldModel, piModel, Operator, UpdateModel);
        }

        Task<List<PpsUpdateDateAllVo>?> IPpsService.UpdateDateAll(List<ProcessStatusModel> PpsModels)
        {
            return UpdateDateAll(PpsModels);
        }
    }
}
