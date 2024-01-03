using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Vo.Insp
{
    public class InspEquipVo
    {
        public int Id { get; set; }
        public string? InspEquipName { get; set; }       // 장비명
        public string? Unit { get; set; }               // 측정단위

    }
}
