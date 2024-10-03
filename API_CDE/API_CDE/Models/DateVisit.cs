using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class DateVisit
    {
        [Key]
        public int IdDaVi { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date {  get; set; }

        public int IdViSc { get; set; }

        public VisitSchedule? VisitSchedule { get; set; }
    }
}
