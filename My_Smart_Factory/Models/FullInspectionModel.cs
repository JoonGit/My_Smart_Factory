using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Models.Insp;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    // 전수검사
    public class FullInspectionModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FullInspectionNumber { get; set; }                                   // 전수검사번호
        public virtual WorkOrderModel? WorkOrder { get; set; }                              // 작업지시
        public virtual List<InspEquipSettingRecordModel>? InspEquipRecord { get; set; }     // 검사장비 세팅 기록
        public virtual List<InspProdRecordModel> ProdInspectionRecords { get; set; }        // 제품 검사 기록   
    }
}
