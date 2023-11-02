using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        UserEntity LoginUser(string email, string psswdHash);
        void RegisterUser(string lastName, string firstName, DateTime birthDate, string nickName, string email, string psswdHash);
        UserEntity GetUserById(int id);
        IEnumerable<UserEntity> GetAllUsers();
        void DeleteUser(int id);
        void UpdateUser(int id);
        void SetRole(int userId, int roleId);
    }
}