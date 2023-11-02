using Api_Fondamental.DTOs;
using Api_Fondamental.Infrastructure;
using Api_Fondamental.Mappers;
using Api_Fondamental.Models;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Fondamental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Iservice<StudentModel> _studentService;
        private readonly TokenGenerator _tokenGenerator;
        public StudentController(Iservice<StudentModel> studentService, TokenGenerator tokenGenerator) 
        {
            _studentService = studentService;
            _tokenGenerator = tokenGenerator;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }
        [HttpGet("GetStudentById/{Id}")]
        public IActionResult GetStudentById(int Id)
        {
            return Ok(_studentService.Get(Id));
        }
        [HttpPost]
        public IActionResult Post(StudentViewModel viewModel)
        {
            try
            {
           
                _studentService.Add(viewModel.ApiToBll());
            }
            catch (Exception ex)
            {
                if (viewModel == null)
                {
                    BadRequest(ex.Message);
                }
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _studentService.Delete(Id);
            return Ok();
        }
    }
}
