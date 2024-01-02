using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Dto.ProcessStatus;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service
{
    public class InspEquipSettingRecordService : EntityBaseRepository<InspEquipSettingRecordModel>, IInspEquipSettingRecordService
    {
        public InspEquipSettingRecordService(MyDbContext context) : base(context)
        {
        }

        private InspEquipSettingRecordModel UpdateModel(InspEquipSettingRecordModel model, InspEquipSettingRecordDto requestDto, InspEquipModel InspEquip, InspSpecModel InspSpec)
        {
            model.InspEquip = InspEquip;
            model.InspSpec = InspSpec;
            model.InspectionDateTime = requestDto.InspectionDateTime;
            model.IES = requestDto.IES;
            model.Accuracy = requestDto.Accuracy;

            return model;
        }

        InspEquipSettingRecordModel IInspEquipSettingRecordService.UpdateModel(InspEquipSettingRecordModel model,
            InspEquipSettingRecordDto requestDto,
            InspEquipModel InspEquip,
            InspSpecModel InspSpec)
        {
            return UpdateModel(model, requestDto, InspEquip, InspSpec);
        }
    }
}
