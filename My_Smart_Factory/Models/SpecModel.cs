using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    public class SpecModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }       // 장비명
        public virtual InspEquipModel? InspEquip { get; set; }       // 검사장비
        public double? IES { get; set; }                    // Inspection Equipment Settings
        public int? ETR { get; set; }       // 오류 허용범위 (Error Tolerance Range)
    }
}
