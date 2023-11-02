using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                PsswdHash = model.PsswdHash,
                RoleId = model.RoleId
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
                PsswdHash = entity.PsswdHash,
                RoleId = entity.RoleId
            };
        }
        internal static StudentEntity BllToDal(this StudentModel model)
        {
            return new StudentEntity()
            {
                Id = model.Id,
                NickName = model.NickName,
                Email = model.Email,
                PsswdHash = model.PsswdHash,
                UserId = model.UserId,
            };
        }
        internal static StudentModel DalToBll(this StudentEntity entity)
        {
            return new StudentModel()
            {
                Id = entity.Id,
                NickName = entity.NickName,
                Email = entity.Email,
                PsswdHash = entity.PsswdHash,
                UserId = entity.UserId,
            };
        }
        internal static PdfCourseEntity BllToDal(this PdfCourseModel model)
        {
            return new PdfCourseEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                CourseId = model.CourseId,
            };
        }
        internal static PdfCourseModel DalToBll(this PdfCourseEntity entity)
        {
            return new PdfCourseModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                CourseId = entity.CourseId,
            };
        }
        internal static MessageHubEntity BllToDal(this  MessageHubModel model)
        {
            return new MessageHubEntity()
            {
                Id = model.Id,
                Author = model.Author,
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
                Id = entity.Id,
                Author = entity.Author,
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
                Id = model.Id,
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
                Id = entity.Id,
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
                Id = model.Id,
                Content = model.Content,
                CourseId = model.CourseId,
            };
        }
        internal static ExplicationModel DalToBll(this ExplicationEntity entity)
        {
            return new ExplicationModel()
            {
                Id = entity.Id,
                Content = entity.Content,
                CourseId = entity.CourseId,
            };
        }
        internal static CourseEntity BllToDal(this CourseModel model)
        {
            return new CourseEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                FormationId = model.FormationId,
            };
        }
        internal static CourseModel DalToBll(this CourseEntity entity)
        {
            return new CourseModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                FormationId = entity.FormationId,
            };
        }
        internal static RoleEntity BllToDal(this RoleModel model)
        {
            return new RoleEntity()
            {
                Id = model.Id,
                Label = model.Label,
            };
        }
        internal static RoleModel DalToBll(this RoleEntity entity)
        {
            return new RoleModel()
            {
                Id = entity.Id,
                Label = entity.Label,
            };
        }
    }
}
