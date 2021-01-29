using Microsoft.Extensions.DependencyInjection;
using Registration.Data;
using Registration.Data.Master;
using Registration.Entities;
using Registration.Repo;

namespace Registration.API.CompositeRoots
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDependancyMapper(this IServiceCollection services)
        {
            // add dapper configuration
            //DataAccess.Maps.DapperConfiguration.Initalize();

            services.AddSingleton<IConnectionStrings, ConnectionStrings>();           
            services.AddSingleton<IMasterDatabaseUtils, MasterDatabaseUtils>();
            services.AddSingleton<IRegistrationDal, RegistrationDal>();            
            services.AddSingleton<IRegistrationRepository, RegistrationRepository>();

            return services;
        }
    }
}
