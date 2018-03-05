using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrlScraper.Application.Entities;

namespace UrlScraper.Application.Services
{
    public interface IScraper
    {
        Uri GetUri(RequestData searchData);

        Task<string> LoadHtml(Uri url);

        Dictionary<int, string> FindMatchingTags(string html, string lookupTag, string url);

        ResultData FetchResults(Dictionary<int, string> resultPositions);

    }
}
