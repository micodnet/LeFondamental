using System.ComponentModel.DataAnnotations;

namespace Api_Fondamental.DTOs
{
    public class User
    {
        [Required]public string LastName { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public DateTime BirthDate { get; set; }
        [Required] public string NickName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string PsswdHash { get; set; }
    }
}
