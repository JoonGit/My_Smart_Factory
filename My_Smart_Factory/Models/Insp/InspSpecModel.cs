using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models.Insp
{
    // 상품검사를 위한 기준 스펙
    public class InspSpecModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? InspSpecName { get; set; }                        // 검사기준명
        public virtual ProdInfoModel? ProdInfo { get; set; }             // 관리번호
        public virtual InspEquipModel? InspEquip { get; set; }          // 검사장비
        public double? IES { get; set; }                                // Inspection Equipment Settings (검사장비설정)
        public int? ETR { get; set; }                                   // 오류 허용범위 (Error Tolerance Range)
    }
}
