using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Vo;

namespace My_Smart_Factory.Data.Dto
{
    public class FullInspRecordDto
    {
        public int Id { get; set; }
        public string? FullInspectionNumber { get; set; }                                               // 전수검사번호
        public string? WorkOrderNumber { get; set; }                                                    // 작업 지시 번호

        public virtual List<InspEquipSettingRecordDto>? InspEquipSettingRecordDtos { get; set; }        // 검사장비 세팅 기록
        public virtual List<InspProdRecordDto> InspProdRecordDtos { get; set; }                         // 제품 검사 기록   

        public FullInspRecordModel ToModel(WorkOrderModel WorkOrder,
            List<InspEquipSettingRecordModel> InspEquipSettingRecords,
            List<InspProdRecordModel> InspProdRecords)
        {
            FullInspRecordModel model = new FullInspRecordModel();
            model.WorkOrder = WorkOrder;
            model.InspEquipSettingRecords = InspEquipSettingRecords;
            model.InspProdRecords = InspProdRecords;

            return model;
        }
        public FullInspRecordVo ToVo(FullInspRecordModel FullInspRecord)
        {
            return new FullInspRecordVo
            {
                Id = FullInspRecord.Id,
                FullInspectionNumber = FullInspRecord.FullInspectionNumber,
                WorkOrderNumber = FullInspRecord.WorkOrder.WorkOrderNumber,
                InspEquipSettingRecordDtos = FullInspRecord.InspEquipSettingRecords.Select(x => new InspEquipSettingRecordDto().ToVo(x)).ToList(),
                InspProdRecordDtos = FullInspRecord.InspProdRecords.Select(x => new InspProdRecordDto().ToVo(x)).ToList()
            };
        }
    }
}
