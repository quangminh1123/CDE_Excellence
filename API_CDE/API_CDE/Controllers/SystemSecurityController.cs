using API_CDE.Models;
using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSecurityController : ControllerBase
    {
        private readonly ISystemSecurity systemSecurity;
        public SystemSecurityController(ISystemSecurity systemSecurity)
        {
            this.systemSecurity = systemSecurity;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            var acc = systemSecurity.Login(email, password);
            return Ok(acc);
        }
    }
}
