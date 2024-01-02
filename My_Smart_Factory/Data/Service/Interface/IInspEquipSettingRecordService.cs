using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IInspEquipSettingRecordService : IEntityBaseRepository<InspEquipSettingRecordModel>
    {
        InspEquipSettingRecordModel UpdateModel(InspEquipSettingRecordModel model,
            InspEquipSettingRecordDto requestDto,
            InspEquipModel InspEquip,
            InspSpecModel InspSpec);
    }
}
