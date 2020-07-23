using System;

namespace PlaneBooking.Database.Models
{
    public class PlaneDeparture : BaseModel
    {        
        public DateTime Departure { get; set; }

        public int PlaneId { get; set; }
        
        public Plane Plane { get; set; }
    }
}
