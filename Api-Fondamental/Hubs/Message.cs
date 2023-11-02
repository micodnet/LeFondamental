namespace Api_Fondamental.Hubs
{
    public class Message
    {
        public int Id { get; init; }
        public string Author { get; init; }
        public string Content { get; set; }
        public int UserIdEnvoi { get; set; }
        public int UserIdRecu { get; set; }
        public DateTime DateEnvoi { get; set; }
    }
}
