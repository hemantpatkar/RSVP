using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Registration.Data.Core
{
    public class DatabaseUtils : IDatabaseUtils
    {

        private readonly DbProviderFactory _connectionFactory;
        private readonly string _connectionString;

        public DatabaseUtils(DbProviderFactory connectionFactory, string connectionString)
        {
            _connectionFactory = connectionFactory;
            _connectionString = connectionString;
        }

        public DbDataReader ExecuteDataReader(string CommandText, CommandType type, Dictionary<string, string> parameters)
        {
            var connection = OpenConnection();
            var command = CreateCommand(connection, CommandText, type, CreateParameter(parameters));
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public async Task<DbDataReader> ExecuteDataReaderAsync(String CommandText, CommandType type, Dictionary<string, string> parameters)
        {
            var connection = await OpenConnectionAsync();
            var command = CreateCommand(connection, CommandText, type, CreateParameter(parameters));
            return await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        }

        public async Task<DataSet> ExecuteDataSetAsync(string CommandText, CommandType type, Dictionary<string, string> parameters)
        {
            using (var connection = await OpenConnectionAsync())
            {
                DbTransaction myTransaction = connection.BeginTransaction();
                try
                {
                    using (var command = CreateCommand(connection, CommandText, type, CreateParameter(parameters)))
                    {
                        command.Transaction = myTransaction;
                        DataSet ds = new DataSet();
                        DbDataAdapter da = _connectionFactory.CreateDataAdapter();
                        da.SelectCommand = command;
                        da.Fill(ds);
                        myTransaction.Commit();
                        return ds;
                    }
                }
                catch
                {
                    myTransaction.Rollback();
                    throw;
                }
            }
        }


        private DbCommand CreateCommand(DbConnection connection, string commandText, CommandType commandType,
                                       IEnumerable<DbParameter> parameters)
        {
            var command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        private List<DbParameter> CreateParameter(Dictionary<string, string> parameter)
        {
            List<DbParameter> ParameterList = new List<DbParameter>();

            foreach (var item in parameter)
            {
                DbParameter paramId = _connectionFactory.CreateParameter();
                paramId.ParameterName = item.Key;
                paramId.Value = item.Value;
                ParameterList.Add(paramId);
            }
            return ParameterList;
        }

        private async Task<DbConnection> OpenConnectionAsync()
        {
            var connection = _connectionFactory.CreateConnection();
            connection.ConnectionString = _connectionString;
            await connection.OpenAsync();
            return connection;
        }

        private DbConnection OpenConnection()
        {
            var connection = _connectionFactory.CreateConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
