using API_CDE.Models;
using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationSecurityController : ControllerBase
    {
        private readonly IAuthenticationSecurity security;
        public AuthenticationSecurityController(IAuthenticationSecurity security)
        {
            this.security = security;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            var acc = security.Login(email, password);
            return Ok(acc);
        }

        [Authorize(Roles = "Owner,Admin,User")]
        [HttpPut("ChangePassword/{idAccount}")]
        public ActionResult ChangePassword(int idAccount, string password)
        {
            var acc = security.ChangePassword(idAccount, password);
            if (acc == "Update Success")
                return Ok();
            return BadRequest(acc);
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpPut("ResetPassword/{idAccount}")]
        public ActionResult ResetPassword(int idAccount)
        {
            var acc = security.ResetPassword(idAccount);
            if (acc == "Update Success")
                return Ok();
            return BadRequest(acc);
        }

    }
}
