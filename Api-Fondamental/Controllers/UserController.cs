using Api_Fondamental.Mappers;
using Api_Fondamental.Models;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Fondamental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                UserViewModel user = _userService.GetUserById(id).ApiToBll();
                if (user is null) return NotFound();
                Object userPublique = new {user.Id, user.FirstName, user.LastName };
                return Ok(userPublique);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
    }
}
