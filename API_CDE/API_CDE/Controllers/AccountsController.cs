using API_CDE.Models;
using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccount account;
        public AccountsController(IAccount account)
        {
            this.account = account;
        }

        [HttpGet]
        public ActionResult GetUser()
        {
            return Ok(account.UserList());
        }

        [HttpPost]
        [Route("AddUser")]
        public ActionResult AddUser(string fullName, string email, int? idPosition, string status)
        {
            var addUser = account.AddUser(fullName, email, idPosition, status);
            if (addUser == null)
                return BadRequest();
            return CreatedAtAction("AddUser", addUser);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, string fullName, string email, int? idPosition, string status)
        {
            var acc = account.UpdateUser(id, fullName, email, idPosition, status);
            if (acc == null)
                return BadRequest();
            return Ok(acc);
        }
    }
}
