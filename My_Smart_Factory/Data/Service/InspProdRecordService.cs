using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service
{
    public class InspProdRecordService : EntityBaseRepository<InspProdRecordModel>, IInspProdRecordService
    {
        public InspProdRecordService(MyDbContext context) : base(context)
        {
        }
        private InspProdRecordModel UpdateModel(InspProdRecordModel model,
            InspProdRecordDto requestDto,
            InspEquipModel InspEquip,
            ProdCtrlNoModel ProdCtrlNo)
        {
            model.InspEquip = InspEquip;
            model.ProdCtrlNo = ProdCtrlNo;
            model.InspectionDateTime = requestDto.InspectionDateTime;
            model.MeasuredValue = requestDto.MeasuredValue;
            model.Accuracy = requestDto.Accuracy;
            model.IsPassed = requestDto.IsPassed;

            return model;
        }

        InspProdRecordModel IInspProdRecordService.UpdateModel(InspProdRecordModel model, InspProdRecordDto requestDto, InspEquipModel InspEquip, ProdCtrlNoModel ProdCtrlNo)
        {
            return UpdateModel(model, requestDto, InspEquip, ProdCtrlNo);
        }
    }
}
