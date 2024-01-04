using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;

namespace My_Smart_Factory.Data.Dto.Insp
{
    public class InspEquipSettingRecordDto
    {
        public int Id { get; set; }
        public string FullInspNo { get; set; }                // 검사 관리 번호
        public string? InspEquipName { get; set; }                  // 검사에 사용한 장비명
        public string? InspSpecName { get; set; }                   // 검사기준명
        public DateTime? InspectionDateTime { get; set; }           // 검사 일시
        public decimal? IES { get; set; }                            // Inspection Equipment Settings


        public InspEquipSettingRecordModel ToModel(InspEquipModel InspEquip, InspSpecModel InspSpec, FullInspRecordModel FullInspRecord, decimal Accuracy)
        {
            InspEquipSettingRecordModel model = new InspEquipSettingRecordModel();
            model.InspEquip = InspEquip;
            model.InspSpec = InspSpec;
            model.InspectionDateTime = InspectionDateTime;
            model.IES = IES;
            model.Accuracy = Accuracy;
            model.FullInspRecord = FullInspRecord;
            return model;
        }

        public InspEquipSettingRecordVo ToVo(InspEquipSettingRecordModel InspEquipSettingRecord)
        {
            return new InspEquipSettingRecordVo
            {
                Id = InspEquipSettingRecord.Id,
                InspEquipName = InspEquipSettingRecord.InspEquip.InspEquipName,
                InspSpecName = InspEquipSettingRecord.InspSpec.InspSpecName,
                InspectionDateTime = InspEquipSettingRecord.InspectionDateTime,
                IES = InspEquipSettingRecord.IES,
                SpecIES = InspEquipSettingRecord.InspSpec.ProdInfo.ProdWeight,
                ETR = InspEquipSettingRecord.InspSpec.ETR,
                Unit = InspEquipSettingRecord.InspEquip.Unit,
                Accuracy = InspEquipSettingRecord.Accuracy
            };
        }
    }
}
