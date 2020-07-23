using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace PlaneBooking.Web.Helper
{
    public class APIHelper
    {
        private IConfiguration _configuration;
        public APIHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HttpClient Initial() 
        {
            var client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:5001");
            client.BaseAddress = new Uri(_configuration.GetValue<string>("PlaneBookingAPIUrl"));
            return client;
        }
    }
}
