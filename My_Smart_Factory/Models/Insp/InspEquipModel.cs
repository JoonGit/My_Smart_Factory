using My_Smart_Factory.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models.Insp
{
    // 검사장비
    public class InspEquipModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? InspEquipName { get; set; }       // 장비명
        public string? Unit { get; set; }       // 측정단위

    }
}
