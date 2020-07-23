using PlaneBooking.Database.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaneBooking.Web.Services.Contracts
{
    public interface ITutorService
    {

        Task Post(TutorViewModel model);

        Task<IEnumerable<TutorViewModel>> GetList();

        Task<TutorViewModel> GetById(int id);
    }
}
