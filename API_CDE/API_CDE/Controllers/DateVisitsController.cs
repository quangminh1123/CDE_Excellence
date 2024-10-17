using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateVisitsController : ControllerBase
    {
        private readonly IDateVisit dateVisit;
        public DateVisitsController(IDateVisit dateVisit)
        {
            this.dateVisit = dateVisit;
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("{idVisitSchedule}")]
        public ActionResult GetByIdViSc(int idVisitSchedule)
        {
            return Ok(dateVisit.dateVisitByIdViSc(idVisitSchedule));
        }

        //[Authorize(Roles = "Owner,Admin,User")]
        [HttpPost]
        public ActionResult Add(DateTime date, int idVisitSchedule)
        {
            var daVi = dateVisit.Add(date, idVisitSchedule);
            if (daVi == null)
                return BadRequest();
            return CreatedAtAction("Add", daVi);
        }

    }
}
