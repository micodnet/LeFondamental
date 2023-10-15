using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class MessageHubEntity
    {
        public int Id { get; init; }
        public string Content { get; set; }
        public int UserIdEnvoi { get; set; }
        public int UserIdRecu { get; set; }
        public DateTime DateEnvoi { get; set; }
    }
}
