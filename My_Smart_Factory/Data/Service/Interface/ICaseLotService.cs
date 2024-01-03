using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface ICaseLotService : IEntityBaseRepository<CaseLotModel>
    {
        CaseLotModel UpdateModel(CaseLotModel model, CaseLotVo requestDto);
    }
}
