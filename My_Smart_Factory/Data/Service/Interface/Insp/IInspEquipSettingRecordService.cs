using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;
using NuGet.Packaging.Signing;

namespace My_Smart_Factory.Data.Service.Interface.Insp
{
    public interface IInspEquipSettingRecordService : IEntityBaseRepository<InspEquipSettingRecordModel>
    {
        InspEquipSettingRecordModel UpdateModel(InspEquipSettingRecordModel model,
            InspEquipSettingRecordDto requestDto,
            InspEquipModel InspEquip,
            InspSpecModel InspSpec,
            FullInspRecordModel FullInspRecord,
            decimal Accuracy);

        InspEquipSettingRecordVo ModelToVo(InspEquipSettingRecordModel model);
        InspEquipSettingRecordDto ModelToDto(InspEquipSettingRecordModel model);
    }
}
