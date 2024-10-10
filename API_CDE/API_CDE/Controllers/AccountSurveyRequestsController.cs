using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSurveyRequestsController : ControllerBase
    {
        public readonly IAccountSurveyRequest accountSurveyRequest;
        public AccountSurveyRequestsController(IAccountSurveyRequest accountSurveyRequest)
        {
            this.accountSurveyRequest = accountSurveyRequest;
        }

        [HttpGet]
        public ActionResult Get() {
            return Ok(accountSurveyRequest.List());
        }

        [HttpPost]
        public ActionResult Add(int idSurveyRequest, int idAccount)
        {
            var acSuRe = accountSurveyRequest.Add(idSurveyRequest, idAccount);
            if (acSuRe == null)
                return BadRequest();
            return CreatedAtAction("Add",acSuRe);
        }
    }
}
