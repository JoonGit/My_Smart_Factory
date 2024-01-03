using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Insp
{
    public class InspSpecService : EntityBaseRepository<InspSpecModel>, IInspSpecService
    {
        public InspSpecService(MyDbContext context) : base(context)
        {
        }
        private InspSpecModel UpdateModel(InspSpecModel model, InspSpecDto requestDto, ProdInfoModel ProdInfo, InspEquipModel InspEquip)
        {
            model.InspSpecName = requestDto.InspSpecName;
            //model.IES = requestDto.IES;
            model.ETR = requestDto.ETR;
            model.InspEquip = InspEquip;
            model.ProdInfo = ProdInfo;

            return model;
        }

        InspSpecModel IInspSpecService.UpdateModel(InspSpecModel model, InspSpecDto requestDto, ProdInfoModel ProdInfo, InspEquipModel InspEquip)
        {
            return UpdateModel(model, requestDto, ProdInfo, InspEquip);
        }
    }
}
