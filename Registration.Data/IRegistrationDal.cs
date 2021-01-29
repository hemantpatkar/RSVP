using Registration.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Data
{
    public interface IRegistrationDal
    {
        Task<List<Register>> GetRegistrationList(string search);
        Task<Register> GetRegistrationDetails(int ID);
        Task<bool> AddRegistration(Register Request);
        Task<bool> UpdateRegistration(Register Request);
        Task<bool> DeleteRegistration(int ID);
    }
}
