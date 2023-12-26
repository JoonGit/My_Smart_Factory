using System.ComponentModel.DataAnnotations;

namespace My_Smart_Factory.Data.Dto.User
{
    public class LoginDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
