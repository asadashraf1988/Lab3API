using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab3Controller : ControllerBase
    {
        private static List<Lab3> users = new List<Lab3>
            {
                new Lab3 { studentId = 8864578, name = "Asad" },
                new Lab3 { studentId = 8864000, name = "Dummy" }
            };

        // 1. Get All Users (Get)
        [HttpGet]
        public async Task<ActionResult<List<Lab3>>> Get()
        {
            return Ok(users);
        }

        // 2. Get a user detail by providing user ID (Get)
        [HttpGet("userDetailById")]
        public async Task<ActionResult<Lab3>> Get(int userDetailById)
        {
            var user = users.Find(i => i.studentId == userDetailById);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            else
            {
                return Ok(user);
            }
        }

        // 3. Add a new user (Post)
        [HttpPost]
        public async Task<ActionResult<List<Lab3>>> AddUser(Lab3 user)
        {
            users.Add(user);
            return Ok(user);
        }

        // 4. Update existing user (Put) 


    }
}
