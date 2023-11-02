using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Api_Fondamental.DTOs
{
    public class LoginUser
    {
        public int Id { get; init; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [MinLength(8), MaxLength(500)]
        public string PsswdHash { get; set; }
    }   
}
