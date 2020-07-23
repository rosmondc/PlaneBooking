using PlaneBooking.Database.ViewModels;
using System.Threading.Tasks;

namespace PlaneBooking.Web.Services.Contracts
{
    public interface IUserService
    {
        Task Login(UserViewModel model);
    }
}
