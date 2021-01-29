using System.Data.SqlClient;
namespace Registration.Data.Core
{
    public class SqlDataUtils : DatabaseUtils
    {
        public SqlDataUtils(string connectionString) : base(SqlClientFactory.Instance, connectionString)
        {

        }
    }
}
