namespace My_Smart_Factory.Data.Vo.Prod
{
    public class ProdInfoVo
    {
        public int id { get; set; }
        public string? prodName { get; set; }       // 제품명
        public string? prodCode { get; set; }       // 제품코드
        public decimal? prodWeight { get; set; }     // 제품 무게           
    }
}
