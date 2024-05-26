using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            string[] studentNames = new string[] { "Swag", "Bob", "Charlie", "Doggy", "Elise", "Fox" };

            return Ok(studentNames);

        }

    }
}
