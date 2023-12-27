using System.ComponentModel.DataAnnotations;

namespace My_Smart_Factory.Data.Dto.User
{
    public class UpdateRolesDto
    {
        public string userName { get; set; }
        public string oldRole { get; set; }
        public string newRole { get; set; }
    }
}
