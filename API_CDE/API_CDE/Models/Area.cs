using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_CDE.Models
{
    public class Area
    {
        [Key]
        public int IdArea { get; set; }

        [Required, Column(TypeName = "varchar(30)")]
        public string AreaCode {  get; set; }

        [Required, MaxLength(150)]
        public string AreaName { get; set; }

        public ICollection<Account>? accounts { get; set; }
        public ICollection<Distributor>? distributors { get; set; }

    }
}
