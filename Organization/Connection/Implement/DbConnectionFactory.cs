using System;
using System.Collections.Generic;
using System.Data;
using Connection.Base;
using Npgsql;

namespace Connection.Implement
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<DbConnectionName, string> _connectionDictionary;

        public DbConnectionFactory(IDictionary<DbConnectionName, string> connectionDictionary)
        {
            _connectionDictionary = connectionDictionary;
        }

        public IDbConnection CreateDbConnection(DbConnectionName connectionName)
        {
            if (_connectionDictionary.TryGetValue(connectionName, out var connectionString))
                return new NpgsqlConnection(connectionString);

            throw new ArgumentNullException();
        }
    }
}
