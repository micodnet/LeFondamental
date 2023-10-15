using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        UserModel LoginUser(string email, string psswd);
        void RegisterUser(string lastName, string firstName, DateTime birthDate, string nickname, string email, string psswdHash);
        UserModel GetUserById(int id);
        IEnumerable<UserModel> GetAllUsers();
        void DeleteUser(int id);
        void UpdateUser(int id);
        void SetRole(int userId,int roleId);

    }
}
