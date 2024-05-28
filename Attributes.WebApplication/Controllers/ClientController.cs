using Microsoft.AspNetCore.Mvc;

namespace Attributes.WebApplication.Controllers
{
    [ApiController]
    [AuthorizeRole(Role = Roles.Client)]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {   

        public ClientController()
        {
        }

        [HttpPost]
        [AuthorizeRole(Role = Roles.Moderator)]
        public Task<ActionResult<int>> AddUser()
        {
            return Task.FromResult(new ActionResult<int>(1));
        }
    }
}