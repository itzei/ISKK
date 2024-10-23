using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReactWithAsp.Server.Data.Consts;
using ReactWithAsp.Server.Services;

namespace ReactWithAsp.Server.Controllers.Admin
{

    [ApiController]
    [Route("api/admin/[controller]")]
    [Authorize (Roles = UserRoles.Admin)]

    public class DashboardController(IGetIdentityUserService getIdentityUserService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await getIdentityUserService.GetAll();
            return Ok(results);
        }
    }
}
