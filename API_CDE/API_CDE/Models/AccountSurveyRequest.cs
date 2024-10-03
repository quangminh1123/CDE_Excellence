using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class AccountSurveyRequest
    {
        [Key]
        public int IdAcSu {  get; set; }

        public int IdSuRe {  get; set; }

        public int IdAcc { get; set; }

        public SurveyRequest? SurveyRequest { get; set; }
        public Account? Account { get; set; }
    }
}
