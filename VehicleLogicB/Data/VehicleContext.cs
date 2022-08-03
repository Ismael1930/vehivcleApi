using Microsoft.EntityFrameworkCore;
using VehicleLogicB.Models;

namespace VehicleLogicB.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {

        }

        public DbSet<Car>? Cars  { get; set; }
        public DbSet<Make>? Makes { get; set; }
        public DbSet<Model>? Models { get; set; }

    }
}
