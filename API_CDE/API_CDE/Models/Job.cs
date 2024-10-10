using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class Job
    {
        [Key]
        public int IdJob { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Describe { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Required,MaxLength(100)]
        public string Status { get; set; }

        public int IdViSc {  get; set; }

        public int IdImplementer {  get; set; }

        public int IdCreator { get; set; }

        public VisitSchedule? VisitSchedule { get; set; }
        public Account? Implementer {  get; set; }
        public Account? Creator { get; set; }
        public ICollection<JobImage>? JobImages { get; set; }
    }
}
