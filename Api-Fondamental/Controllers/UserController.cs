using Api_Fondamental.DTOs;
using Api_Fondamental.Mappers;
using Api_Fondamental.Models;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using BusinessLogicLayer.Services;

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
                //Object userPublique = new { user.Id, user.FirstName, user.LastName };
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
    }
}
