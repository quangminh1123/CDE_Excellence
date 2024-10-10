using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class VisitSchedule
    {
        [Key]
        public int IdViSc { get; set; }

        [Required, MaxLength(100)]
        public string Session {  get; set; }

        [Required,MaxLength(200)]
        public string Purpose { get; set; }

        [Required, MaxLength(100)]
        public string Status {  get; set; }

        public int? IdDistributor { get; set; }

        public int IdCreator { get; set; }

        public Distributor? Distributor {  get; set; }
        public Account? Account { get; set; }
        public ICollection<DateVisit>? dateVisits { get; set; }
        public ICollection<Job>? jobs { get; set; }
        public ICollection<Visitor>? visitors { get; set; }
    }
}
