using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class MessageHubModel
    {
        public int Id { get; init; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int UserIdEnvoi { get; set; }
        public int UserIdRecu { get; set; }
        public DateTime DateEnvoi { get; set; }
    }
}
