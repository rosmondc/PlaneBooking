using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneBooking.Database.Models
{
    public class Airport : BaseModel
    {
        [StringLength(100)]
        public string Location { get; set; }

        public IEnumerable<Plane> Planes { get; set; }
    }
}
