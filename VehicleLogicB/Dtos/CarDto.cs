namespace VehicleLogicB.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("yyyy");
        public int MakeId { get; set; }
        
    }
}
