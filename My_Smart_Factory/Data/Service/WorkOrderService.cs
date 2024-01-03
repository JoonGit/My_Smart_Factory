﻿using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service
{
    public class WorkOrderService : EntityBaseRepository<WorkOrderModel>, IWorkOrderService
    {
        public WorkOrderService(MyDbContext context) : base(context)
        {
        }
        private WorkOrderModel UpdateModel(WorkOrderModel model, WorkOrderVo requestDto, ProdInfoModel ProdInfo, UserIdentity WorkOrderIssuer, FullInspRecordModel? FullInspection)
        {
            model.WorkOrderNumber = requestDto.WorkOrderNumber;
            model.WorkOrderDate = requestDto.WorkOrderDate;
            model.ProdInfo = ProdInfo;
            model.WorkOrderIssuer = WorkOrderIssuer;
            model.WorkQuantity = requestDto.WorkQuantity;
            model.WorkStatus = requestDto.WorkStatus;
            model.CurrentWorkQuantity = requestDto.CurrentWorkQuantity;
            model.QRURL = requestDto.QRURL;
            model.FullInspection = FullInspection;
            return model;
        }

        WorkOrderModel IWorkOrderService.UpdateModel(WorkOrderModel model, WorkOrderVo requestDto, ProdInfoModel ProdInfo, UserIdentity WorkOrderIssuer, FullInspRecordModel? FullInspection)
        {
            return UpdateModel(model, requestDto, ProdInfo, WorkOrderIssuer, FullInspection);
        }
    }
}
