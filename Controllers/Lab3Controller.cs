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
        private readonly DataContext context;

        public Lab3Controller(DataContext context) {
            this.context = context;
        }

        // 1. Get All Users (Get)
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<Lab3>>> Get()
        {
            return Ok(await context.Lab3Users.ToListAsync());
        }

        // 2. Get a user detail by providing user ID (Get)
        [HttpGet("GetUserDetailById")]
        public async Task<ActionResult<Lab3>> Get(int userDetailById)
        {
            var user = await context.Lab3Users.FindAsync(userDetailById);
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
        [HttpPost("AddUser")]
        public async Task<ActionResult<List<Lab3>>> AddUser(Lab3 user)
        {
            context.Lab3Users.Add(user);
            await context.SaveChangesAsync();
            return Ok(await context.Lab3Users.ToListAsync());
        }

        // 4. Update existing user (Put) 
        [HttpPut("UapdateUserById")]
        public async Task<ActionResult<List<Lab3>>> UpdateUser(Lab3 updateRequest)
        {
            var user = await context.Lab3Users.FindAsync(updateRequest.studentId);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            else
            {
                user.name = updateRequest.name;
                await context.SaveChangesAsync();

                return Ok(await context.Lab3Users.ToListAsync());
            }
        }

    }
}
