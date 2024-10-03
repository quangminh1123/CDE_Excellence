using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }

        public int IdAcc { get; set; }

        public int IdViSc { get; set; }

        public Account? Account { get; set; }
        public VisitSchedule? VisitSchedule { get; set; }
    }
}
