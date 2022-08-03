using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleLogicB.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("yyyy");

        [ForeignKey("Make")]
        public int MakeId { get; set; }
        public Make? Make { get; set; }

    }
}
