using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Registration.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Web.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ILogger<RegistrationService> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;
        public RegistrationService(ILogger<RegistrationService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("RegistrationAPIUrl");
        }

        public async Task<bool> AddRegistration(RegistrationViewModel Request)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Request), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "Registration";

                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public async Task<bool> DeleteRegistration(int ID)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(ID), Encoding.UTF8, "application/json");

                var Response = await client.DeleteAsync("Registration/" + ID);

                if (Response.IsSuccessStatusCode)
                {
                }
                else
                {
                }
                return true;
            }
        }

        public async Task<RegistrationViewModel> GetRegistrationDetails(int ID)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(""), Encoding.UTF8, "application/json");

                RegistrationViewModel contact = null;
                var Response = await client.GetAsync("Registration/" + ID);

                if (Response.IsSuccessStatusCode)
                {
                    var readTask = Response.Content.ReadAsAsync<RegistrationViewModel>();
                    readTask.Wait();
                    contact = readTask.Result;
                }
                else
                {
                }
                return contact;

            }
        }

        public async Task<List<RegistrationViewModel>> GetRegistrationList(string search)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);

                List<RegistrationViewModel> contacts = null;
                var Response = await client.GetAsync("Registration");

                if (Response.IsSuccessStatusCode)
                {
                    var readTask = Response.Content.ReadAsAsync<List<RegistrationViewModel>>();
                    readTask.Wait();
                    contacts = readTask.Result;
                }
                else
                {

                }
                return contacts;

            }
        }

        public async Task<bool> UpdateRegistration(RegistrationViewModel Request)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(Request), Encoding.UTF8, "application/json");
                    string endpoint = apiBaseUrl + "Registration";
                    using (var Response = await client.PutAsync(endpoint, content))
                    {
                        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
