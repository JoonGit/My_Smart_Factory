using My_Smart_Factory.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    public class PiModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ControlNumber { get; set; }       // 관리번호
        public string? Specification { get; set; }      // 스펙
        public string? LotNumber { get; set; }          // 로트번호


    }
}
