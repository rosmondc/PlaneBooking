using PlaneBooking.Database.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneBooking.Database.ViewModels
{
    public class PlaneViewModel
    {
        [Required]
        public string Description { get; set; }
        public IEnumerable<PlaneDeparture> PlaneDepartures { get; set; }
    }
}
