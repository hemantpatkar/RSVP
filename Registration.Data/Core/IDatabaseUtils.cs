using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Registration.Data.Core
{
    public interface IDatabaseUtils
    {

        Task<DbDataReader> ExecuteDataReaderAsync(String CommandText, CommandType type, Dictionary<string, string> parameters);
        DbDataReader ExecuteDataReader(String CommandText, CommandType type, Dictionary<string, string> parameters);
        Task<DataSet> ExecuteDataSetAsync(String CommandText, CommandType type, Dictionary<string, string> parameters);

    }
}
