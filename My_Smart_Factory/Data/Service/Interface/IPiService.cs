using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Pi;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IPiService : IEntityBaseRepository<PiModel>
    {
        Task<List<PiVo>?> ReadAll(List<PiModel> piModels);
        Task<PiModel> Create(PiDto requestDto);
        Task<PiModel?> Update(PiModel oldModel, PiDto UpdateModel);
    }
}
