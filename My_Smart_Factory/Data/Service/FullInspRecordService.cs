using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Service
{
    public class FullInspRecordService : EntityBaseRepository<FullInspRecordModel>, IFullInspRecordService
    {
        public FullInspRecordService(MyDbContext context) : base(context)
        {
        }

        private FullInspRecordModel UpdateModel(FullInspRecordModel model,
            FullInspRecordDto requestDto,
            WorkOrderModel WorkOrder,
            List<InspEquipSettingRecordModel> InspEquipSettingRecords,
            List<InspProdRecordModel> InspProdRecords)
        {
            model.WorkOrder = WorkOrder;
            model.InspEquipSettingRecords = InspEquipSettingRecords;
            model.FullInspectionNumber = requestDto.FullInspectionNumber;
            model.InspProdRecords = InspProdRecords;
            return model;
        }

        FullInspRecordModel IFullInspRecordService.UpdateModel(FullInspRecordModel model, FullInspRecordDto requestDto, WorkOrderModel WorkOrder, List<InspEquipSettingRecordModel> InspEquipSettingRecords, List<InspProdRecordModel> InspProdRecords)
        {
            return UpdateModel(model, requestDto, WorkOrder, InspEquipSettingRecords, InspProdRecords);
        }
    }
}
