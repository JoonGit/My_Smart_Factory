using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace My_Smart_Factory.Models
{
    public class QRCodeModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Enter QRCode Text")]
        public string QRCodeText { get; set; }
    }
}
