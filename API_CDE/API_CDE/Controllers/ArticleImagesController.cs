using API_CDE.Services;
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

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(articleImage.ArticleImageList());
        }

        [HttpPost]
        public ActionResult Add(IFormFile image, int idCreator)
        {
            var arIm = articleImage.Add(image, idCreator);
            if (arIm == null)
                return BadRequest();
            return CreatedAtAction("Add", arIm);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            string arIm = articleImage.Delete(id);
            if (arIm == "Delete Success")
                return NoContent();
            return BadRequest(arIm);
        }
    }
}
