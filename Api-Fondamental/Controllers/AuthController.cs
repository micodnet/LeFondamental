using Api_Fondamental.Infrastructure;
using Api_Fondamental.Models.Form;
using Api_Fondamental.Models;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Fondamental.Mappers;
using Api_Fondamental.DTOs;
using DataAccessLayer;

namespace Api_Fondamental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenGenerator _tokenManager;

        public AuthController(IUserService userService, TokenGenerator tokenManager)
        {
            _userService = userService;
            _tokenManager = tokenManager;
        }

        //[Authorize("AdminPolicy")]
        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangerRole r)
        {
            _userService.SetRole(r.UserId, r.RoleId);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserForm user)
        {
            try
            {
                UserModel connectedUser = _userService.LoginUser(user.Email, user.PsswdHash);
                string MdpUser = user.PsswdHash;
                string hashpwd = connectedUser.PsswdHash;
                bool motDePasseValide = BCrypt.Net.BCrypt.Verify(MdpUser, hashpwd);

                if (motDePasseValide)
                {
                    return Ok(_tokenManager.GenerateToken(connectedUser));
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            
                _userService.RegisterUser( user.LastName, user.FirstName, user.BirthDate, user.NickName, user.Email, user.PsswdHash);
                return Ok();
           
        }
    }
}
