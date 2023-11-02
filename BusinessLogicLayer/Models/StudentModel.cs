using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class StudentModel
    {
        public int Id { get; init; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string PsswdHash { get; set; }
        public int UserId { get; set; }
    }
}
