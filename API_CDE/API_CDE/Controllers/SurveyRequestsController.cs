using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyRequestsController : ControllerBase
    {
        private readonly ISurveyRequest surveyRequest;
        public SurveyRequestsController(ISurveyRequest surveyRequest)
        {
            this.surveyRequest = surveyRequest;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(surveyRequest.SurveyRequestList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(surveyRequest.GetSurveyRequest(id));
        }

        [HttpGet("ByReceiver/{idReceiver}")]
        public ActionResult GetByIdReceiver(int idReceiver) {
            return Ok(surveyRequest.GetByIdReceiver(idReceiver));
        }

        [HttpPost]
        public ActionResult Add(string title, int idCreator, int idSurveyArticle, DateTime startDate, DateTime endDate)
        {
            var suRe = surveyRequest.Add(title, idCreator, idSurveyArticle, startDate, endDate);
            if (suRe == null)
                return BadRequest();
            return CreatedAtAction("Add", suRe);
        }
    }
}
