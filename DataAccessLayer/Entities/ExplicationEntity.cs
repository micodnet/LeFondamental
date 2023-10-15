using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ExplicationEntity
    {
        public int Id { get; init; }
        public string Content { get; set; }
        public int CourseId { get; set; }
    }
}
