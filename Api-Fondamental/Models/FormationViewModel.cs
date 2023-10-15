namespace Api_Fondamental.Models
{
    public class FormationViewModel
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime Duree { get; set; }
        public string PreRequis { get; set; }
    }
}
