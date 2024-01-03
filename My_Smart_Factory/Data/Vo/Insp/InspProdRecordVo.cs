using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Data.Vo.Insp
{
    public class InspProdRecordVo
    {
        public int? Id { get; set; }
        public string? InspEquipName { get; set; }                      // 장비명
        public string? ProdCtrlNo { get; set; }                         // 관리번호
        public string? ProdName { get; set; }                           // 제품 이름
        public DateTime? InspectionDateTime { get; set; }               // 검사 일시
        public decimal? MeasuredValue { get; set; }                      // 측정값
        public decimal? Accuracy { get; set; }                           // 일치율
        public string Unit { get; set; }                                // 단위
        public bool? IsPassed { get; set; }

    }
}
