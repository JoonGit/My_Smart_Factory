using System.ComponentModel.DataAnnotations;

namespace My_Smart_Factory.Data.Dto.User
{
    public class UpdateRolesDto
    {
        public string[] UserId { get; set; }
        public string[] Role { get; set; }
        public string[] BeforeRole { get; set; }
    }
}
