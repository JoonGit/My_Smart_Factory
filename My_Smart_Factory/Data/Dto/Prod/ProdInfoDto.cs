using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Data.Dto.Prod
{
    public class ProdInfoDto
    {
        public int Id { get; set; }
        public string? ProdName { get; set; }                       // 상품이름
        public string? ProdCode { get; set; }                       // 상품코드
        public string? ProdWeight { get; set; }
    }
}
