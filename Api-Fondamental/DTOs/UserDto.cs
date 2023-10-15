using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Api_Fondamental.DTOs
{
    public class UserDto
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [MinLength(8), MaxLength(500)]
        public string PsswdHash { get; set; }
        //public int RoleId { get; set; } = 1;
    }
}
