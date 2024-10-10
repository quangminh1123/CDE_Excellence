using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitor visitor;
        public VisitorsController(IVisitor visitor)
        {
            this.visitor = visitor;
        }

        [HttpGet("{idVisitSchedule}")]
        public ActionResult GetByIdViSc(int idVisitSchedule)
        {
            return Ok(visitor.GetVisitorByIdViSc(idVisitSchedule));
        }

        [HttpPost]
        public ActionResult Add(int idAccount, int idVisitSchedule)
        {
            var vis = visitor.Add(idAccount, idVisitSchedule);
            if (vis == null)
                return BadRequest();
            return CreatedAtAction("Add", vis);
        }
    }
}
