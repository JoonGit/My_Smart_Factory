namespace My_Smart_Factory.Data.Vo.FullInsp
{
    public class FullInspProdRecordVo
    {
        public int Id { get; set; }
        public string? ProdCtrlNo { get; set; }                         // 관리번호
        public string? ProdName { get; set; }                           // 제품 이름
        public DateTime? InspectionDateTime { get; set; }               // 검사 일시
        public decimal? MeasuredValue { get; set; }                     // 측정값
        public decimal? SpecIES { get; set; }                           // 기준값
        public decimal? Accuracy { get; set; }                          // 일치율
        public decimal? ETR { get; set; }                               // 에러 범위
        public bool? IsPassed { get; set; }
    }
}
