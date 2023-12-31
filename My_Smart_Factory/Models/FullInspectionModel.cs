using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    // 전수검사
    public class FullInspectionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FullInspectionNumber { get; set; }           // 전수검사번호
        public virtual WorkOrderModel? WorkOrder { get; set; }      // 작업지시
        public DateTime? InspectionDateTime { get; set; }           // 검사 일시
        public virtual InspEquipRecordModel? InspEquipRecord { get; set; }  // 검사장비 기록
        public virtual List<ProdInspectionRecordModel> ProdInspectionRecords { get; set; }
    }
}
