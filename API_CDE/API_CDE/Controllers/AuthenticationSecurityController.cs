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
            try
            {
                var token = security.Login(email, password);
                return Ok(token);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangePassword/{idAccount}")]
        public ActionResult ChangePassword(int idAccount, string password)
        {
            try
            {
                var acc = security.ChangePassword(idAccount, password);
                if (acc == "Update Success")
                    return Ok();
                return BadRequest(acc);
            }
            catch (Exception)
            {
                return BadRequest("Cannot change password");
            }
        }

        [Authorize(Roles = "Owner,Admin")]
        [HttpPut("ResetPassword/{idAccount}")]
        public ActionResult ResetPassword(int idAccount)
        {
            try
            {

                if (!User.Identity.IsAuthenticated)
                {
                    return Unauthorized(new { message = "You are not logged in. Please login to continue." });
                }
                var acc = security.ResetPassword(idAccount);
                if (acc == "Update Success")
                    return Ok();
                return BadRequest(acc);
            }
            catch (Exception)
            {

                return BadRequest("Cannot reset password");
            }
        }

    }
}
