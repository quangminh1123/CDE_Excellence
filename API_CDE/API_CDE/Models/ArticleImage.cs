using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class ArticleImage
    {
        [Key]
        public int IdArIm { get; set; }

        [Required, MaxLength(100)]
        public string Image {  get; set; }

        public int IdManager { get; set; }

        public Account? Account { get; set; }
    }
}
