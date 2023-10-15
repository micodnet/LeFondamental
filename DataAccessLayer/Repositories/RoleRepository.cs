using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Mappers;
using ToolBox;

namespace DataAccessLayer.Repositories
{
    public class RoleRepository : IRepository<RoleEntity>
    {
        private readonly IConnection _connection;
        public RoleRepository(IConnection connection)
        {
            _connection = connection;
        }
        public void Add(RoleEntity entity)
        {
            Command command = new Command("INSERT INTO Roles (Label)" + " VALUES (@label)", false);
            command.AddParameter("id", entity.Id);
            command.AddParameter("label", entity.Label);
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("DELETE Roles WHERE Id = @id", false);
            command.AddParameter("id", id);
            _connection.ExecuteNonQuery(command);
        }

        public RoleEntity Get(int id)
        {
            Command command = new Command("SELECT * FROM Roles WHERE Id = @id", false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, er => er.DbToRole()).First();
        }

        public IEnumerable<RoleEntity> GetAll()
        {
            Command command = new Command("SELECT * FROM Roles", false);
            return _connection.ExecuteReader(command, er => er.DbToRole());
        }

        public void Update(RoleEntity entity)
        {
            Command command = new Command("UPDATE Roles WHERE ID = @id", false);
            command.AddParameter("id", entity.Id);
            _connection.ExecuteNonQuery(command);
        }
    }
}
