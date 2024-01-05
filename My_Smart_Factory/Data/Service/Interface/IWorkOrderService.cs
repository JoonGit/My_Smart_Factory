using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IWorkOrderService : IEntityBaseRepository<WorkOrderModel>
    {
        WorkOrderModel UpdateModel(WorkOrderModel model, WorkOrderDto requestDto, ProdInfoModel ProdInfo, UserIdentity WorkOrderIssuer, FullInspRecordModel? FullInspection, string QrUrl);
        
        WorkOrderDto ModelToDto(WorkOrderModel model);
        WorkOrderVo ModelToVo(WorkOrderModel model);
    }
}
