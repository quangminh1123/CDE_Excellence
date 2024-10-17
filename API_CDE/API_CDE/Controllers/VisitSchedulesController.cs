using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitSchedulesController : ControllerBase
    {
        private readonly IVisitSchedule visitSchedule;
        public VisitSchedulesController(IVisitSchedule visitSchedule)
        {
            this.visitSchedule = visitSchedule;
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(visitSchedule.VisitScheduleList());
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(visitSchedule.GetVisitSchedule(id));
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpPost]
        public ActionResult Add(string session, string purpose, int idDistributor, int idCreator)
        {
            var viSc = visitSchedule.Add(session, purpose, idDistributor, idCreator);
            if (viSc == null)
                return BadRequest();
            return CreatedAtAction("Add",viSc);
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("Search")]
        public ActionResult Search(DateTime startDate, DateTime endDate, string status, int idDistributor)
        {
            return Ok(visitSchedule.Search(startDate, endDate,status,idDistributor));
        }
    }
}
