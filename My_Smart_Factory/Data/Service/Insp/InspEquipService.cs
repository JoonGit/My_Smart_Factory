using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Dto.ProcessStatus;
using My_Smart_Factory.Data.Service.Interface.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Service.Insp
{
    public class InspEquipService : EntityBaseRepository<InspEquipModel>, IInspEquipService
    {
        public InspEquipService(MyDbContext context) : base(context)
        {
        }

        private InspEquipModel UpdateModel(InspEquipModel model, InspEquipDto requestDto)
        {
            model.InspEquipName = requestDto.InspEquipName;
            model.Unit = requestDto.Unit;
            return model;
        }

        InspEquipModel IInspEquipService.UpdateModel(InspEquipModel model, InspEquipDto requestDto)
        {
            return UpdateModel(model, requestDto);
        }
    }
}
