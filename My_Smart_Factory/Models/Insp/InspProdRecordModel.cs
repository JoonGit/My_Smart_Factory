using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models.Insp
{
    // 제품검사기록
    public class InspProdRecordModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual InspEquipModel? InspEquip { get; set; }      // 검사 장비
        public virtual ProdCtrlNoModel? ProdCtrlNo { get; set; }    // 관리번호
        public DateTime? InspectionDateTime { get; set; }           // 검사 일시
        public double? MeasuredValue { get; set; }                   // 측정값
        public double? Accuracy { get; set; }                       // 일치율
        public bool? IsPassed { get; set; }                         // 합격여부
    }
}
