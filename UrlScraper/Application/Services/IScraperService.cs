using System.Threading.Tasks;
using UrlScraper.Application.Entities;

namespace UrlScraper.Application.Services
{
    public interface IScraperService
    {
        Task<ResultData> Execute(RequestData searchData);
    }
}
