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
    public class MessageHubRepository : IRepository<MessageHubEntity>
    {
        private readonly IConnection _connection;
        public MessageHubRepository(IConnection connection)
        {
            _connection = connection;
        }
        public void Add(MessageHubEntity entity)
        {
            Command command = new Command("CALL AddMessage", true);
            command.AddParameter("id", entity.Id);
            command.AddParameter("Content", entity.Content);
            command.AddParameter("UserIdEnvoi", entity.UserIdEnvoi);
            command.AddParameter("UserIdRecu", entity.UserIdRecu);
            command.AddParameter("DateEnvoi", entity.DateEnvoi);
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("CALL DeleteMessage", true);
            command.AddParameter("Id", id);
            _connection.ExecuteNonQuery(command);

        }

        public MessageHubEntity Get(int id)
        {
            Command command = new Command("CALL GetMessageId", true);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, er => er.DbToMessageHub()).First();
        }

        public IEnumerable<MessageHubEntity> GetAll()
        {
            Command command = new Command("SELECT * FROM MessagesHub", false);
            return _connection.ExecuteReader(command, er => er.DbToMessageHub());
        }

        public void Update(MessageHubEntity entity)
        {
            Command command = new Command("UPDATE MessagesHub WHERE Id = @id", false);
            command.AddParameter("Id", entity.Id);
            _connection.ExecuteNonQuery(command);
        }
    }
}
