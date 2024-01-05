using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo.FullInsp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Service
{
    public class FullInspRecordService : EntityBaseRepository<FullInspRecordModel>, IFullInspRecordService
    {
        public FullInspRecordService(MyDbContext context) : base(context)
        {
        }

        private FullInspRecordModel UpdateModel(FullInspRecordModel model,
            FullInspRecordDto requestDto,
            WorkOrderModel WorkOrder,
            List<InspEquipSettingRecordModel> InspEquipSettingRecords,
            List<InspProdRecordModel> InspProdRecords)
        {
            model.WorkOrder = WorkOrder;
            model.InspEquipSettingRecords = InspEquipSettingRecords;
            model.FullInspNo = requestDto.FullInspeNo;
            model.InspProdRecords = InspProdRecords;
            return model;
        }

        private FullInspRecordDto ModelToDto(FullInspRecordModel model)
        {
            return new FullInspRecordDto
            {
                Id = model.Id,
                FullInspeNo = model.FullInspNo,
                WorkOrderNo = model.WorkOrder.WorkOrderNo
            };
        }
        #region Vo
        private FullInspRecordVo ModelToVo(FullInspRecordModel model)
        {
            return new FullInspRecordVo
            {
                Id = model.Id,
                FullInspNo = model.FullInspNo,
                WorkOrderNo = model.WorkOrder.WorkOrderNo
            };
        }

        private List<FullInspEquipRecordVo> ModelToEquipVo(FullInspRecordModel model)
        {
            List<FullInspEquipRecordVo> fullInspEquipRecordVos = new List<FullInspEquipRecordVo>();
            foreach (InspEquipSettingRecordModel InspEquipSettingRecord in model.InspEquipSettingRecords)
            {
                fullInspEquipRecordVos.Add(new FullInspEquipRecordVo
                {
                    InspEquipName = InspEquipSettingRecord.InspEquip.InspEquipName,
                    ProdName = InspEquipSettingRecord.InspSpec.ProdInfo.ProdName,
                    InspectionDateTime = InspEquipSettingRecord.InspectionDateTime,
                    IES = InspEquipSettingRecord.IES,
                    SpecIES = InspEquipSettingRecord.InspSpec.ProdInfo.ProdWeight,
                    ETR = InspEquipSettingRecord.InspSpec.ETR,
                    Accuracy = InspEquipSettingRecord.Accuracy,
                });
            }
            return fullInspEquipRecordVos;
        }
        private List<FullInspProdRecordVo> ModelToProdVo(FullInspRecordModel model)
        {
            List<FullInspProdRecordVo> fullInspProdRecordVos = new List<FullInspProdRecordVo>();
            foreach (InspProdRecordModel InspProdRecord in model.InspProdRecords)
            {
                fullInspProdRecordVos.Add(new FullInspProdRecordVo
                {
                    ProdCtrlNo = InspProdRecord.ProdCtrlNo.ProdCtrlNo,
                    ProdName = InspProdRecord.InspSpec.ProdInfo.ProdName,
                    InspectionDateTime = InspProdRecord.InspectionDateTime,
                    MeasuredValue = InspProdRecord.MeasuredValue,
                    SpecIES = InspProdRecord.InspSpec.ProdInfo.ProdWeight,
                    Accuracy = InspProdRecord.Accuracy,
                    ETR = InspProdRecord.InspSpec.ETR,
                    IsPassed = InspProdRecord.IsPassed
                });
            }
            return fullInspProdRecordVos;
        }
        #endregion
        FullInspRecordModel IFullInspRecordService.UpdateModel(FullInspRecordModel model, FullInspRecordDto requestDto, WorkOrderModel WorkOrder, List<InspEquipSettingRecordModel> InspEquipSettingRecords, List<InspProdRecordModel> InspProdRecords)
        {
            return UpdateModel(model, requestDto, WorkOrder, InspEquipSettingRecords, InspProdRecords);
        }

        FullInspRecordDto IFullInspRecordService.ModelToDto(FullInspRecordModel model)
        {
            return ModelToDto(model);
        }
        List<FullInspProdRecordVo> IFullInspRecordService.ModelToProdVo(FullInspRecordModel model)
        {
            return ModelToProdVo(model);
        }

        List<FullInspEquipRecordVo> IFullInspRecordService.ModelToEquipVo(FullInspRecordModel model)
        {
            return ModelToEquipVo(model);
        }

        FullInspRecordVo IFullInspRecordService.ModelToVo(FullInspRecordModel model)
        {
            return ModelToVo(model);
        }
    }
}
