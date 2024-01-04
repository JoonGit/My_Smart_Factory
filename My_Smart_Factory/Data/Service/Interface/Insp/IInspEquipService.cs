using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Service.Interface.Insp
{
    public interface IInspEquipService : IEntityBaseRepository<InspEquipModel>
    {
        InspEquipModel UpdateModel(InspEquipModel model, InspEquipDto requestDto);
        InspEquipVo ModelToVo(InspEquipModel model);
        InspEquipDto ModelToDto(InspEquipModel model);

    }
}
