using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Prod;
using My_Smart_Factory.Data.Vo.Prod;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Interface.Prod
{
    public interface IProdInfoService : IEntityBaseRepository<ProdInfoModel>
    {
        Task<IEnumerable<ProdInfoVo>?> ToVo(IEnumerable<ProdInfoModel> piModels);
        Task<ProdInfoModel> Create(ProdInfoDto requestDto);
        Task<ProdInfoModel?> Update(ProdInfoModel oldModel, ProdInfoDto UpdateModel);
    }
}
