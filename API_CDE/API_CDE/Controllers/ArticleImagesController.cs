using API_CDE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleImagesController : ControllerBase
    {
        private readonly IArticleImage articleImage;
        public ArticleImagesController(IArticleImage articleImage)
        {
            this.articleImage = articleImage;
        }

        [Authorize(Roles = "Owner")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(articleImage.ArticleImageList());
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public ActionResult Add(IFormFile image, int idCreator)
        {
            var arIm = articleImage.Add(image, idCreator);
            if (arIm == null)
                return BadRequest();
            return CreatedAtAction("Add", arIm);
        }

        [Authorize(Roles = "Owner")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            string arIm = articleImage.Delete(id);
            if (arIm == "Delete Success")
                return NoContent();
            return BadRequest(arIm);
        }
    }
}
