using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyArticlesController : ControllerBase
    {
        private readonly ISurveyArticle surveyArticle;
        public SurveyArticlesController(ISurveyArticle surveyArticle)
        {
            this.surveyArticle = surveyArticle;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(surveyArticle.SuArList());
        }

        [HttpGet("{id}")]
        public ActionResult GetId(int id)
        {
            return Ok(surveyArticle.GetById(id));
        }

        [HttpPost]
        public ActionResult Add(string title, int idCreator, string status)
        {
            var suAr = surveyArticle.AddSuAr(title, idCreator, status);
            if (suAr == null)
                return BadRequest();
            return CreatedAtAction("Add", suAr);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, string title, string status)
        {
            var suAr = surveyArticle.UpdateSuAr(id, title, status);
            if (suAr == null)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            string suAr = surveyArticle.DeleteSuAr(id);
            if (suAr == "Delete Success")
                return NoContent();
            return BadRequest(suAr);
        }
    }
}
