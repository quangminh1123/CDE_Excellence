using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class Article
    {
        [Key]
        public int IdArticle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Describe { get; set; }

        [Required, Column(TypeName = "varchar(120)")]
        public string PathArticle { get; set; }

        [Required]
        public string Image { get; set; }

        public int IdCreator { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required, MaxLength(100)]
        public string Status { get; set; }

        public Account? Account { get; set; }
    }
}
