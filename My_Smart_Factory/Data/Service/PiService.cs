using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Pi;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service
{
    public class PiService : EntityBaseRepository<PiModel>, IPiService
    {
        public PiService(MyDbContext context) : base(context)
        {
        }



        #region Create
        private async Task<PiModel> Create(PiDto requestDto)
        {
            try
            {
                PiModel piModel = new PiModel();
                piModel.ControlNumber = requestDto.controlNumber;
                piModel.Specification = requestDto.specification;
                piModel.LotNumber = requestDto.lotNumber;
                return piModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion
        #region ReadAll
        private async Task<List<PiVo>?> ReadAll(List<PiModel> piModels)
        {
            try
            {
                List<PiVo> voList = new List<PiVo>();
                foreach (var piModel in piModels)
                {
                    PiVo piVo = new PiVo();
                    piVo.id = piModel.Id;
                    piVo.controlNumber = piModel.ControlNumber;
                    piVo.specification = piModel.Specification;
                    piVo.lotNumber = piModel.LotNumber;
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
        private async Task<PiModel?> Update(PiModel oldModel, PiDto UpdateModel)
        {
            PiModel saveModel = oldModel;
            try
            {
                oldModel.ControlNumber = UpdateModel.controlNumber;
                oldModel.Specification = UpdateModel.specification;
                oldModel.LotNumber = UpdateModel.lotNumber;
                return oldModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion

        Task<List<PiVo>?> IPiService.ReadAll(List<PiModel> piModels)
        {
            return ReadAll(piModels);
        }

        Task<PiModel> IPiService.Create(PiDto requestDto)
        {
            return Create(requestDto);
        }

        Task<PiModel?> IPiService.Update(PiModel oldModel, PiDto UpdateModel)
        {
            return Update(oldModel, UpdateModel);
        }
    }
}
