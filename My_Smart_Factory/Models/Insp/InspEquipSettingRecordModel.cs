using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models.Insp
{
    // 검사장비 세팅 기록
    public class InspEquipSettingRecordModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual InspEquipModel? InspEquip { get; set; }      // 검사에 사용한 장비
        public virtual InspSpecModel? InspSpec { get; set; }        // 검사에 기준이 된 스펙
        public DateTime? InspectionDateTime { get; set; }           // 검사 일시
        public double? IES { get; set; }                        // Inspection Equipment Settings
        public double? Accuracy { get; set; }                   // 일치율
    }
}
