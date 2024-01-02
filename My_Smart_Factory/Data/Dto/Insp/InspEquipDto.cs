using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Dto.Insp
{
    public class InspEquipDto
    {
        public int Id { get; set; }
        public string? InspEquipName { get; set; }       // 장비명
        public string? Unit { get; set; }               // 측정단위

        public InspEquipModel ToModel()
        {
            InspEquipModel model = new InspEquipModel();
            model.InspEquipName = InspEquipName;
            model.Unit = Unit;

            return model;
        }
    }
}
