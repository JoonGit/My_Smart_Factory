using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Dto.ProcessStatus;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Insp
{
    public class InspEquipSettingRecordService : EntityBaseRepository<InspEquipSettingRecordModel>, IInspEquipSettingRecordService
    {
        public InspEquipSettingRecordService(MyDbContext context) : base(context)
        {
        }

        private InspEquipSettingRecordModel UpdateModel(InspEquipSettingRecordModel model, InspEquipSettingRecordDto requestDto, InspEquipModel InspEquip, InspSpecModel InspSpec, FullInspRecordModel FullInspRecord, decimal Accuracy)
        {
            model.InspEquip = InspEquip;
            model.InspSpec = InspSpec;
            model.InspectionDateTime = requestDto.InspectionDateTime;
            model.FullInspRecord = FullInspRecord;
            model.IES = requestDto.IES;
            model.Accuracy = Accuracy;

            return model;
        }
        private InspEquipSettingRecordDto ModelToDto(InspEquipSettingRecordModel model)
        {
            return new InspEquipSettingRecordDto
            {
                Id = model.Id,
                InspEquipName = model.InspEquip.InspEquipName,
                InspSpecName = model.InspSpec.InspSpecName,
                InspectionDateTime = model.InspectionDateTime,
                FullInspNo = model.FullInspRecord.FullInspNo,
                IES = model.IES,
            };
        }

        private InspEquipSettingRecordVo ModelToVo(InspEquipSettingRecordModel model)
        {
            return new InspEquipSettingRecordVo
            {
                Id = model.Id,
                InspEquipName = model.InspEquip.InspEquipName,
                InspSpecName = model.InspSpec.InspSpecName,
                InspectionDateTime = model.InspectionDateTime,
                IES = model.IES,
                SpecIES = model.InspSpec.ProdInfo.ProdWeight,
                ETR = model.InspSpec.ETR,
                ProdName = model.InspSpec.ProdInfo.ProdName,
                Unit = model.InspEquip.Unit,
                FullInspNo = model.FullInspRecord.FullInspNo,
                Accuracy = model.Accuracy
            };
        }

        InspEquipSettingRecordModel IInspEquipSettingRecordService.UpdateModel(InspEquipSettingRecordModel model,
            InspEquipSettingRecordDto requestDto,
            InspEquipModel InspEquip,
            InspSpecModel InspSpec,
            FullInspRecordModel FullInspRecord,
            decimal Accuracy)
        {
            return UpdateModel(model, requestDto, InspEquip, InspSpec, FullInspRecord, Accuracy);
        }

        InspEquipSettingRecordVo IInspEquipSettingRecordService.ModelToVo(InspEquipSettingRecordModel model)
        {
            return ModelToVo(model);
        }

        InspEquipSettingRecordDto IInspEquipSettingRecordService.ModelToDto(InspEquipSettingRecordModel model)
        {
            return ModelToDto(model);
        }
    }
}
