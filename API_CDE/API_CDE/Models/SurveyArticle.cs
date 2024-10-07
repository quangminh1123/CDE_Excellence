using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class SurveyArticle
    {
        [Key]
        public int IdSuAr {  get; set; }

        [Required]
        public string Title { get; set; }

        public int IdCreator { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required, MaxLength(100)]
        public string Status { get; set; }

        public Account? Account { get; set; }
        public ICollection<Question>? questions { get; set; }
        public ICollection<SurveyRequest>? surveyRequests { get; set; }
    }
}
