using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IFullInspRecordService : IEntityBaseRepository<FullInspRecordModel>
    {
        FullInspRecordModel UpdateModel(FullInspRecordModel model,
            FullInspRecordDto requestDto,
            WorkOrderModel WorkOrder,
            List<InspEquipSettingRecordModel> InspEquipSettingRecords,
            List<InspProdRecordModel> InspProdRecords);
    }
}
