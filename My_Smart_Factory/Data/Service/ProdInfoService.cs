﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Pi;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service
{
    public class ProdInfoService : EntityBaseRepository<ProdInfoModel>, IProdInfoService
    {
        public ProdInfoService(MyDbContext context) : base(context)
        {
        }



        #region Create
        private async Task<ProdInfoModel> Create(ProdInfoDto requestDto)
        {
            try
            {
                ProdInfoModel ProdInfoModel = new ProdInfoModel();
                ProdInfoModel.ProdName = requestDto.prodName;
                ProdInfoModel.ProdCode = requestDto.prodCode;
                ProdInfoModel.ProdWeight = requestDto.prodWeight;
                return ProdInfoModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion
        #region ReadAll
        private async Task<List<ProdInfoVo>?> ReadAll(List<ProdInfoModel> ProdInfoModels)
        {
            try
            {
                List<ProdInfoVo> voList = new List<ProdInfoVo>();
                foreach (var ProdInfoModel in ProdInfoModels)
                {
                    ProdInfoVo piVo = new ProdInfoVo();
                    piVo.id = ProdInfoModel.Id;
                    piVo.prodName = ProdInfoModel.ProdName;
                    piVo.prodCode = ProdInfoModel.ProdCode;
                    piVo.prodWeight = ProdInfoModel.ProdWeight;
                    voList.Add(piVo);
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
        private async Task<ProdInfoModel?> Update(ProdInfoModel oldModel, ProdInfoDto UpdateModel)
        {
            try
            {
                oldModel.ProdName = UpdateModel.prodName;
                oldModel.ProdCode = UpdateModel.prodCode;
                oldModel.ProdWeight = UpdateModel.prodWeight;
                return oldModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion

        Task<List<ProdInfoVo>?> IProdInfoService.ReadAll(List<ProdInfoModel> piModels)
        {
            return ReadAll(piModels);
        }

        Task<ProdInfoModel> IProdInfoService.Create(ProdInfoDto requestDto)
        {
            return Create(requestDto);
        }

        Task<ProdInfoModel?> IProdInfoService.Update(ProdInfoModel oldModel, ProdInfoDto UpdateModel)
        {
            return Update(oldModel, UpdateModel);
        }
    }
}
