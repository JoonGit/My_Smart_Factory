using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Data.Vo.Insp
{
    public class InspSpecVo
    {
        public int Id { get; set; }
        public string? InspSpecName { get; set; }                        // 검사기준명
        public string? ProdName { get; set; }                            // 상품이름
        public string? InspEquipName { get; set; }                       // 장비명
        public decimal? IES { get; set; }                                // Inspection Equipment Settings (검사장비설정)
        public int? ETR { get; set; }
        
    }
}
