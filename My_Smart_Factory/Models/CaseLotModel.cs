using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    //케이스 로트
    //Case Lot
    public class CaseLotModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? LotNumber { get; set; }       // 로트번호
        public string? Unit { get; set; }            // 단위
    }
}
