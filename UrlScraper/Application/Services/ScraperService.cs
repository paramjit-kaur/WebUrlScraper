using System.Threading.Tasks;
using UrlScraper.Application.Entities;

namespace UrlScraper.Application.Services
{
    public class ScraperService : IScraperService
    {

        /// <summary>
        /// Execute the task to find the no. of occurrences of requested url.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ResultData</returns>
        public async Task<ResultData> Execute(RequestData request)
        {
            ResultScraper resultScraper = new ResultScraper();

            ResultData result = await resultScraper.FetchData(request);

            return result;
        }
    }
}
