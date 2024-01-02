using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Dto.Insp
{
    public class InspEquipSettingRecordDto
    {
        public int Id { get; set; }
        public string? InspEquipName { get; set; }                   // 검사에 사용한 장비명
        public string? InspSpecName { get; set; }                        // 검사기준명
        public DateTime? InspectionDateTime { get; set; }           // 검사 일시
        public double? IES { get; set; }                            // Inspection Equipment Settings
        public double? Accuracy { get; set; }                       // 일치율

        //public virtual InspEquipModel? InspEquip { get; set; }      // 검사에 사용한 장비
        //public virtual InspSpecModel? InspSpec { get; set; }        // 검사에 기준이 된 스펙

        public InspEquipSettingRecordModel ToModel(InspEquipModel InspEquip, InspSpecModel InspSpec)
        {
            InspEquipSettingRecordModel model = new InspEquipSettingRecordModel();
            model.InspEquip = InspEquip;
            model.InspSpec = InspSpec;
            model.InspectionDateTime = InspectionDateTime;
            model.IES = IES;
            model.Accuracy = Accuracy;
            return model;
        }
    }
}
