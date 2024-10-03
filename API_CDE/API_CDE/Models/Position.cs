using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace API_CDE.Models
{
    public class Position
    {
        [Key]
        public int IdPos { get; set; }

        [Required, MaxLength(150)]
        public string PositionName { get; set; }

        public int IdPoGr {  get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public PositionGroup? positionGroup { get; set; }
        public ICollection<Account>? accounts { get; set; }
    }
}
