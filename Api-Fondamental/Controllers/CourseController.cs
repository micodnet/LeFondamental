using Api_Fondamental.Mappers;
using Api_Fondamental.Models;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Fondamental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly Iservice<CourseModel> _service;
        public CourseController(Iservice<CourseModel> service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet("GetCourseById/{Id}")]
        public IActionResult GetCourseById(int Id)
        {
            return Ok(_service.Get(Id));
        }
        [HttpPost]
        public IActionResult Post(CourseViewModel model)
        {
            try
            {
                _service.Add(model.ApiToBll());
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
            _service.Delete(Id);
            return Ok();
        }
    }
}
