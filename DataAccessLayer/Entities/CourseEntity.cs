using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CourseEntity
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FormationId { get; set; }
    }
}
