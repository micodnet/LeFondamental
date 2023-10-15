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
    public class ExplicationRepository : IRepository<ExplicationEntity>
    {
        private readonly IConnection _connection;
        public ExplicationRepository(IConnection connection) 
        {
            _connection = connection;
        }
        public void Add(ExplicationEntity entity)
        {
            Command command = new Command("CALL AddExplication", true);
            command.AddParameter("id", entity.Id);
            command.AddParameter("Content", entity.Content);
            command.AddParameter("CourseId", entity.CourseId);
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("CALL DeleteExplication", true);
            command.AddParameter("id", id);
            _connection.ExecuteNonQuery(command);
        }

        public ExplicationEntity Get(int id)
        {
            Command command = new Command("CALL GetExplicationId", true);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, er => er.DbToExplication()).First(); 
        }

        public IEnumerable<ExplicationEntity> GetAll()
        {
            Command command = new Command("SELECT * FROM Explications", false);
            return _connection.ExecuteReader(command, er => er.DbToExplication());
        }

        public void Update(ExplicationEntity entity)
        {
            Command command = new Command("UPDATE Explications WHERE Id = @id", false);
            command.AddParameter("id", entity.Id);
            _connection.ExecuteNonQuery(command);
        }
    }
}
