using API_CDE.Models;
using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        //[Authorize(Roles = "Owner")]
        [HttpGet]
        public ActionResult Get(int page = 1)
        {
            int pagesize = 3; //mặc định 3 items trên 1 trang
            var skip = (page - 1) * pagesize;
            var articles = article.ArticleList().Skip(skip).Take(pagesize).ToList();

            if (articles == null || !articles.Any())
            {
                return NotFound("Không có dữ liệu");
            }

            var totalItems = article.ArticleList().Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pagesize);
            //var result = new
            //{
            //    Page = page,
            //    PageSize = 3,
            //    TotalItems = totalItems,
            //    TotalPages = totalPages,
            //    Items = areas
            //}
            return Ok(articles);
        }

        [Authorize(Roles = "Owner,Admin,User")]
        [HttpGet("{id}")]
        public ActionResult GetId(int id) {
            return Ok(article.GetArticle(id));
        }

        //[Authorize(Roles = "Owner")]
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
