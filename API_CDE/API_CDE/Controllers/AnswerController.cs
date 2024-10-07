using API_CDE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswer answer;
        public AnswerController(IAnswer answer)
        {
            this.answer = answer;
        }

        [HttpGet("{idQuestion}")]
        public ActionResult GetAnswersByIdQuestion(int idQuestion)
        {
            return Ok(answer.GetAnsersByIdQuestion(idQuestion));
        }

        [HttpPost]
        public ActionResult Add(string content, int idQuestion)
        {
            var ans = answer.AddAnswer(content, idQuestion);
            if (ans == null)
                return BadRequest();
            return Ok(ans);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, string content)
        {
            var ans = answer.UpdateAnswer(id, content);
            if (ans == null)
                return BadRequest();
            return Ok(ans);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ans = answer.DeleteAnswer(id);
            if (ans == "Delete Success")
                return NoContent();
            return BadRequest();
        }
    }
}
