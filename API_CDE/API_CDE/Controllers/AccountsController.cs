using API_CDE.Models;
using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        //[Authorize(Roles = "Owner,Admin")]
        [HttpGet]
        public ActionResult GetUsers(int page = 1)
        {
            int pagesize = 3; //mặc định 3 items trên 1 trang
            var skip = (page - 1) * pagesize;
            var accounts = account.AccountList().Skip(skip).Take(pagesize).ToList();

            if (accounts == null || !accounts.Any())
            {
                return NotFound("Không có dữ liệu");
            }

            var totalItems = account.AccountList().Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pagesize);
            return Ok(accounts);
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("{idAccount}")]
        public ActionResult GetUser(int idAccount)
        {
            return Ok(account.GetAccount(idAccount));
        }

        //[Authorize(Roles = "Owner,Admin")]
        [HttpPost]
        [Route("AddUser")]
        public ActionResult AddUser(string fullName, string email, int? idPosition, string status)
        {
            try
            {
                var add = account.AddUser(fullName, email, idPosition, status);
                return CreatedAtAction("AddUser", add);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                   return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "Owner,Admin")]
        [HttpPut("UpdateUser/{id}")]
        public ActionResult UpdateUser(int id, string fullName, string email, int? idPosition, string status)
        {
            var acc = account.UpdateUser(id, fullName, email, idPosition, status);
            if (acc == null)
                return BadRequest();
            return Ok(acc);
        }

        //[Authorize(Roles = "Owner,Admin")]
        [HttpPost("AddSale")]
        public ActionResult AddSale(string fullName, string email, int idPosition, int idManager, string status)
        {
            var acc = account.AddSale(fullName, email, idPosition, idManager, status);
            if (acc == null)
                return BadRequest();
            return CreatedAtAction("AddSale", acc);
        }

        //[Authorize(Roles = "Owner,Admin")]
        [HttpPut("UpdateSale/{id}")]
        public ActionResult Update(int id, string fullName, string email, int idPosition, int idManager, int? idDistributor, string status)
        {
            var acc = account.UpdateSale(id, fullName, email, idPosition, idManager, idDistributor, status);
            if (acc == null)
                return BadRequest();
            return Ok(acc);
        }

        //[Authorize(Roles = "Owner,Admin")]
        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            string acc = account.Delete(id);
            if (acc == "Delete Success")
                return NoContent();
            return BadRequest(acc);
        }

        //[Authorize(Roles = "Owner,Admin")]
        [HttpPut("AddSubordinate")]
        public ActionResult AddSubordinate(int idAccount, int idManager)
        {
            var acc = account.AddSubordinate(idAccount, idManager);
            if (acc == null)
                return BadRequest();
            return Ok(acc);
        }

        //[Authorize(Roles = "Owner,Admin")]
        [HttpPut("DeleteSubordinate")]
        public ActionResult DeleteSubordinate(int idAccount)
        {
            var acc = account.DeleteSubordinate(idAccount);
            if (acc == null)
                return BadRequest();
            return Ok(acc);
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpPut("UpdateYourInfo")]
        public ActionResult Update(int id, string fullName, string phone, string address)
        {
            var acc = account.UpdateYourInfo(id, fullName, phone, address);
            if (acc == null)
                return BadRequest();
            return Ok(acc);
        }
    }
}
