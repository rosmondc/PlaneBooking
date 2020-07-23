using AutoMapper;
using PlaneBooking.Database.Models;
using PlaneBooking.Database.ViewModels;

namespace PlaneBooking.DataAccess
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tutor, TutorViewModel>();
            CreateMap<Plane, PlaneViewModel>();
            CreateMap<Tutor, AirportViewModel>();
        }
    }
}
