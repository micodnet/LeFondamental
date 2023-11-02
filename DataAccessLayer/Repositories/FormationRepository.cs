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
    public class FormationRepository : IRepository<FormationEntity>
    {
        private readonly IConnection _connection;
        public FormationRepository(IConnection connection) 
        {
            _connection = connection;
        }
        public void Add(FormationEntity entity)
        {
            Command command = new("INSERT INTO Formations (Name, Description, DateDebut, Duree, PreRequis) VALUES (@name, @description, @dateDebut, @duree, @preRequis)", false);
            command.AddParameter("name", entity.Name);
            command.AddParameter("description", entity.Description);
            command.AddParameter("dateDebut", entity.DateDebut);
            command.AddParameter("duree", entity.Duree);
            command.AddParameter("preRequis", entity.PreRequis);
            
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("DeleteFormation", true);
            command.AddParameter("id", id);
            _connection.ExecuteNonQuery(command);
        }

        public FormationEntity Get(int id)
        {
            Command command = new Command("GetFormationId", true);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, er => er.DbToFormation()).First();
        }

        public IEnumerable<FormationEntity> GetAll()
        {
            Command command = new Command("SELECT * FROM Formations" , false);
            return _connection.ExecuteReader(command, er => er.DbToFormation());
        }

        public void Update(FormationEntity entity)
        {
            Command command = new Command("UPDATE Formations WHERE Id = @Id", false);
            command.AddParameter("Id", entity.Id);
            _connection.ExecuteNonQuery(command);
        }
    }
}
