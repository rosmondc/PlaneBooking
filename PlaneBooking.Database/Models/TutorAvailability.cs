using System;

namespace PlaneBooking.Database.Models
{
    public class TutorAvailability : BaseModel
    {        
        public DateTime ScheduleDate { get; set; }

        public int TutorId { get; set; }

        public Tutor Tutor { get; set; }
    }
}
