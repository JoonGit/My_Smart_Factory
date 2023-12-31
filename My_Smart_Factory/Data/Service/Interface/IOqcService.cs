using Microsoft.AspNetCore.Authentication;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Oqc;
using My_Smart_Factory.Data.Vo.Oqc;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IOqcService : IEntityBaseRepository<OutgoingInspModel>
    {

        Task<OutgoingInspModel?> Create(OqcDto requestDto, UserIdentity inspector, UserIdentity confirmor);
        Task<OutgoingInspModel?> CreateDefultModel(string controlnumber, UserIdentity inspector, UserIdentity confirmor);
        Task<OutgoingInspModel?> Update(OqcDto requestDto, OutgoingInspModel oqc, UserIdentity inspector, UserIdentity confirmor);
        OqcVo CreateOqcVo(OutgoingInspModel oqc);
        Task<List<OqcVo>?> Read(List<OutgoingInspModel> oqcList);

    }
}
