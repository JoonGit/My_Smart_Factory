using System.ComponentModel.DataAnnotations;

namespace My_Smart_Factory.Data.Dto.User
{
    public class SignUpDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
