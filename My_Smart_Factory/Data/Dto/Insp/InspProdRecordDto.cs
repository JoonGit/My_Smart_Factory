using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Data.Dto.Insp
{
    public class InspProdRecordDto
    {
        public int Id { get; set; }
        public string FullInspNo { get; set; }                          // 검사 관리 번호
        public string? InspSpecName { get; set; }                       // 장비명
        public string? ProdCtrlNo { get; set; }                         // 관리번호
        public DateTime? InspectionDateTime { get; set; }               // 검사 일시
        public decimal? MeasuredValue { get; set; }                     // 측정값

        //public virtual InspEquipModel? InspEquip { get; set; }      // 검사 장비
        //public virtual ProdCtrlNoModel? ProdCtrlNo { get; set; }    // 관리번호

        public InspProdRecordModel ToModel(InspSpecModel InspSpec, ProdCtrlNoModel ProdCtrlNo, FullInspRecordModel? FullInspRecord, decimal? Accuracy, bool IsPassed)
        {
            return new InspProdRecordModel
            {
                InspSpec = InspSpec,
                ProdCtrlNo = ProdCtrlNo,
                InspectionDateTime = InspectionDateTime,
                MeasuredValue = MeasuredValue,
                Accuracy = Accuracy,
                FullInspRecord = FullInspRecord,
                IsPassed = IsPassed
            };
        }
        
        public InspProdRecordVo ToVo(InspProdRecordModel InspProdRecord)
        {
            return new InspProdRecordVo
            {
                Id = InspProdRecord.Id,
                InspEquipName = InspProdRecord.InspSpec.InspEquip.InspEquipName,
                ProdCtrlNo = InspProdRecord.ProdCtrlNo.ProdCtrlNo,
                ProdName = InspProdRecord.ProdCtrlNo.ProdInfo.ProdName,
                InspectionDateTime = InspProdRecord.InspectionDateTime,
                MeasuredValue = InspProdRecord.MeasuredValue,
                Accuracy = InspProdRecord.Accuracy,
                Unit = InspProdRecord.InspSpec.InspEquip.Unit,
                IsPassed = InspProdRecord.IsPassed
            };
        }


    }
}
