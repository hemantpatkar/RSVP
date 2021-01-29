using Registration.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Web.Service
{
    public interface IRegistrationService
    {
        Task<List<RegistrationViewModel>> GetRegistrationList(string search);
        Task<RegistrationViewModel> GetRegistrationDetails(int ID);
        Task<bool> AddRegistration(RegistrationViewModel Request);
        Task<bool> UpdateRegistration(RegistrationViewModel Request);
        Task<bool> DeleteRegistration(int ID);
    }
}
