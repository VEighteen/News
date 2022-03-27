using Abot2.Core;
using Abot2.Poco;

namespace News.CrawlerName
{
    internal class Crawler
    {
        private readonly string _url;

        public Crawler(string url)
        {
            _url = url;
        }

        public async Task<CrawledPage> DownloadPage()
        {
            var pageRequester = new PageRequester(new CrawlConfiguration(), new WebContentExtractor());

            return await pageRequester.MakeRequestAsync(new Uri(_url));
        }
    }
}
