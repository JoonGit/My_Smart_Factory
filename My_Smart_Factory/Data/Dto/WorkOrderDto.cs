using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Models;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Data.Enums;

namespace My_Smart_Factory.Data.Dto
{
    public class WorkOrderDto
    {
        public int Id { get; set; }
        public string? WorkOrderNo { get; set; }                    // 작업 지시 번호
        public DateTime? WorkOrderDate { get; set; }                // 작업 지시 일자
        public string? ProdName { get; set; }                       // 작업 물건
        public string WorkOrderIssuer { get; set; }                 // 작업지시자
        public int? WorkQuantity { get; set; }                      // 작업 수량
        public WorkOrderStatus? Status { get; set; }                // 작업 상태
        public int? CurrentWorkQuantity { get; set; }               // 현재 작업 수량
        public string? FullInspNo { get; set; }                     // 전수검사

        public WorkOrderModel ToModel(ProdInfoModel prodInfo, UserIdentity WorkOrderIssuer, string QrURL)
        {
            WorkOrderModel model = new WorkOrderModel();
            model.ProdInfo = prodInfo;
            model.WorkOrderNo = WorkOrderNo;
            model.WorkOrderDate = WorkOrderDate;
            model.WorkOrderIssuer = WorkOrderIssuer;
            model.WorkQuantity = WorkQuantity;
            model.QRURL = QrURL;

            return model;

        }
        public WorkOrderVo ToVo(WorkOrderModel workOrder)
        {
            return new WorkOrderVo
            {
                Id = workOrder.Id,
                WorkOrderNo = workOrder.WorkOrderNo,
                WorkOrderDate = workOrder.WorkOrderDate,
                ProdName = workOrder.ProdInfo.ProdName,
                WorkOrderIssuer = workOrder.WorkOrderIssuer.UserName,
                WorkQuantity = workOrder.WorkQuantity,
                WorkStatus = workOrder.Status,
                CurrentWorkQuantity = workOrder.CurrentWorkQuantity,
                QRURL = workOrder.QRURL,
                FullInspeNoId = workOrder.FullInspection.Id,
                FullInspNo = workOrder.FullInspection.FullInspNo
            };
        }
    }
}
