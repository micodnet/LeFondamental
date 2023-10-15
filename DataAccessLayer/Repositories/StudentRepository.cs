using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Mappers;
using ToolBox;

namespace DataAccessLayer.Repositories
{
    public class StudentRepository : IRepository<StudentEntity>
    {
        private readonly IConnection _connection;
        public StudentRepository(IConnection connection)
        {
            _connection = connection;
        }
        public void Add(StudentEntity entity)
        {
            Command command = new Command("INSERT INTO Students (Email, NickName, PsswdHash)" +
                " VALUES (@email, @nickName, @psswdHash)", false);
            command.AddParameter("id", entity.Id);
            command.AddParameter("email", entity.Email);
            command.AddParameter("nickName", entity.NickName);
            command.AddParameter("psswdHash", entity.PsswdHash);
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("DELETE Students WHERE Id = @id", false);
            command.AddParameter("id", id);
            _connection.ExecuteNonQuery(command);
        }

        public StudentEntity Get(int id)
        {
            Command command = new Command("SELECT * FROM Students WHERE Id = @id", false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, er => er.DbToStudent()).First();
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            Command command = new Command("SELECT * FROM Students", false);
            return _connection.ExecuteReader(command,er => er.DbToStudent()).ToList();
        }

        public void Update(StudentEntity entity)
        {
            Command command = new Command("UPDATE Students WHERE Id = @id", false);
            command.AddParameter("id", entity.Id);
            _connection.ExecuteNonQuery(command);
        }
    }
}
