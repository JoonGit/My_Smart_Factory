using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Vo.FullInsp;

namespace My_Smart_Factory.Data.Dto
{
    public class FullInspRecordDto
    {
        public int Id { get; set; }
        public string? FullInspeNo { get; set; }                                               // 전수검사번호
        public string? WorkOrderNo { get; set; }                                                    // 작업 지시 번호

        public virtual List<InspEquipSettingRecordDto>? InspEquipSettingRecordDtos { get; set; }        // 검사장비 세팅 기록
        public virtual List<InspProdRecordDto> InspProdRecordDtos { get; set; }                         // 제품 검사 기록   

        public FullInspRecordModel ToModel(WorkOrderModel WorkOrder
            )
        {
            FullInspRecordModel model = new FullInspRecordModel();
            model.FullInspNo = FullInspeNo;
            if (WorkOrder == null)
            {
                WorkOrderModel newWorkOrder = new WorkOrderModel();
                model.WorkOrder = newWorkOrder;

                return model;
            }
            else
            {
                model.WorkOrder = WorkOrder;

                return model;
            }
            
        }
        public FullInspRecordVo ToVo(FullInspRecordModel FullInspRecord)
        {
            return new FullInspRecordVo
            {
                Id = FullInspRecord.Id,
                FullInspNo = FullInspRecord.FullInspNo,
                WorkOrderNo = FullInspRecord.WorkOrder.WorkOrderNo,
            };
        }
    }
}
