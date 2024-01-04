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
        public DateTime? InspectionDateTime { get; set; }           // 검사 일시
        public decimal? MeasuredValue { get; set; }                   // 측정값
        public decimal? Accuracy { get; set; }                       // 일치율
        public bool? IsPassed { get; set; }                         // 합격여부
        public virtual FullInspRecordModel? FullInspRecord { get; set; } // 전체 검사기록
        public virtual InspSpecModel? InspSpec { get; set; }       // 검사 스펙
        public virtual ProdCtrlNoModel? ProdCtrlNo { get; set; }    // 관리번호
    }
}
