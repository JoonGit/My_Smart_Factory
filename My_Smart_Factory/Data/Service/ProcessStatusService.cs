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
                ProcessStatusModel ppsModel = new ProcessStatusModel();
                ppsModel.ProdInfoModel = ProdInfoModel;
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
        private async Task<List<ProcessStatusVo>?> ReadAll(List<ProcessStatusModel> processStatusModels)
        {
            try
            {
                List<ProcessStatusVo> voList = new List<ProcessStatusVo>();
                foreach (var processStatusModel in processStatusModels)
                {
                    ProcessStatusVo processStatusVo = new ProcessStatusVo();
                    processStatusVo.id = processStatusModel.Id;
                    processStatusVo.prodName = processStatusModel.ProdInfoModel.ProdName;
                    processStatusVo.prodCode = processStatusModel.ProdInfoModel.ProdCode;
                    processStatusVo.prodWeight = processStatusModel.ProdInfoModel.ProdWeight;
                    processStatusVo.quantity = processStatusModel.Quantity;
                    processStatusVo.defectiveQuantity = processStatusModel.DefectiveQuantity;

                    if (processStatusModel.Quantity != 0)
                    {
                        double defectRate = (processStatusModel.DefectiveQuantity / (double)processStatusModel.Quantity) * 100;
                        processStatusVo.defectRate = Math.Round(defectRate, 5);
                    }
                    else
                    {
                        processStatusVo.defectRate = 0;
                    }

                    voList.Add(processStatusVo);
                }
                return voList;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        private async Task<List<ProcessStatusUpdateDateAllVo>?> UpdateDateAll(List<ProcessStatusModel> processStatusModels)
        {
            try
            {
                List<ProcessStatusUpdateDateAllVo> voList = new List<ProcessStatusUpdateDateAllVo>();
                foreach (var ppsModel in processStatusModels)
                {
                    ProcessStatusUpdateDateAllVo ppsVo = new ProcessStatusUpdateDateAllVo();
                    ppsVo.id = ppsModel.Id;
                    ppsVo.ProdName = ppsModel.ProdInfoModel.ProdName;
                    ppsVo.date = ppsModel.Date;
                    ppsVo.quantity = ppsModel.Quantity;
                    ppsVo.operatorName = ppsModel.Operator.UserName;
                    ppsVo.defectiveQuantity = ppsModel.DefectiveQuantity;


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
        private async Task<ProcessStatusModel?> Update(ProcessStatusModel oldModel, ProdInfoModel piModel, UserIdentity Operator, ProcessStatusDto UpdateModel)
        {
            ProcessStatusModel saveModel = oldModel;
            try

                // 새로운 psModel을 생성한다
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

        Task<List<ProcessStatusUpdateDateAllVo>?> IProcessStatusService.UpdateDateAll(List<ProcessStatusModel> PpsModels)
        {
            return UpdateDateAll(PpsModels);
        }
    }
}
