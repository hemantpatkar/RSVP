using Microsoft.Extensions.Options;
using Registration.Data.Core;
using Registration.Entities;

namespace Registration.Data.Master
{
    public class MasterDatabaseUtils : SqlDataUtils, IMasterDatabaseUtils
    {
        //private readonly IConnectionStrings _connectionString;

        public MasterDatabaseUtils(IOptions<ConnectionStrings> connectionString)
            : base(connectionString.Value.MasterConnection)
        {
            //_connectionString = connectionString.Value;
        }
    }
}
