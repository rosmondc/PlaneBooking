using System.Collections.Generic;

namespace PlaneBooking.Database.Models
{
    public class Plane : BaseModel
    {
        public IEnumerable<PlaneDeparture> PlaneDepartures { get; set; }
    }
}
