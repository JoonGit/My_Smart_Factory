namespace My_Smart_Factory.Data.Vo.Pps
{
    public class PpsVo
    {

        public int id { get; set; }
        public string? specification { get; set; }          // 스펙
        public string? lotNumber { get; set; }              // 로트번호
        public int quantity { get; set; }                   // 수량
        public int defectiveQuantity { get; set; }          // 불량수량
        public double defectRate { get; set; }                 // 불량률
    }
}
