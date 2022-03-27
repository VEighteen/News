using ServiceStack.OrmLite;
using System.Data;

namespace News.Db
{
    public class Connection
    {
        private readonly IConfiguration configuration;

        private readonly OrmLiteConnectionFactory _dbFactory ;

        public Connection()
        {
             _dbFactory = new OrmLiteConnectionFactory(configuration.GetConnectionString("DevConnection"), SqlServerDialect.Provider);
        }

        public IDbConnection getConnection()
        {
            return _dbFactory.Open();
        }
    }
}
