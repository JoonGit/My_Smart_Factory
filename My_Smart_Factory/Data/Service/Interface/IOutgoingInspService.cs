using Microsoft.AspNetCore.Authentication;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Oqc;
using My_Smart_Factory.Data.Vo.Oqc;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IOutgoingInspService : IEntityBaseRepository<OutgoingInspModel>
    {

        Task<OutgoingInspModel?> Create(OutgoingInspDto requestDto, UserIdentity inspector, UserIdentity confirmor);
        Task<OutgoingInspModel?> CreateDefultModel(string controlnumber, UserIdentity inspector, UserIdentity confirmor);
        Task<OutgoingInspModel?> Update(OutgoingInspDto requestDto, OutgoingInspModel oqc, UserIdentity inspector, UserIdentity confirmor);
        OutgoingInspVo CreateOqcVo(OutgoingInspModel oqc);
        Task<List<OutgoingInspVo>?> Read(List<OutgoingInspModel> oqcList);

    }
}
