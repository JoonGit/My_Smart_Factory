using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    //Product Control Number
    public class ProdCtrlNoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ControlNumber { get; set; }       // 관리번호
        public string? OriginOfProduction { get; set; }      // 스펙
    }
}
