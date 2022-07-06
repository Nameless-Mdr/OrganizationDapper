using System.Data;

namespace Connection.Base
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(DbConnectionName connectionName);
    }
}
