using System.Collections.Generic;

namespace PlaneBooking.Database.Models
{
    public class Tutor : BaseModel
    {
        public IEnumerable<TutorAvailability> Availabilities { get; set; }
    }
}
