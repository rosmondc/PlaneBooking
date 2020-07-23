using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Database.Models;

namespace PlaneBooking.Database
{
    public class PlaneBookingContext : IdentityDbContext
    {
        public PlaneBookingContext(DbContextOptions<PlaneBookingContext> options)
                :base(options)
        {

        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneDeparture> PlaneDepartures { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<TutorAvailability> TutorAvailabilities { get; set; }


        public DbSet<CustomIdentityRole> CustomIdentityRoles { get; set; }
    }
}
