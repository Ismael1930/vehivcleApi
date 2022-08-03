using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleLogicB.Models
{
    [Table("Models")]
    public class Model
    {
        [Key]
        public int Id { get; set; }
        public string? model { get; set; }

        [ForeignKey("Make")]
        public int MakeId { get; set; }
        public Make? Make { get; set; }
    }
}
