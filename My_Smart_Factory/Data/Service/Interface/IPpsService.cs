using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Pps;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Data.Vo.Pps;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IPpsService : IEntityBaseRepository<ProcessStatusModel>
    {
        Task<List<PpsVo>?> ReadAll(List<ProcessStatusModel> piModels);
        Task<ProcessStatusModel> Create(PpsDto requestDto, ProdInfoModel piModel, UserIdentity Operator);
        Task<ProcessStatusModel?> Update(ProcessStatusModel oldModel, ProdInfoModel piModel, UserIdentity Operator, PpsDto UpdateModel);
        Task<List<PpsUpdateDateAllVo>?> UpdateDateAll(List<ProcessStatusModel> PpsModels);
    }
}
