using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Vo.Insp;

namespace My_Smart_Factory.Data.Vo
{
    public class FullInspRecordVo
    {
        public int Id { get; set; }
        public string? FullInspectionNumber { get; set; }                                               // 전수검사번호
        public string? WorkOrderNumber { get; set; }                                                    // 작업 지시 번호

        public virtual List<InspEquipSettingRecordVo>? InspEquipSettingRecordDtos { get; set; }        // 검사장비 세팅 기록
        public virtual List<InspProdRecordVo> InspProdRecordDtos { get; set; }                         // 제품 검사 기록   
    }
}
