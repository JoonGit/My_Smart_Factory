using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    public class WorkOrderModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }                             
        public string? WorkOrderNumber { get; set; }            // 작업 지시 번호
        public DateTime? WorkOrderDate { get; set; }            // 작업 지시 일자
        public virtual SpecModel? Spec { get; set; }            // 스펙
        public virtual UserIdentity UserIdentity { get; set; }  // 작업자
        public int? WorkQuantity { get; set; }                  // 작업 수량
        public string? WorkStatus { get; set; }                 // 작업 상태
        public int? CurrentWorkQuantity { get; set; }           // 현재 작업 수량
        public string? QRURL { get; set; }                      // qr 코드 url
    }
}
