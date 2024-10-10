using API_CDE.Data;
using API_CDE.Models;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using API_CDE.Controllers;

namespace API_CDE.Services
{
    public class ArticleResponse : IArticle
    {
        private readonly ApplicationDBContext _context;
        public ArticleResponse(ApplicationDBContext context) => _context = context;

        public Article Add(string title, string describe, string path, IFormFile image, int idCreator)
        {
            try
            {
                string imagePath = SaveImage(image);

                var ar = new Article
                {
                    Title = title,
                    Describe = describe,
                    PathArticle = path,
                    Image = $"/Image/SurveyArticle/{imagePath}",
                    IdCreator = idCreator,
                    Status = "Mới"
                };
                _context.Articles.Add(ar);
                _context.SaveChanges();
                return ar;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public IEnumerable<Article> ArticleList()
        {
            return _context.Articles;
        }

        public string Delete(int id)
        {
            try
            {
                var ar = _context.Articles.Find(id);
                if (ar == null)
                    return "Not found";
                _context.Articles.Remove(ar);
                _context.SaveChanges();
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "SurveyArticles", Path.GetFileName(ar.Image));
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
                return "Delete Success";
            }
            catch (Exception)
            {

                return "Not remove";
            }
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.Where(x => x.IdArticle == id).FirstOrDefault();
        }

        public Article UpdateAriticle(int id, string title, string descibe, string path, IFormFile image)
        {
            try
            {
                string imagePath = SaveImage(image);
                var ar = _context.Articles.Find(id);
                if (ar == null)
                    return null;
                var imgOld = Path.Combine(Directory.GetCurrentDirectory(), "Images", "SurveyArticles", Path.GetFileName(ar.Image));
                if (File.Exists(imgOld))
                {
                    File.Delete(imgOld);
                }
                ar.Title = title;
                ar.Describe = descibe;
                ar.PathArticle = path;
                ar.Image = $"/Images/SurveyArticles/{imagePath}";
                _context.SaveChanges();
                return ar;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public Article UpdateStatusAr(int id, string Status)
        {
            try
            {
                var ar = _context.Articles.Find(id);
                if (ar == null)
                    return null;
                ar.Status = Status;
                _context.SaveChanges();
                return ar;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private string SaveImage(IFormFile imageFile)
        {
            if (imageFile == null)
                return null;
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Images/SurveyArticles");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            var filePath = Path.Combine(uploadPath, imageFile.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyToAsync(fileStream);
            }
            return imageFile.FileName;
        }
    }
}
