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
            Command command = new Command("INSERT INTO Courses(Title, Description, FormationId)" + "VALUES ('title', 'description', 'formationId')", false);
            command.AddParameter("title", entity.Title);
            command.AddParameter("description", entity.Description);
            command.AddParameter("formationId", entity.FormationId);
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("DeleteCourse",true); 
            command.AddParameter("Id", id);
            _connection.ExecuteNonQuery(command);
        }

        public CourseEntity Get(int id)
        {
            Command command = new Command("GetCourseId", true);
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
