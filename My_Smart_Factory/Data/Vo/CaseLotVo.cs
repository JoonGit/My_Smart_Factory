using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Vo
{
    public class CaseLotVo
    {
        public int Id { get; set; }
        public string? LotNumber { get; set; }       // 로트번호
        public string? Unit { get; set; }            // 단위
    }
}
