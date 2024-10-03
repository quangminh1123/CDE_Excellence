using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class AccountAnswer
    {
        [Key]
        public int IdUsAn { get; set; }

        public int IdQuestion { get; set; }

        public int IdAnswer { get; set; }

        public int IdAcc { get; set; }

        public Question? Question { get; set; }
        public Answer? Answer { get; set; }
        public Account? Account { get; set; }

    }
}
