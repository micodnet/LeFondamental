using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers().Select(x => x.DalToBll());
        }
        public void RegisterUser(string lastName, string firstName, DateTime birthDate,string nickname, string email, string psswdHash)
        {
            _userRepository.RegisterUser(lastName, firstName, birthDate, nickname, email, psswdHash);
        }
        public UserModel LoginUser(string email, string psswd)
        {
            return _userRepository.LoginUser(email, psswd).DalToBll();
        }
        public void SetRole(int userId, int roleId)
        {
            _userRepository.SetRole(userId, roleId);
        }

        public UserModel GetUserById(int id)
        {
            return _userRepository.GetUserById(id).DalToBll();
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public void UpdateUser(int id)
        {
            _userRepository.UpdateUser(id);
        }
    }
}
