using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Dto
{
    public class CaseLotVo
    {
        public int Id { get; set; }
        public string? LotNumber { get; set; }       // 로트번호
        public string? Unit { get; set; }            // 단위

        public CaseLotModel ToModel()
        {
            return new CaseLotModel
            {
                Id = Id,
                LotNumber = LotNumber,
                Unit = Unit
            };
        }

        public CaseLotVo ToVo(CaseLotModel caseLot)
        {
            return new CaseLotVo
            {
                Id = caseLot.Id,
                LotNumber = caseLot.LotNumber,
                Unit = caseLot.Unit
            };
        }
    }
}
