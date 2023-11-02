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
            // Etape 1 : Recuperation de l'id user
            Command selectCommand = new Command("SELECT Id FROM Users WHERE Email = @email", false);
            selectCommand.AddParameter("email", entity.Email);
            int userId = Convert.ToInt32(_connection.ExecuteScalar(selectCommand));

            // Étape 2 : Insertion d'un nouvel étudiant avec l'ID de l'utilisateur récupéré
            string passSt = BCrypt.Net.BCrypt.HashPassword(entity.PsswdHash);

            Command insertCommand = new Command("INSERT INTO Students (NickName, Email, PsswdHash, UserId) " +
                "VALUES (@nickName, @email, @psswdHash, @userId)", false);
            insertCommand.AddParameter("nickName", entity.NickName);
            insertCommand.AddParameter("email", entity.Email);
            insertCommand.AddParameter("psswdHash", passSt);
            insertCommand.AddParameter("userId", userId);

            _connection.ExecuteNonQuery(insertCommand);
            
            //string psswdHash = entity.PsswdHash;
            //Hash.HashPassword(psswdHash);
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
