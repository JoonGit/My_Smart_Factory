using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Prod;
using My_Smart_Factory.Data.Vo.Prod;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Interface.Prod
{
    public interface IProdCtrlNoService : IEntityBaseRepository<ProdCtrlNoModel>
    {
        ProdCtrlNoModel UpdateModel(ProdCtrlNoModel model, ProdCtrlNoDto requestDto, ProdInfoModel ProdInfo);

        ProdCtrlNoVo ModelToVo(ProdCtrlNoModel model);
        ProdCtrlNoDto ModelToDto(ProdCtrlNoModel model);
    }
}
