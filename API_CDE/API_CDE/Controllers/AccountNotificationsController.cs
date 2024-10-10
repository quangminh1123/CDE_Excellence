using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountNotificationsController : ControllerBase
    {
        private readonly IAccountNotification accountNotification;
        public AccountNotificationsController(IAccountNotification accountNotification)
        {
            this.accountNotification = accountNotification;
        }

        [HttpPost]
        public ActionResult Add(int idNoti, int idReceiver)
        {
            var acNo = accountNotification.Add(idNoti, idReceiver);
            if (acNo == null)
                return BadRequest();
            return Ok(acNo);
        }
    }
}
