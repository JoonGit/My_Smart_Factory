using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data.Dto.Prod;
using My_Smart_Factory.Data.Vo.FullInsp;
using My_Smart_Factory.Data.Vo.Prod;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IFullInspRecordService : IEntityBaseRepository<FullInspRecordModel>
    {
        FullInspRecordModel UpdateModel(FullInspRecordModel model,
            FullInspRecordDto requestDto,
            WorkOrderModel WorkOrder,
            List<InspEquipSettingRecordModel> InspEquipSettingRecords,
            List<InspProdRecordModel> InspProdRecords);

        FullInspRecordDto ModelToDto(FullInspRecordModel model);

        List<FullInspProdRecordVo> ModelToProdVo(FullInspRecordModel model);
        List<FullInspEquipRecordVo> ModelToEquipVo(FullInspRecordModel model);
        FullInspRecordVo ModelToVo(FullInspRecordModel model);
    }
}
