using Registration.Data;
using Registration.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Repo
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IRegistrationDal _registrationDal;
        public RegistrationRepository(IRegistrationDal registrationDal)
        {
            _registrationDal = registrationDal;
        }
        public async Task<bool> AddRegistration(Register Request)
        {
            return await _registrationDal.AddRegistration(Request);
        }

        public async Task<bool> DeleteRegistration(int ID)
        {
            return await _registrationDal.DeleteRegistration(ID);
        }

        public async Task<Register> GetRegistrationDetails(int ID)
        {
            return await _registrationDal.GetRegistrationDetails(ID);
        }

        public async Task<List<Register>> GetRegistrationList(string search)
        {
            return await _registrationDal.GetRegistrationList(search);
        }

        public async Task<bool> UpdateRegistration(Register Request)
        {
            return await _registrationDal.UpdateRegistration(Request);
        }
    }
}
