using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLearningSkills.BL.Interfaces;
using MyLearningSkills.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;

namespace MyLearningSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesBusinessLogic _coursesBusinessLogic;

        public CoursesController(ICoursesBusinessLogic coursesService)
        {
            _coursesBusinessLogic = coursesService;
        }

        [HttpGet]
        [Route("GetAllCourses")]
        [SwaggerOperation(Tags = new[] { "GET Courses" },
            Summary = "Get All Courses",
            Description = "This endpoint is used to retrive all the courses available")]
        public IActionResult GetAllCourses()
        {
            var courses = _coursesBusinessLogic.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "GET Courses" }, Description = "This endpoint is used to retrive course by id")]
        public IActionResult GetCourseById(int id)
        {
            return Ok();
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "POST/PUT Operations" }, Description = "This endpoint is used to add new course")]
        public IActionResult AddCourse(CourseDto course)
        {
            return Ok(_coursesBusinessLogic.AddCourse(course));
        }

        [HttpPut]
        [SwaggerOperation(Tags = new[] { "POST/PUT Operations" }, Description = "This endpoint is used to update exitsting course")]
        public IActionResult UpdateCourse(int id, CourseDto course)
        {
            return Ok(_coursesBusinessLogic.UpdateCourse(id, course));
        }

        [HttpDelete]
        [SwaggerOperation(Tags = new[] { "POST/PUT Operations" }, Description = "This endpoint is used to delete exitsting course")]
        public IActionResult DeleteCourse(int id)
        {
            _coursesBusinessLogic.DeleteCourse(id);
            return Ok();
        }
    }
}
