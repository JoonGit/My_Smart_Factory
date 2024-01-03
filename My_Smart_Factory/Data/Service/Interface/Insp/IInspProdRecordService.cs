using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Interface.Insp
{
    public interface IInspProdRecordService : IEntityBaseRepository<InspProdRecordModel>
    {
        InspProdRecordModel UpdateModel(InspProdRecordModel model,
            InspProdRecordDto requestDto,
            InspSpecModel InspEquip,
            ProdCtrlNoModel ProdCtrlNo,
            decimal Accuracy,
            bool IsPassed);
    }
}
