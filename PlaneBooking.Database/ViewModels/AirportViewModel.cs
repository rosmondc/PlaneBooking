using PlaneBooking.Database.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneBooking.Database.ViewModels
{
    public class AirportViewModel
    {
        [Required]
        public string Description { get; set; }
        public IEnumerable<Plane> Planes { get; set; }
    }
}
