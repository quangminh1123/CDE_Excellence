using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_CDE.Models
{
    public class Distributor
    {
        [Key]
        public int IdDis { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public int? IdArea { get; set; }
       
        public int? IdManager { get; set; }

        [Required, MaxLength(100)]
        public string Status { get; set; }

        public Area? Area { get; set; }
        public Account? Account { get; set; }
        public ICollection<Account>? accounts { get; set; }
        public ICollection<VisitSchedule>? visitSchedules { get; set; }
    }
}
