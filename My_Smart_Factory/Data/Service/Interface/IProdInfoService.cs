using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Pi;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IProdInfoService : IEntityBaseRepository<ProdInfoModel>
    {
        Task<List<ProdInfoVo>?> ReadAll(List<ProdInfoModel> piModels);
        Task<ProdInfoModel> Create(ProdInfoDto requestDto);
        Task<ProdInfoModel?> Update(ProdInfoModel oldModel, ProdInfoDto UpdateModel);
    }
}
