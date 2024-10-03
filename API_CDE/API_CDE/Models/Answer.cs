using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class Answer
    {
        [Key]
        public int IdAnswer { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Content { get; set; }

        public int IdQuestion { get; set; }

        public Question? Question { get; set; }
        public ICollection<AccountAnswer>? accountAnswers { get; set; }
    }
}
