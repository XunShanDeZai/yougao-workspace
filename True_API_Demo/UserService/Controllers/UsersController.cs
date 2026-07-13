using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new[] { new { Id = 1, Name = "Alice" }, new { Id = 2, Name = "Bob" } });

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(new { Id = id, Name = "User " + id });
    }
}
