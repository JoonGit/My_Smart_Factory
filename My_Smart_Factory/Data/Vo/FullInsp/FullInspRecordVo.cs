using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Data.Dto.Insp;
using My_Smart_Factory.Data.Vo.Insp;

namespace My_Smart_Factory.Data.Vo.FullInsp
{
    public class FullInspRecordVo
    {
        public int Id { get; set; }
        public string? FullInspNo { get; set; }                                               // 전수검사번호
        public string? WorkOrderNo { get; set; }                                                    // 작업 지시 번호

        //public virtual List<InspEquipSettingRecordVo>? InspEquipSettingRecordVos { get; set; }        // 검사장비 세팅 기록
        //public virtual List<InspProdRecordVo> InspProdRecordVos { get; set; }                         // 제품 검사 기록   
    }
}
