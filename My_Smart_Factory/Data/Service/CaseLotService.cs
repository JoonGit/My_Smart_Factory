using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service
{
    public class CaseLotService : EntityBaseRepository<CaseLotModel>, ICaseLotService
    {
        public CaseLotService(MyDbContext context) : base(context)
        {
        }
        private CaseLotModel UpdateModel(CaseLotModel model, CaseLotVo requestDto)
        {
            model.LotNumber = requestDto.LotNumber;
            model.Unit = requestDto.Unit;
            return model;
        }

        CaseLotModel ICaseLotService.UpdateModel(CaseLotModel model, CaseLotVo requestDto)
        {
            return UpdateModel(model, requestDto);
        }
    }
}
