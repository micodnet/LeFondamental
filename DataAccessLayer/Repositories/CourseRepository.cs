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
    public class CourseRepository : IRepository<CourseEntity>
    {
        private readonly IConnection _connection;
        public CourseRepository(IConnection connection)
        {
            _connection = connection;
        }

        public void Add(CourseEntity entity)
        {
            Command command = new Command("CALL AddCourse", true);
            command.AddParameter("id", entity.Id);
            command.AddParameter("Title", entity.Title);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("FormationId", entity.FormationId);
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("CALL DeleteCourse",true); 
            command.AddParameter("id", id);
            _connection.ExecuteNonQuery(command);
        }

        public CourseEntity Get(int id)
        {
            Command command = new Command("CALL GetCourseId", true);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, er => er.DbToCourse()).First();
        }

        public IEnumerable<CourseEntity> GetAll()
        {
            Command command = new Command("SELECT * FROM Courses");
            return _connection.ExecuteReader(command, er => er.DbToCourse());
        }

        public void Update(CourseEntity entity)
        {
            Command command = new Command("UPDATE Courses SET Title = 'newTitle', Description = 'newDescription', FormationId = 'newFormationId' WHERE Id = @id;", false);
            command.AddParameter("id", entity.Id);
            _connection.ExecuteNonQuery(command);
        }
    }
}
