using Microsoft.AspNetCore.Authentication;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Oqc;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service.Interface
{
    public interface IOqcService : IEntityBaseRepository<OqcModel>
    {

        Task<OqcModel?> Create(OqcDto requestDto, UserIdentity inspector, UserIdentity confirmor);
        Task<OqcModel?> CreateDefultModel(string controlnumber, UserIdentity inspector, UserIdentity confirmor);
        Task<OqcModel?> Update(OqcDto requestDto, OqcModel oqc, UserIdentity inspector, UserIdentity confirmor);
        OqcVo CreateOqcVo(OqcModel oqc);
        Task<List<OqcVo>?> Read(List<OqcModel> oqcList, UserIdentity inspector, UserIdentity confirmor);

    }
}
