using My_Smart_Factory.Data.Vo.Prod;
using My_Smart_Factory.Models.Prod;

namespace My_Smart_Factory.Data.Dto.Prod
{
    public class ProdInfoDto
    {
        public int id { get; set; }
        public string? prodName { get; set; }       // 제품명
        public string? prodCode { get; set; }       // 제품코드
        public decimal? prodWeight { get; set; }     // 제품 무게       

        public ProdInfoModel ToModel()
        {
            ProdInfoModel model = new ProdInfoModel();
            model.ProdName = prodName;
            model.ProdCode = prodCode;
            model.ProdWeight = prodWeight;

            return model;
        }

        public ProdInfoVo ToVo() {             
            return new ProdInfoVo
            {
                id = id,
                prodName = prodName,
                prodCode = prodCode,
                prodWeight = prodWeight
            };
        }
    }
}
