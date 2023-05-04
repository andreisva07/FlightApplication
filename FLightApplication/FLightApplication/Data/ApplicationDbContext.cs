using Microsoft.EntityFrameworkCore;
using FlightManagement.DataModel;
using FlightManagement.DataAccess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FlightManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext) 
        {

        }
        public DbSet<FlightManagement.DataModel.Flight> Flight { get; set; } = default!;
        public DbSet<FlightManagement.DataModel.Passenger> Passenger { get; set; } = default!;
        public DbSet<FlightManagement.DataModel.TIcket> TIcket { get; set; } = default!;
        public DbSet<FlightManagement.DataModel.Booking> Booking { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
