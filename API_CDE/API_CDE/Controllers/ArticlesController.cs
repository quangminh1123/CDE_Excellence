using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticle article;
        public ArticlesController(IArticle article)
        {
            this.article = article;
        }

        [Authorize(Roles = "Owner")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(article.ArticleList());
        }

        [Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("{id}")]
        public ActionResult Get(int id) {
            return Ok(article.GetArticle(id));
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public ActionResult Add(string title, string descibe, string path, IFormFile image, int idCreator)
        {
            var ar = article.Add(title, descibe, path, image, idCreator);
            if (ar == null)
                return BadRequest();
            return CreatedAtAction("Add", ar);
        }

        [Authorize(Roles = "Owner")]
        [HttpPut("{id}")]
        public ActionResult Update(int id, string title, string descibe, string path, IFormFile image)
        {
            var ar = article.UpdateAriticle(id, title, descibe, path, image);
            if (ar == null)
                return BadRequest();
            return Ok(ar);
        }

        [Authorize(Roles = "Owner")]
        [HttpPut("UpdateStatus/{id}")]
        public ActionResult Update(int id, string status)
        {
            var ar = article.UpdateStatusAr(id, status);
            if (ar == null)
                return BadRequest();
            return Ok(ar);
        }

        [Authorize(Roles = "Owner")]
        [HttpDelete]
        public ActionResult Delete(int id) {
            var ar = article.Delete(id);
            if (ar == "Delete Success")
                return NoContent();
            return BadRequest(ar);
        }
    }
}
