using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotification notification;
        public NotificationsController(INotification notification)
        {
            this.notification = notification;
        }

        [HttpGet("ByCreator/{idCreator}")]
        public ActionResult GetByIdCreator(int idCreator)
        {
            return Ok(notification.GetByIdAccount(idCreator));
        }

        [HttpGet("{idNoti}")]
        public ActionResult GetNoti(int idNoti)
        {
            return Ok(notification.GetNotification(idNoti));
        }

        [HttpPost]
        public ActionResult Add(string title, string content, int idCreator, string status)
        {
            var noti = notification.AddNotification(title, content, idCreator, status);
            if (noti == null)
                return BadRequest();
            return CreatedAtAction("Add", noti);
        }
    }
}
