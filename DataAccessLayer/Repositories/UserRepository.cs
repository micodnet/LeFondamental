using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Mappers;
using Microsoft.AspNetCore.Rewrite;
using ToolBox;
using BCrypt.Net;

namespace DataAccessLayer.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IDbConnection _dbConnection;
        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            _dbConnection.Open();
            string sql = "SELECT * FROM Users";
            return _dbConnection.Query<UserEntity>(sql);
        }

        public void RegisterUser(string lastName, string firstName, DateTime birthDate, string nickname, string email, string psswdHash)
        {
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(psswdHash);

            string sql = "INSERT INTO Users (LastName, FirstName, BirthDate,  NickName, Email, PsswdHash)" +
                " VALUES (@lastName, @firstName, @birthDate, @nickName, @email, @PasswordHash)";
            var param = new { lastName, firstName, birthDate, nickname, email, PasswordHash };
            _dbConnection.Execute(sql, param);

        }

        public UserEntity LoginUser(string email, string psswdHash)
        {
            try
            {
                string sqlCheckPassword = "SELECT * FROM Users WHERE Email = @email";
                return _dbConnection.QueryFirst<UserEntity>(sqlCheckPassword, new { email });

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Utilisateur inéxistant");
            }
        }

        public void SetRole(int userId, int roleId)
        {
            string sql = "UPDATE Users SET RoleId = @roleId WHERE Id = @userId";
            var param = new { userId, roleId };
            _dbConnection.Execute(sql, param);
        }

        public UserEntity GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            var param = new { id };
            return _dbConnection.QueryFirst<UserEntity>(sql, param);
        }

        public void DeleteUser(int id)
        {
            string sql = "DELETE FROM Users WHERE Id = @Id";
            var param = new { id };
            _dbConnection.Execute(sql, param);
        }

        public void UpdateUser(int id)
        {
            string sql = "UPDATE Users SET LastName = 'newLastName', FirstName = 'newFirstName', BirthDate = 'newBirthDate', NickName = 'newNickName', Email = 'newEmail', PsswdHash = 'newPsswdHash' WHERE Id = @Id";
            var param = new { id };
            _dbConnection.Execute(sql, param);
        }
    }
}
