using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers
{
    internal static class Mappers
    {
        internal static UserEntity BllToDal(this UserModel model)
        {
            return new UserEntity()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                NickName = model.NickName,
                Email = model.Email,
                PsswdHash = model.PsswdHash
            };
        }
        internal static UserModel DalToBll(this UserEntity entity)
        {
            return new UserModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate,
                NickName = entity.NickName,
                Email = entity.Email,
                PsswdHash = entity.PsswdHash
            };
        }
        internal static StudentEntity BllToDal(this StudentModel model)
        {
            return new StudentEntity()
            {
                Email = model.Email,
                NickName = model.NickName,
                PsswdHash = model.PsswdHash,
            };
        }
        internal static StudentModel DalToBll(this StudentEntity entity)
        {
            return new StudentModel()
            {
                Email = entity.Email,
                NickName = entity.NickName,
                PsswdHash = entity.PsswdHash,
            };
        }
        internal static PdfCourseEntity BllToDal(this PdfCourseModel model)
        {
            return new PdfCourseEntity()
            {
                Title = model.Title,
                Content = model.Content,
                CourseId = model.CourseId,
            };
        }
        internal static PdfCourseModel DalToBll(this PdfCourseEntity entity)
        {
            return new PdfCourseModel()
            {
                Title = entity.Title,
                Content = entity.Content,
                CourseId = entity.CourseId,
            };
        }
        internal static MessageHubEntity BllToDal(this  MessageHubModel model)
        {
            return new MessageHubEntity()
            {
                Content = model.Content,
                UserIdEnvoi = model.UserIdEnvoi,
                UserIdRecu = model.UserIdRecu,
                DateEnvoi = model.DateEnvoi,
            };
        }
        internal static MessageHubModel DalToBll(this MessageHubEntity entity)
        {
            return new MessageHubModel()
            {
                Content = entity.Content,
                UserIdEnvoi = entity.UserIdEnvoi,
                UserIdRecu = entity.UserIdRecu,
                DateEnvoi = entity.DateEnvoi,
            };
        }
        internal static FormationEntity BllToDal(this FormationModel model)
        {
            return new FormationEntity()
            {
                Name = model.Name,
                Description = model.Description,
                DateDebut = model.DateDebut,
                Duree = model.Duree,
                PreRequis = model.PreRequis,
            };
        }
        internal static FormationModel DalToBll(this FormationEntity entity)
        {
            return new FormationModel()
            {
                Name = entity.Name,
                Description = entity.Description,
                DateDebut = entity.DateDebut,
                Duree = entity.Duree,
                PreRequis = entity.PreRequis,
            };
        }
        internal static ExplicationEntity BllToDal(this ExplicationModel model)
        {
            return new ExplicationEntity()
            {
                Content = model.Content,
                CourseId = model.CourseId,
            };
        }
        internal static ExplicationModel DalToBll(this ExplicationEntity entity)
        {
            return new ExplicationModel()
            {
                Content = entity.Content,
                CourseId = entity.CourseId,
            };
        }
        internal static CourseEntity BllToDal(this CourseModel model)
        {
            return new CourseEntity()
            {
                Title = model.Title,
                Description = model.Description,
                FormationId = model.FormationId,
            };
        }
        internal static CourseModel DalToBll(this CourseEntity entity)
        {
            return new CourseModel()
            {
                Title = entity.Title,
                Description = entity.Description,
                FormationId = entity.FormationId,
            };
        }
        internal static RoleEntity BllToDal(this RoleModel model)
        {
            return new RoleEntity()
            {
                Label = model.Label,
            };
        }
        internal static RoleModel DalToBll(this RoleEntity entity)
        {
            return new RoleModel()
            {
                Label = entity.Label,
            };
        }
    }
}
