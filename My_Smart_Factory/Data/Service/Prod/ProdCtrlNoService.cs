using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Prod;
using My_Smart_Factory.Data.Service.Interface.Prod;
using My_Smart_Factory.Data.Vo.Prod;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Prod
{
    public class ProdCtrlNoService : EntityBaseRepository<ProdCtrlNoModel>, IProdCtrlNoService
    {
        public ProdCtrlNoService(MyDbContext context) : base(context)
        {
        }

        private ProdCtrlNoModel UpdateModel(ProdCtrlNoModel model, ProdCtrlNoDto requestDto, ProdInfoModel ProdInfo)
        {
            model.ProdInfo = ProdInfo;
            model.ProdCtrlNo = requestDto.ProdCtrlNo;
            model.ProdInfo = ProdInfo;
            return model;
        }

        private ProdCtrlNoDto ModelToDto(ProdCtrlNoModel model)
        {
            return new ProdCtrlNoDto
            {
                ProdCtrlNo = model.ProdCtrlNo,
                ProdName = model.ProdInfo.ProdName
            };
        }

        private ProdCtrlNoVo ModelToVo(ProdCtrlNoModel model)
        {
            return new ProdCtrlNoVo
            {
                Id = model.Id,
                ProdCtrlNo = model.ProdCtrlNo,
                ProdName = model.ProdInfo.ProdName
            };
        }

        ProdCtrlNoModel IProdCtrlNoService.UpdateModel(ProdCtrlNoModel model, ProdCtrlNoDto requestDto, ProdInfoModel ProdInfo)
        {
            return UpdateModel(model, requestDto, ProdInfo);
        }

        ProdCtrlNoVo IProdCtrlNoService.ModelToVo(ProdCtrlNoModel model)
        {
            return ModelToVo(model);
        }

        ProdCtrlNoDto IProdCtrlNoService.ModelToDto(ProdCtrlNoModel model)
        {
            return ModelToDto(model);
        }
    }
}
