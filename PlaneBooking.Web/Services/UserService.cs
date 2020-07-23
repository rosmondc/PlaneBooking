using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlaneBooking.Database.ViewModels;
using PlaneBooking.Web.Helper;
using PlaneBooking.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaneBooking.Web.Services
{
    public class UserService : IUserService
    {
        private HttpClient client;

        public UserService(IConfiguration configuration)
        {
            client = new APIHelper(configuration).Initial();
        }

        public async Task Login(UserViewModel model)
        {
            HttpResponseMessage response = await client.GetAsync($"api/authentication/login/{model.Email}/{model.Password}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;                
            }
        }
    }
}
