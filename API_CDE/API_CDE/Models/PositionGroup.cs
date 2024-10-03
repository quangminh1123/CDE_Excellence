using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_CDE.Models
{
    public class PositionGroup
    {
        [Key]
        public int IdPoGr { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        public ICollection<Position>? positions { get; set; }
    }
}
