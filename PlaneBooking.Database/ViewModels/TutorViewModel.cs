using PlaneBooking.Database.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneBooking.Database.ViewModels
{
    public class TutorViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public IEnumerable<TutorAvailability> Availabilities { get; set; }
    }
}
