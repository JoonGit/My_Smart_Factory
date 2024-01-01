using My_Smart_Factory.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    //케이스 로트 : 한상자의 번호와 그 안에 들어있는 제품의 수량
    //Case Lot
    public class CaseLotModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LotNumber { get; set; }       // 로트번호
        public string? Unit { get; set; }            // 단위
    }
}
