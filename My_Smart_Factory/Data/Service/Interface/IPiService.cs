using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Pi;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IPiService : IEntityBaseRepository<ProdInfoModel>
    {
        Task<List<PiVo>?> ReadAll(List<ProdInfoModel> piModels);
        Task<ProdInfoModel> Create(PiDto requestDto);
        Task<ProdInfoModel?> Update(ProdInfoModel oldModel, PiDto UpdateModel);
    }
}
