using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Models.Insp;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    // 전수검사
    public class FullInspRecordModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FullInspNo { get; set; }                                                     // 전수검사번호
        public virtual WorkOrderModel? WorkOrder { get; set; } = null;                                   // 작업지시
        public virtual List<InspEquipSettingRecordModel>? InspEquipSettingRecords { get; set; }     // 검사장비 세팅 기록
            = new List<InspEquipSettingRecordModel>();  
        public virtual List<InspProdRecordModel>? InspProdRecords { get; set; }                     // 제품 검사 기록   
            = new List<InspProdRecordModel>();  
    }
}
