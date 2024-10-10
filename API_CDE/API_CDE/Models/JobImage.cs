using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class JobImage
    {
        [Key]
        public int IdJoIm { get; set; }

        [Required]
        public string Image {  get; set; }

        [Required, MaxLength(100)]
        public string Descibe { get; set; }

        public int IdJob { get; set; }
        
        public Job? Job { get; set; }
    }
}
