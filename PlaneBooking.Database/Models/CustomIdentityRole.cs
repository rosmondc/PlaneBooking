using Microsoft.AspNetCore.Identity;

namespace PlaneBooking.Database.Models
{
    public class CustomIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
