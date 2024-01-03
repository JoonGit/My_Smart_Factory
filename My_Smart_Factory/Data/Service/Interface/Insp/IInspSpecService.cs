using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Interface.Insp
{
    public interface IInspSpecService : IEntityBaseRepository<InspSpecModel>
    {
        InspSpecModel UpdateModel(InspSpecModel model, InspSpecDto requestDto, ProdInfoModel ProdInfo, InspEquipModel InspEquip);
    }
}
