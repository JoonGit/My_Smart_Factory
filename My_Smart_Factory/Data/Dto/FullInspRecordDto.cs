using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Dto
{
    public class FullInspRecordDto
    {
        public int Id { get; set; }
        public string? FullInspectionNumber { get; set; }                                   // 전수검사번호
        public string? WorkOrderNumber { get; set; }            // 작업 지시 번호


        public virtual List<InspEquipSettingRecordModel>? InspEquipRecord { get; set; }     // 검사장비 세팅 기록
        public virtual List<InspProdRecordModel> ProdInspectionRecords { get; set; }        // 제품 검사 기록   
        //public virtual WorkOrderModel? WorkOrder { get; set; }                              // 작업지시
    }
}
