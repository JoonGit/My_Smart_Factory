using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Dto
{
    public class WorkOrderVo
    {
        public int Id { get; set; }
        public string? WorkOrderNumber { get; set; }                        // 작업 지시 번호
        public DateTime? WorkOrderDate { get; set; }                        // 작업 지시 일자
        public virtual string? ProdName { get; set; }                       // 작업 물건
        public virtual string WorkOrderIssuer { get; set; }                 // 작업지시자
        public int? WorkQuantity { get; set; }                              // 작업 수량
        public string? WorkStatus { get; set; }                             // 작업 상태
        public int? CurrentWorkQuantity { get; set; }                       // 현재 작업 수량
        public string? QRURL { get; set; }                                  // qr 코드 url
        public virtual string? FullInspectionNumber { get; set; }           // 전수검사

        public WorkOrderModel ToModel(ProdInfoModel prodInfo, UserIdentity WorkOrderIssuer, FullInspRecordModel FullInspection)
        {
            WorkOrderModel model = new WorkOrderModel();
            model.ProdInfo = prodInfo;
            model.WorkOrderNumber = WorkOrderNumber;
            model.WorkOrderDate = WorkOrderDate;
            model.WorkOrderIssuer = WorkOrderIssuer;
            model.WorkQuantity = WorkQuantity;
            model.WorkStatus = WorkStatus;
            model.CurrentWorkQuantity = CurrentWorkQuantity;
            model.QRURL = QRURL;
            model.FullInspection = FullInspection;

            return model;

        }
        public WorkOrderVo ToVo(WorkOrderModel workOrder)
        {
            return new WorkOrderVo
            {
                Id = workOrder.Id,
                WorkOrderNumber = workOrder.WorkOrderNumber,
                WorkOrderDate = workOrder.WorkOrderDate,
                ProdName = workOrder.ProdInfo.ProdName,
                WorkOrderIssuer = workOrder.WorkOrderIssuer.UserName,
                WorkQuantity = workOrder.WorkQuantity,
                WorkStatus = workOrder.WorkStatus,
                CurrentWorkQuantity = workOrder.CurrentWorkQuantity,
                QRURL = workOrder.QRURL,
                FullInspectionNumber = workOrder.FullInspection.FullInspectionNumber
            };
        }
    }
}
