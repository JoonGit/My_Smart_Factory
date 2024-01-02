using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Data.Dto.Insp
{
    public class InspSpecDto
    {
        public int Id { get; set; }
        public string? InspSpecName { get; set; }                        // 검사기준명
        public string? ProdName { get; set; }                            // 상품이름
        public string? InspEquipName { get; set; }                       // 장비명
        public double? IES { get; set; }                                // Inspection Equipment Settings (검사장비설정)
        public int? ETR { get; set; }

        public InspSpecModel ToModel(ProdInfoModel ProdInfo, InspEquipModel InspEquip)
        {
            InspSpecModel model = new InspSpecModel();
            model.InspSpecName = InspSpecName;
            model.IES = IES;
            model.ETR = ETR;
            model.InspEquip = InspEquip;
            model.ProdInfo = ProdInfo;

            return model;
        }
    }
}
