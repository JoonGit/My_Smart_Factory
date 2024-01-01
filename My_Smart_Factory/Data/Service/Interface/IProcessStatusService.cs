using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.ProcessStatus;
using My_Smart_Factory.Data.Vo.Pi;
using My_Smart_Factory.Data.Vo.ProcessStatus;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IProcessStatusService : IEntityBaseRepository<ProcessStatusModel>
    {
        Task<List<ProcessStatusVo>?> ReadAll(List<ProcessStatusModel> piModels);
        Task<ProcessStatusModel> Create(ProcessStatusDto requestDto, ProdInfoModel piModel, UserIdentity Operator);
        Task<ProcessStatusModel?> Update(ProcessStatusModel oldModel, ProdInfoModel piModel, UserIdentity Operator, ProcessStatusDto UpdateModel);
        Task<List<ProcessStatusUpdateDateAllVo>?> UpdateDateAll(List<ProcessStatusModel> PpsModels);
    }
}
