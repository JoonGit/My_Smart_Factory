using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Models.Insp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models.Prod
{
    // 제품의 정보
    public class ProdInfoModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ProdName { get; set; }                       // 상품이름
        public string? ProdCode { get; set; }                       // 상품코드
        public string? ProdWeight { get; set; }                     // 상품무게

    }
}
