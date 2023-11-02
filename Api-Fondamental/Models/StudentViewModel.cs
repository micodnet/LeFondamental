namespace Api_Fondamental.Models
{
    public class StudentViewModel
    {
        public int Id { get; init; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string PsswdHash { get; set; }
        public int UserId { get; set; }
    }
}
