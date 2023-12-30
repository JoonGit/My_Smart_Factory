using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Pps;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Data.Vo.Pps;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IPpsService : IEntityBaseRepository<PpsModel>
    {
        Task<List<PpsVo>?> ReadAll(List<PpsModel> piModels);
        Task<PpsModel> Create(PpsDto requestDto, PiModel piModel, UserIdentity Operator);
        Task<PpsModel?> Update(PpsModel oldModel, PiModel piModel, UserIdentity Operator, PpsDto UpdateModel);
        Task<List<PpsUpdateDateAllVo>?> UpdateDateAll(List<PpsModel> PpsModels);
    }
}
