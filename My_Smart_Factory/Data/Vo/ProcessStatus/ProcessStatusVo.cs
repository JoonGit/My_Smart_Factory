namespace My_Smart_Factory.Data.Vo.ProcessStatus
{
    public class ProcessStatusVo
    {

        public int id { get; set; }
        public string? prodName { get; set; }               // 제품명
        public string? prodCode { get; set; }               // 로트번호
        public string? prodWeight { get; set; }             // 로트번호
        public int quantity { get; set; }                   // 수량
        public int defectiveQuantity { get; set; }          // 불량수량
        public double defectRate { get; set; }              // 불량률
    }
}
