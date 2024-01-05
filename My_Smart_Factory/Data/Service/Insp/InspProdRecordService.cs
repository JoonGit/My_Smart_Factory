using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models;
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
            FullInspRecordModel FullInspRecord,
            decimal Accuracy,
            bool IsPassed)
        {
            model.InspSpec = InspEquip;
            model.ProdCtrlNo = ProdCtrlNo;
            model.InspectionDateTime = requestDto.InspectionDateTime;
            model.MeasuredValue = requestDto.MeasuredValue;
            model.Accuracy = Accuracy;
            model.IsPassed = IsPassed;
            model.FullInspRecord = FullInspRecord;
            return model;
        }

        private InspProdRecordVo ModelToVo(InspProdRecordModel model)
        {
            return new InspProdRecordVo
            {
                Id = model.Id,
                InspEquipName = model.InspSpec.InspEquip.InspEquipName,
                ProdCtrlNo = model.ProdCtrlNo.ProdCtrlNo,
                InspectionDateTime = model.InspectionDateTime,
                MeasuredValue = model.MeasuredValue,
                SpecIES = model.InspSpec.ProdInfo.ProdWeight,
                ETR = model.InspSpec.ETR,
                ProdName = model.InspSpec.ProdInfo.ProdName,
                Unit = model.InspSpec.InspEquip.Unit,
                Accuracy = model.Accuracy,
                IsPassed = model.IsPassed,
                FullInspNo = model.FullInspRecord.FullInspNo

            };
        }
        private InspProdRecordDto ModelToDto(InspProdRecordModel model)
        {
            return new InspProdRecordDto
            {
                Id = model.Id,
                FullInspNo = model.FullInspRecord.FullInspNo,
                InspSpecName = model.InspSpec.InspSpecName,
                ProdCtrlNo = model.ProdCtrlNo.ProdCtrlNo,
                InspectionDateTime = model.InspectionDateTime,
                MeasuredValue = model.MeasuredValue
            };
        }
        InspProdRecordModel IInspProdRecordService.UpdateModel(InspProdRecordModel model,
            InspProdRecordDto requestDto,
            InspSpecModel InspSpec,
            ProdCtrlNoModel ProdCtrlNo,
            FullInspRecordModel FullInspRecord,
            decimal Accuracy,
            bool IsPassed)
        {
            return UpdateModel(model, requestDto, InspSpec, ProdCtrlNo, FullInspRecord, Accuracy,  IsPassed);
        }

        InspProdRecordVo IInspProdRecordService.ModelToVo(InspProdRecordModel model)
        {
            return ModelToVo(model);
        }

        InspProdRecordDto IInspProdRecordService.ModelToDto(InspProdRecordModel model)
        {
            return ModelToDto(model);
        }
    }
}
