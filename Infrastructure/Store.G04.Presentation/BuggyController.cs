using Microsoft.AspNetCore.Mvc;

namespace Store.G04.Presentation
{
    [ApiController]
    [Route("api/[controller]")]

    public class BuggyController : ControllerBase
    {
        [HttpGet("notfound")] // GET: api/Buggy/notfound
        public IActionResult GetNotFoundRequest()
        {
            // Code
            return NotFound(); // 404
        }

        [HttpGet("servererror")] // GET: api/Buggy/servererror
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception();
            return Ok();
        }

        [HttpGet(template: "badrequest")] // GET: api/Buggy/badrequest
        public IActionResult GetBadTRequest()
        {
            return BadRequest();//400
        }

        [HttpGet(template: "badrequest/{id}/{age}")] // GET: api/Buggy/badrequest/ahmed
        public IActionResult GetBadTRequest(int id, int age) // validation erroe
        {
            return BadRequest();//400
        }

        [HttpGet(template: "unauthorized")] // GET: api/Buggy/unauthorized
        public IActionResult GetUnauthorizedRequest()
        {
            return Unauthorized();//401
        }


    }
}