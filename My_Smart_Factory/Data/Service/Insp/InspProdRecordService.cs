using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Insp
{
    public class InspProdRecordService : EntityBaseRepository<InspProdRecordModel>, IInspProdRecordService
    {
        public InspProdRecordService(MyDbContext context) : base(context)
        {
        }
        private InspProdRecordModel UpdateModel(InspProdRecordModel model,
            InspProdRecordDto requestDto,
            InspSpecModel InspEquip,
            ProdCtrlNoModel ProdCtrlNo,
            decimal Accuracy,
            bool IsPassed)
        {
            model.InspSpecModel = InspEquip;
            model.ProdCtrlNo = ProdCtrlNo;
            model.InspectionDateTime = requestDto.InspectionDateTime;
            model.MeasuredValue = requestDto.MeasuredValue;
            model.Accuracy = Accuracy;
            model.IsPassed = IsPassed;
            return model;
        }

        InspProdRecordModel IInspProdRecordService.UpdateModel(InspProdRecordModel model,
            InspProdRecordDto requestDto,
            InspSpecModel InspSpec,
            ProdCtrlNoModel ProdCtrlNo,
            decimal Accuracy,
            bool IsPassed)
        {
            return UpdateModel(model, requestDto, InspSpec, ProdCtrlNo, Accuracy, IsPassed);
        }
    }
}
