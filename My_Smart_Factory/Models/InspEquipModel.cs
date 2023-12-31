using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    // InspectionEquipment
    // 검사장비
    public class InspEquipModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }       // 장비명
        public string? Unit { get; set; }       // 측정단위

    }
}
