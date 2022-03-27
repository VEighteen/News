using News.Model;
using ServiceStack.OrmLite;
using News.CrawlerName;

namespace News.Db
{
    public class DataActions
    {
        private readonly Connection _connection;

        public DataActions(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Page> SelectAll()
        {
            return _connection.getConnection().Select<Page>();
        }

        public void Insert(Page page)
        {
            _connection.getConnection().Insert(page);
        }

        public void Insert(string url)
        {
            Crawler crawler = new Crawler(url);
            var res = crawler.DownloadPage().Result;

            Page page = new Page
            {
                Html = res.Content.Text,
                Url = res.Uri.AbsoluteUri,
                Text = res.AngleSharpHtmlDocument.Body.TextContent,
                Date = DateTime.Now
            };

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
