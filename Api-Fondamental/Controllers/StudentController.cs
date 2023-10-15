using Api_Fondamental.Mappers;
using Api_Fondamental.Models;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
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
        public StudentController(Iservice<StudentModel> studentService) 
        {
            _studentService = studentService;
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
        public IActionResult Post(StudentViewModel model)
        {
            try
            {
                _studentService.Add(model.ApiToBll());
            }
            catch (Exception ex)
            {
                if (model == null)
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
