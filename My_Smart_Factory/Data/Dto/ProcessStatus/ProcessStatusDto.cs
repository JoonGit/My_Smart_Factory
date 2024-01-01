using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Dto.ProcessStatus
{
    public class ProcessStatusDto
    {
        public int id { get; set; }
        public string? prodName { get; set; }               // 제품명
        public DateTime? date { get; set; }                 // 작업 날짜
        public int quantity { get; set; }                   // 수량
        public string? operatorName { get; set; }           // 작업자
        public int defectiveQuantity { get; set; }          // 불량수량
    }
}
