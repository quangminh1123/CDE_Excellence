using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class Question
    {
        [Key]
        public int IdQuestion { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Content { get; set; }

        public bool IsMultipleChoice { get; set; } = false;

        public int IdSuAr {  get; set; }

        public SurveyArticle? SurveyArticle { get; set; }
        public ICollection<AccountAnswer>? accountAnswers { get; set; }
        public ICollection<Answer>? answers { get; set; }
    }
}
