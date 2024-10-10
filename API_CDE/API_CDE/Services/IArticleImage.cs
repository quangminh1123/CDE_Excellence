using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IArticleImage
    {
        public IEnumerable<ArticleImage> ArticleImageList();
        public ArticleImage Add(IFormFile image, int idCreator);
        public string Delete(int id);

    }
}
