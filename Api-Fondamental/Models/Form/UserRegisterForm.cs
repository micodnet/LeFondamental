using System.ComponentModel.DataAnnotations;

namespace Api_Fondamental.Models.Form
{
    public class UserRegisterForm
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        public string PsswdHash { get; set; }
    }
}