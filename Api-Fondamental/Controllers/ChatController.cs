using Api_Fondamental.DTOs;
using Api_Fondamental.Hubs;
using Api_Fondamental.Infrastructure;
using Api_Fondamental.Models.Form;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Fondamental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenGenerator _tokenGenerator;
        private readonly ChatHub hub;

        public ChatController(IUserService userService, TokenGenerator tokenGenerator, ChatHub Hub)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
            hub = Hub;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser user)
        {
            try
            {
                
                UserModel connectedUser = _userService.LoginUser(user.Email, user.PsswdHash);
                string MdpUser = user.PsswdHash;
                string hashpwd = connectedUser.PsswdHash;
                bool motDePasseValide = BCrypt.Net.BCrypt.Verify(MdpUser, hashpwd);

                if (motDePasseValide)
                {
                   
                    await hub.JoinGroup("groupName", "userName");
                    return Ok(/*_tokenGenerator.GenerateToken(connectedUser)*/);
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
            //sur base de l'id de connection, je vais récup la liste des groupe du user
            //et je le reinscrit dans ses groupes au niveau du hub
            
        }
    }
}
