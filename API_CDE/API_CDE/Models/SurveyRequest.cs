using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class SurveyRequest
    {
        [Key]
        public int IdSuRe { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        public int IdCreator {  get; set; }

        public int IdSuAr {  get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public Account? Account { get; set; }
        public SurveyArticle? SurveyArticle { get; set; }
        public ICollection<AccountSurveyRequest>? accountSurveyRequests { get; set; }
    }
}
