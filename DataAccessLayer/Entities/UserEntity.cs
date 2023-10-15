using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class UserEntity
    {
        public int Id { get; init; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string PsswdHash { get; set; }
        public int RoleId { get; set; }
    }
}
