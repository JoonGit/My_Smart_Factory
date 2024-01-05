using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Models;
using My_Smart_Factory.Data.Enums;

namespace My_Smart_Factory.Data.Vo
{
    public class WorkOrderVo
    {
        public int Id { get; set; }
        public string? WorkOrderNo { get; set; }                    // 작업 지시 번호
        public DateTime? WorkOrderDate { get; set; }                // 작업 지시 일자
        public string? ProdName { get; set; }                       // 작업 물건
        public string WorkOrderIssuer { get; set; }                 // 작업지시자
        public int? WorkQuantity { get; set; }                      // 작업 수량
        public WorkOrderStatus? WorkStatus { get; set; }            // 작업 상태
        public int? CurrentWorkQuantity { get; set; }               // 현재 작업 수량
        public string? QRURL { get; set; }                          // qr 코드 url
        public int FullInspeNoId { get; set; }                      // 전수검사기록ID
        public string? FullInspNo { get; set; }                    // 전수검사기록
    }
}
