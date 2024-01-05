namespace My_Smart_Factory.Data.Vo.FullInsp
{
    public class FullInspEquipRecordVo
    {
        public int Id { get; set; }
        public string? InspEquipName { get; set; }                   // 검사에 사용한 장비명
        public string? ProdName { get; set; }                        // 검사한 제품 이름
        public DateTime? InspectionDateTime { get; set; }            // 검사 일시
        public decimal? IES { get; set; }                            // 장비 세팅값 Inspection Equipment Settings
        public decimal? SpecIES { get; set; }                        // 기준 값
        public decimal? ETR { get; set; }                            // 에러 허용 값
        public decimal? Accuracy { get; set; }                       // 일치율
    }
}
