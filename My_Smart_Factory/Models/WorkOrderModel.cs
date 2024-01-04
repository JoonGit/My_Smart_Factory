using System.ComponentModel.DataAnnotations.Schema;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Models
{
    // 작업지시
    public class WorkOrderModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }                             
        public string? WorkOrderNo { get; set; }                            // 작업 지시 번호
        public DateTime? WorkOrderDate { get; set; }                        // 작업 지시 일자
        public int? WorkQuantity { get; set; }                              // 작업 수량
        public string? WorkOrderStatus { get; set; }                             // 작업 지시 상태
        public int? CurrentWorkQuantity { get; set; }                       // 현재 작업 수량
        public string? QRURL { get; set; }                                  // qr 코드 url
        public virtual FullInspRecordModel? FullInspection { get; set; }    // 전수검사
        public virtual ProdInfoModel? ProdInfo { get; set; }                // 작업 물건
        public virtual UserIdentity WorkOrderIssuer { get; set; }           // 작업지시자


    }
}
