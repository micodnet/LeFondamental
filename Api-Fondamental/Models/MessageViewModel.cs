namespace Api_Fondamental.Models
{
    public class MessageViewModel
    {
        public int Id { get; init; }
        public string Content { get; set; }
        public int UserIdEnvoi { get; set; }
        public int UserIdRecu { get; set; }
        public DateTime DateEnvoi { get; set; }
    }
}
