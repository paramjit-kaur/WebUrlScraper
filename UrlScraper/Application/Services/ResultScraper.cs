using System.Collections.Generic;
using System.Threading.Tasks;
using UrlScraper.Application.Entities;

namespace UrlScraper.Application.Services
{
    public class ResultScraper
    {
        readonly IScraper scraper = null;
        readonly string lookupTags = "(<div class=\"g\">.*?</div>)";

        public ResultScraper()
        {
            scraper = new Scraper();
        }

        public async Task<ResultData> FetchData(RequestData request)
        {
            var url = scraper.GetUri(request);

            var resultHtml = await scraper.LoadHtml(url);

            Dictionary<int, string> resultPositions = scraper.FindMatchingTags(resultHtml, lookupTags, request.WebsiteUrl);

            ResultData result = scraper.FetchResults(resultPositions);

            return result;
        }
    }
}
