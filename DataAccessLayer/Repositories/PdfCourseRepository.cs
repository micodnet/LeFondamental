using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ToolBox;
using DataAccessLayer.Mappers;

namespace DataAccessLayer.Repositories
{
    public class PdfCourseRepository : IRepository<PdfCourseEntity>
    {
        private readonly IConnection _connection;
        public PdfCourseRepository(IConnection connection)
        {
            _connection = connection;
        }
        public void Add(PdfCourseEntity entity)
        {
            Command command = new Command("AddPdf", true);
            command.AddParameter("Title", entity.Title);
            command.AddParameter("Content", entity.Content);
            command.AddParameter("CourseId", entity.CourseId);
            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id)
        {
            Command command = new Command("deletePdf", true);
            command.AddParameter("Id", id);
            
            _connection.ExecuteNonQuery(command);
        }

        public PdfCourseEntity Get(int id)
        {
            Command command = new Command("GetPdfId", true);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, er => er.DbToPdfCourse()).First();
        }

        public IEnumerable<PdfCourseEntity> GetAll()
        {
            Command command = new Command("GetAllPdf", true);
            return _connection.ExecuteReader(command, er => er.DbToPdfCourse()).ToList();
        }

        public void Update(PdfCourseEntity entity)
        {
            Command command = new Command("UPDATE PdfCourses SET Title = 'newTitle', Content = 'newContent', CourseId = 'newCourseId' WHERE Id = @id;", false);
            command.AddParameter("Id", entity.Id);
            _connection.ExecuteNonQuery(command);
        }
    }
}
