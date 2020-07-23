using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlaneBooking.Database.ViewModels;
using PlaneBooking.Web.Helper;
using PlaneBooking.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaneBooking.Web.Services
{
    public class TutorService : ITutorService
    {
     
        private HttpClient client;

        public TutorService(IConfiguration configuration)
        {
            client = new APIHelper(configuration).Initial();
        }

        public Task<TutorViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TutorViewModel>> GetList()
        {
            HttpResponseMessage response = await client.GetAsync("api/tutor");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var tutors = JsonConvert.DeserializeObject<IEnumerable<TutorViewModel>>(result);
                return tutors;
            }
            return null;

        }

        public async Task Post(TutorViewModel model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/tutor", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
