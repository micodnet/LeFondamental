using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Api_Fondamental.DTOs
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [MinLength(8), MaxLength(500)]
        public string PsswdHash { get; set; }
    }   
}
