using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service
{
    public class WorkOrderService : EntityBaseRepository<WorkOrderModel>, IWorkOrderService
    {
        public WorkOrderService(MyDbContext context) : base(context)
        {
        }
        private WorkOrderModel UpdateModel(WorkOrderModel model, WorkOrderDto requestDto, ProdInfoModel ProdInfo, UserIdentity WorkOrderIssuer, FullInspRecordModel? FullInspection, string QrUrl)
        {
            model.WorkOrderNo = requestDto.WorkOrderNo;
            model.WorkOrderDate = requestDto.WorkOrderDate;
            model.ProdInfo = ProdInfo;
            model.WorkOrderIssuer = WorkOrderIssuer;
            model.WorkQuantity = requestDto.WorkQuantity;
            model.Status = requestDto.Status;
            model.CurrentWorkQuantity = requestDto.CurrentWorkQuantity;
            model.QRURL = QrUrl;
            model.FullInspection = FullInspection;
            return model;
        }
        
        private WorkOrderDto ModelToDto(WorkOrderModel model)
        {
            return new WorkOrderDto
            {
                Id = model.Id,
                WorkOrderNo = model.WorkOrderNo,
                WorkOrderDate = model.WorkOrderDate,
                ProdName = model.ProdInfo.ProdName,
                WorkOrderIssuer = model.WorkOrderIssuer.UserName,
                WorkQuantity = model.WorkQuantity,
                Status = model.Status,
                CurrentWorkQuantity = model.CurrentWorkQuantity,
                FullInspNo = model.FullInspection.FullInspNo
            };
        }

        private WorkOrderVo WorkOrderVo(WorkOrderModel model)
        {
            return new WorkOrderVo
            {
                Id = model.Id,
                WorkOrderNo = model.WorkOrderNo,
                WorkOrderDate = model.WorkOrderDate,
                ProdName = model.ProdInfo.ProdName,
                WorkOrderIssuer = model.WorkOrderIssuer.UserName,
                WorkQuantity = model.WorkQuantity,
                WorkStatus = model.Status,
                CurrentWorkQuantity = model.CurrentWorkQuantity,
                QRURL = model.QRURL,
                FullInspeNoId = model.FullInspection.Id,
                FullInspNo = model.FullInspection.FullInspNo
            };
        }

        WorkOrderModel IWorkOrderService.UpdateModel(WorkOrderModel model, WorkOrderDto requestDto, ProdInfoModel ProdInfo, UserIdentity WorkOrderIssuer, FullInspRecordModel? FullInspection, string QrUrl)
        {
            return UpdateModel(model, requestDto, ProdInfo, WorkOrderIssuer, FullInspection, QrUrl);
        }

        WorkOrderDto IWorkOrderService.ModelToDto(WorkOrderModel model)
        {
            return ModelToDto(model);
        }

        public WorkOrderVo ModelToVo(WorkOrderModel model)
        {
            return WorkOrderVo(model);
        }
    }
}
