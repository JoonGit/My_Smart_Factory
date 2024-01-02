using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Dto.Prod
{
    public class ProdCtrlNoDto
    {
        public int Id { get; set; }
        public string? ProdCtrlNo { get; set; }                         // 관리번호
        public string? ProdName { get; set; }                       // 상품이름

        //public virtual ProdInfoModel? ProdInfo { get; set; }
    }
}
