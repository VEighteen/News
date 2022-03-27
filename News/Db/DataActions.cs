using News.Model;
using ServiceStack.OrmLite;

namespace News.Db
{
    public class DataActions
    {
        private readonly Connection _connection;

        public DataActions(Connection connection)
        {
            _connection = connection;
        }

        public void Insert(Page page)
        {
            _connection.getConnection().Insert(page);
        }

        public void Delete(Page page)
        {
            _connection.getConnection().Delete(page);
        }

        public void Update(Page page)
        {
            _connection.getConnection().Update(page);
        }

        public void DeleteById(int id)
        {
            _connection.getConnection().DeleteById<Page>(id);
        }
    }
}
