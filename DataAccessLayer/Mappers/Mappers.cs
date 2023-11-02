using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Mappers
{
    public static class Mappers
    {
        internal static UserEntity DbToUser(this IDataRecord record)
        {
            return new UserEntity()
            {
                Id = (int)record["Id"],
                LastName = (string)record["LastName"],
                FirstName = (string)record["FirstName"],
                NickName = (string)record["Login"],
                Email = (string)record["Email"],
                BirthDate = (DateTime)record["BirtDate"],
                PsswdHash = (string)record["PsswdHash"],
                RoleId = (int)record["RoleId"]
            };
        }
        internal static StudentEntity DbToStudent(this IDataRecord record) 
        {
            return new StudentEntity()
            {
                Id = (int)record["Id"],
                NickName = (string)record["NickName"],
                Email = (string)record["Email"],
                PsswdHash = (string)record["PsswdHash"],
                UserId = (int)record["UserId"]
            };
        }
        internal static PdfCourseEntity DbToPdfCourse(this IDataRecord record)
        {
            return new PdfCourseEntity()
            {
                Id = (int)record["Id"],
                Title = (string)record["Title"],
                Content = (string)record["Content"],
                CourseId = (int)record["CourseId"]
            };
        }
        internal static MessageHubEntity DbToMessageHub(this IDataRecord record)
        {
            return new MessageHubEntity()
            {
                Id = (int)record["Id"],
                Content = (string)record["Content"],
                UserIdEnvoi = (int)record["UserIdEnvoi"],
                UserIdRecu = (int)record["UserIdRecu"],
                DateEnvoi = (DateTime)record["DateEnvoi"],
            };
        }
        internal static FormationEntity DbToFormation(this IDataRecord record)
        {
            return new FormationEntity()
            {
                Id = (int)(record["Id"]),
                Name = (string)record["Name"],
                Description = (string)record["Description"],
                DateDebut  = (DateTime)record["DateDebut"],
                Duree = (DateTime)record["Duree"],
                PreRequis = (string)record["PreRequis"],
            };
        }
        internal static ExplicationEntity DbToExplication(this IDataRecord record)
        {
            return new ExplicationEntity()
            {
                Id = (int)(record["Id"]),
                Content = (string)record["Content"],
                CourseId = (int)record["CourseId"]
            };
        }
        internal static CourseEntity DbToCourse(this IDataRecord record)
        {
            return new CourseEntity()
            {
                Id = (int)(record["Id"]),
                Title = (string)record["Title"],
                Description = (string)record["Description"],
                FormationId = (int)record["FormationId"]
            };
        }
        internal static RoleEntity DbToRole(this IDataRecord record)
        {
            return new RoleEntity()
            {
                Id = (int)(record["Id"]),
                Label = (string)record["Label"]
            };
        }
    }
}
