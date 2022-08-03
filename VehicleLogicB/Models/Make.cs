using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleLogicB.Models
{
    [Table("Makes")]
    public class Make
    {
        [Key]
        public int Id  { get; set; }
        public string? make { get; set; }

        public ICollection<Model>? Models { get; set; }

        
    }
}
