using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Dto.Pi
{
    public class ProdInfoDto
    {
        public int id { get; set; }
        public string? prodName { get; set; }       // 제품명
        public string? prodCode { get; set; }       // 제품코드
        public string? prodWeight { get; set; }     // 제품 무게       

        public ProdInfoModel ToModel()
        {
            ProdInfoModel model = new ProdInfoModel();
            model.ProdName = prodName;
            model.ProdCode = prodCode;
            model.ProdWeight = prodWeight;

            return model;
        }
    }
}
