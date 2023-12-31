using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    public class InspEquipRecordModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double? IES { get; set; }                        // Inspection Equipment Settings
        public double? Accuracy { get; set; }                   // 일치율
    }
}
