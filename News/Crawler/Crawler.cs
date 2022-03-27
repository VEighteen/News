﻿
using Abot2.Core;
using Abot2.Poco;

namespace News.Crawler
{
    internal class Crawler
    {
        private readonly string _url;

        public Crawler(string url)
        {
            _url = url;
        }

        public async Task<CrawledPage> GetPageInfo()
        {
            var pageRequester = new PageRequester(new CrawlConfiguration(), new WebContentExtractor());

            return await pageRequester.MakeRequestAsync(new Uri(_url));
        }
    }
}