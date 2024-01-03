using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Prod;
using My_Smart_Factory.Data.Service.Interface.Prod;
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

        ProdCtrlNoModel IProdCtrlNoService.UpdateModel(ProdCtrlNoModel model, ProdCtrlNoDto requestDto, ProdInfoModel ProdInfo)
        {
            return UpdateModel(model, requestDto, ProdInfo);
        }
    }
}
