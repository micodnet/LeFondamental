using Api_Fondamental.DTOs;
using Api_Fondamental.Models;
using Api_Fondamental.Models.Form;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;

namespace Api_Fondamental.Mappers
{
    public static class Mapper
    {
        internal static UserModel ApiToBll(this UserRegisterForm form)
        {
            return new UserModel()
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                BirthDate = form.BirthDate,
                NickName = form.NickName,
                Email = form.Email,
                PsswdHash = form.PsswdHash

            };
        }

        internal static UserViewModel ApiToBll(this UserModel model)
        {
            return new UserViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                NickName = model.NickName,
                Email = model.Email
            };
        }

        internal static UserModel BllToApî(this UserViewModel viewModel)
        {
            return new UserModel()
            {
                Id = viewModel.Id,
                LastName = viewModel.LastName,
                FirstName = viewModel.FirstName,
                BirthDate = viewModel.BirthDate,
                NickName = viewModel.NickName,
                Email = viewModel.Email
            };
        }

        internal static UserModel BllToApî(this User userDto)
        {
            return new UserModel()
            {
                
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                BirthDate = userDto.BirthDate,
                NickName = userDto.NickName,
                Email = userDto.Email,
                PsswdHash = userDto.PsswdHash
            };
        }
        internal static StudentModel ApiToBll(this StudentViewModel viewModel)
        {
            return new StudentModel()
            {
                Id = viewModel.Id,
                NickName = viewModel.NickName,
                Email = viewModel.Email,
                PsswdHash = viewModel.PsswdHash,
                UserId = viewModel.UserId
            };
        }
        internal static StudentViewModel BllToApi(this StudentModel model)
        {
            return new StudentViewModel()
            {
                Id = model.Id,
                NickName = model.NickName,
                Email = model.Email,
                PsswdHash = model.PsswdHash,
                UserId = model.UserId
            };
        }
        internal static RoleModel ApiToBll(this RoleViewModel model)
        {
            return new RoleModel()
            {
                Label = model.Label,

            };
        }
        internal static RoleViewModel BllToApi(this RoleModel model)
        {
            return new RoleViewModel()
            {
                Label = model.Label,

            };
        }
        internal static MessageHubModel ApiToBll(this MessageViewModel model)
        {
            return new MessageHubModel()
            {
                Id = model.Id,
                Author = model.Author,
                Content = model.Content,
                UserIdEnvoi = model.UserIdEnvoi,
                UserIdRecu = model.UserIdRecu,
                DateEnvoi = model.DateEnvoi,
            };
        }
        internal static MessageViewModel BllToApi(this MessageHubModel model)
        {
            return new MessageViewModel()
            {
                Id = model.Id,
                Author = model.Author,
                Content = model.Content,
                UserIdEnvoi = model.UserIdEnvoi,
                UserIdRecu = model.UserIdRecu,
                DateEnvoi = model.DateEnvoi
            };
        }
        internal static FormationModel ApiToBll(this FormationViewModel viewModel)
        {
            return new FormationModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                DateDebut = viewModel.DateDebut,
                Duree = viewModel.Duree,
                PreRequis = viewModel.PreRequis,
            };
        }
        internal static FormationViewModel BllToApi(this FormationModel model)
        {
            return new FormationViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                DateDebut = model.DateDebut,
                Duree = model.Duree,
                PreRequis = model.PreRequis,
            };
        }
        internal static CourseModel ApiToBll(this CourseViewModel model)
        {
            return new CourseModel()
            {
                Title = model.Title,
                Description = model.Description,
                FormationId = model.FormationId,
            };
        }
        internal static CourseViewModel BllToApi(this CourseModel model)
        {
            return new CourseViewModel()
            {
                Title = model.Title,
                Description = model.Description,
                FormationId = model.FormationId,

            };
        }
        internal static ExplicationModel ApiToBll(this ExplicationViewModel model)
        {
            return new ExplicationModel()
            {
                Content = model.Content,
                CourseId = model.CourseId

            };
        }
        internal static ExplicationViewModel BllToApi(this ExplicationModel model)
        {
            return new ExplicationViewModel()
            {
                Content = model.Content,
                CourseId = model.CourseId


            };
        }
        internal static PdfCourseModel ApiToBll(this PdfCourseViewModel model)
        {
            return new PdfCourseModel()
            {
                Title = model.Title,
                Content = model.Content,
                CourseId = model.CourseId

            };
        }
        internal static PdfCourseViewModel BllToApi(this PdfCourseModel model)
        {
            return new PdfCourseViewModel()
            {
                Title = model.Title,
                Content = model.Content,
                CourseId = model.CourseId


            };
        }
    }
}
