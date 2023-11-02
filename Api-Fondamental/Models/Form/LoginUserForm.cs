using System.ComponentModel.DataAnnotations;

namespace Api_Fondamental.Models.Form
{
    public class LoginUserForm
    {

        
        [Required]
        public string Email { get; set; }
        [Required]
        public string PsswdHash { get; set; }
    }
}
