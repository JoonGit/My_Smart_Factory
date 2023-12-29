namespace My_Smart_Factory.Data.Vo.Pps
{
    public class PpsVo
    {
        public string? Specification { get; set; }          // 스펙
        public string? LotNumber { get; set; }              // 로트번호
        public int Quantity { get; set; }                   // 수량
        public int DefectiveQuantity { get; set; }          // 불량수량
        public int DefectRate { get; set; }                 // 불량률
    }
}
