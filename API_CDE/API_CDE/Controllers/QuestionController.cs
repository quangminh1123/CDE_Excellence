using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestion question;
        public QuestionController(IQuestion question)
        {
            this.question = question;
        }

        [HttpGet("BySuveyArticle/{idSurveyArticle}")]
        public ActionResult GetByIdSurAr(int idSurveyArticle)
        {
            return Ok(question.GetQuestionsByIdSuAr(idSurveyArticle));
        }

        [HttpGet("{idQuestion}")]
        public ActionResult GetQuestion(int idQuestion)
        {
            return Ok(question.GetQuestion(idQuestion));
        }

        [HttpPost]
        public ActionResult Add(string content, bool isMultipleChoice, int idSuAr)
        {
            var ques = question.AddQuestion(content, isMultipleChoice, idSuAr);
            if (ques == null)
                return BadRequest();
            return CreatedAtAction("Add", ques);
        }

        [HttpPut]
        public ActionResult Update(int id, string content, bool isMultipleChoice)
        {
            var ques = question.UpdateQuestion(id, content, isMultipleChoice);
            if (ques == null)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            string ques = question.DeleteQuestion(id);
            if (ques == "Delete Success")
                return NoContent();
            return BadRequest(ques);
        }
    }
}
