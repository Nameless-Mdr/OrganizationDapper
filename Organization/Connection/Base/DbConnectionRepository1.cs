using System.Data;

namespace Connection.Base
{
    public abstract class DbConnectionRepository1
    {
        public IDbConnection DbConnection { get; private set; }

        public DbConnectionRepository1(IDbConnectionFactory dbConnectionFactory)
        {
            this.DbConnection = dbConnectionFactory.CreateDbConnection(DbConnectionName.Connection1);
        }
    }
}
