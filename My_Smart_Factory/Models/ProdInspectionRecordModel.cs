using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    public class ProdInspectionRecordModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual WorkOrderModel? WorkOrder { get; set; }      // 작업지시
        public virtual ProdCtrlNoModel? ProdCtrlNo { get; set; }    // 관리번호
        public double? Accuracy { get; set; }                       // 일치율
        public bool? IsPassed { get; set; }                         // 합격여부

    }
}
