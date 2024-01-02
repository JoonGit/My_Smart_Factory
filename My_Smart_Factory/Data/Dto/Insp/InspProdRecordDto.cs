using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Data.Dto.Insp
{
    public class InspProdRecordDto
    {
        public int Id { get; set; }
        public string? InspEquipName { get; set; }       // 장비명
        public string? ProdCtrlNo { get; set; }                         // 관리번호
        public DateTime? InspectionDateTime { get; set; }           // 검사 일시
        public double? MeasuredValue { get; set; }                   // 측정값
        public double? Accuracy { get; set; }                       // 일치율
        public bool? IsPassed { get; set; }

        //public virtual InspEquipModel? InspEquip { get; set; }      // 검사 장비
        //public virtual ProdCtrlNoModel? ProdCtrlNo { get; set; }    // 관리번호

        public InspProdRecordModel ToModel(InspEquipModel InspEquip, ProdCtrlNoModel ProdCtrlNo)
        {
            return new InspProdRecordModel
            {
                InspEquip = InspEquip,
                ProdCtrlNo = ProdCtrlNo,
                InspectionDateTime = InspectionDateTime,
                MeasuredValue = MeasuredValue,
                Accuracy = Accuracy,
                IsPassed = IsPassed
            };
        }


    }
}
