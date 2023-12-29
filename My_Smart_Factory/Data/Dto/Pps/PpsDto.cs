using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Dto.Pps
{
    public class PpsDto
    {
        public virtual String ControlNumber { get; set; }  // 관리번호
        public DateTime? Date { get; set; }                 // 작업 날짜
        public int Quantity { get; set; }                   // 수량
        public string? OperatorName { get; set; }           // 작업자
        public int DefectiveQuantity { get; set; }          // 불량수량
    }
}
