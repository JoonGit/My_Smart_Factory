using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.ProcessStatus;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.ProcessStatus;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service
{
    public class ProcessStatusService : EntityBaseRepository<ProcessStatusModel>, IProcessStatusService
    {
        public ProcessStatusService(MyDbContext context) : base(context)
        {
        }

        #region Create
        private async Task<ProcessStatusModel> Create(ProcessStatusDto requestDto, ProdInfoModel ProdInfoModel, UserIdentity Operator)
        {
            try
            {
                ProcessStatusModel psModel = new ProcessStatusModel();
                psModel.ProdInfoModel = ProdInfoModel;
                psModel.Date = requestDto.date;
                psModel.Quantity = requestDto.quantity;
                psModel.Operator = Operator;
                psModel.DefectiveQuantity = requestDto.defectiveQuantity;
                return psModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        #endregion
        #region Read
        private async Task<List<ProcessStatusVo>?> ReadAll(List<ProcessStatusModel> psModels)
        {
            try
            {
                List<ProcessStatusVo> voList = new List<ProcessStatusVo>();
                foreach (var psModel in psModels)
                {
                    ProcessStatusVo psVo = new ProcessStatusVo();
                    psVo.id = psModel.Id;
                    psVo.prodName = psModel.ProdInfoModel.ProdName;
                    psVo.prodCode = psModel.ProdInfoModel.ProdCode;
                    psVo.prodWeight = psModel.ProdInfoModel.ProdWeight;
                    psVo.quantity = psModel.Quantity;
                    psVo.defectiveQuantity = psModel.DefectiveQuantity;

                    if (psModel.Quantity != 0)
                    {
                        decimal defectRate = (psModel.DefectiveQuantity / (decimal)psModel.Quantity) * 100;
                        psVo.defectRate = Math.Round(defectRate, 5);
                    }
                    else
                    {
                        psVo.defectRate = 0;
                    }

                    voList.Add(psVo);
                }
                return voList;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        private async Task<List<ProcessStatusUpdateDateAllVo>?> UpdateDateAll(List<ProcessStatusModel> psModels)
        {
            try
            {
                List<ProcessStatusUpdateDateAllVo> voList = new List<ProcessStatusUpdateDateAllVo>();
                foreach (var psModel in psModels)
                {
                    ProcessStatusUpdateDateAllVo psVo = new ProcessStatusUpdateDateAllVo();
                    psVo.id = psModel.Id;
                    psVo.ProdName = psModel.ProdInfoModel.ProdName;
                    psVo.date = psModel.Date;
                    psVo.quantity = psModel.Quantity;
                    psVo.operatorName = psModel.Operator.UserName;
                    psVo.defectiveQuantity = psModel.DefectiveQuantity;

                    voList.Add(psVo);
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
        private async Task<ProcessStatusModel?> Update(ProcessStatusModel oldModel, ProdInfoModel piModel, UserIdentity Operator, ProcessStatusDto UpdateModel)
        {
            ProcessStatusModel saveModel = oldModel;
            try

                {
                    oldModel.ProdInfoModel = piModel;
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
        #region interface
        Task<ProcessStatusModel> IProcessStatusService.Create(ProcessStatusDto requestDto, ProdInfoModel piModel, UserIdentity Operator)
        {
            return Create(requestDto, piModel, Operator);
        }
        Task<List<ProcessStatusVo>?> IProcessStatusService.ReadAll(List<ProcessStatusModel> piModels)
        {
            return ReadAll(piModels);
        }

        Task<ProcessStatusModel?> IProcessStatusService.Update(ProcessStatusModel oldModel, ProdInfoModel piModel, UserIdentity Operator, ProcessStatusDto UpdateModel)
        {
            return Update(oldModel, piModel, Operator, UpdateModel);
        }

        Task<List<ProcessStatusUpdateDateAllVo>?> IProcessStatusService.UpdateDateAll(List<ProcessStatusModel> psModels)
        {
            return UpdateDateAll(psModels);
        }
#endregion
    }
}
