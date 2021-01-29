using Microsoft.AspNetCore.Mvc;
using Registration.Entities;
using Registration.Repo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }


        // GET: api/Registration
        [HttpGet]
        public async Task<IEnumerable<Register>> Get(string search = "")
        {
            if (search == null)
                search = "";
            return await _registrationRepository.GetRegistrationList(search);
        }


        // GET: api/Registration/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Register> Get(int id)
        {
            return await _registrationRepository.GetRegistrationDetails(id);
        }

        // POST: api/Registration
        [HttpPost]
        public async Task<bool> Post([FromBody] Register value)
        {
            return await _registrationRepository.AddRegistration(value);
        }

        // PUT: api/Registration/5
        [HttpPut]
        public async Task<bool> Put([FromBody] Register value)
        {
            return await _registrationRepository.UpdateRegistration(value);
        }

        // Delete: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _registrationRepository.DeleteRegistration(id);
        }

    }
}