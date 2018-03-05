using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using UrlScraper.Application.Entities;

namespace UrlScraper.Application.Services
{
    public class Scraper : IScraper
    {
        /// <summary>
        /// Loads the HTML as string.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>string type of HTML</returns>
        public async Task<string> LoadHtml(Uri url)
        {
            HttpClient client = new HttpClient();

            using (var response = await client.GetAsync(url))
            {
                using (var content = response.Content)
                {
                    return await content.ReadAsStringAsync();
                }
            }
        }

        /// <summary>
        /// Find the matching tags using RegularExpression.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="lookupTag"></param>
        /// <param name="url"></param>
        /// <returns>Dictionary</returns>
        public Dictionary<int, string> FindMatchingTags(string html, string lookupTag, string url)
        {
            List<string> list = new List<string>();
            Dictionary<int, string> dic = new Dictionary<int, string>();
            int counter = 0;

            MatchCollection matches = Regex.Matches(html, lookupTag, RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                string innerText = match.Groups[1].Value;

                counter++;

                if (!string.IsNullOrEmpty(innerText))
                {
                    if (innerText.Contains(url))
                    {
                        dic.Add(counter, innerText);
                    }
                }
            }

            return dic;
        }

        /// <summary>
        /// Create URL from the request
        /// </summary>
        /// <param name="searchData"></param>
        /// <returns>Uri</returns>
        public Uri GetUri(RequestData searchData)
        {
            string googleSearchUrl = "http://www.google.com/search?num={0}&q={1}&btnG=Search";

            string searchTerm = !string.IsNullOrEmpty(searchData.Keywords) ?
                searchData.WebsiteUrl.Trim() + " " + searchData.Keywords.Trim() :
                searchData.WebsiteUrl.Trim();

            //create dynamic url from user input
            Uri url = new Uri(string.Format(googleSearchUrl, searchData.RecordsToSearch, HttpUtility.UrlEncode(searchTerm)));

            return url;
        }

        /// <summary>
        /// Fetch the unique results from the dictionary.
        /// </summary>
        /// <param name="resultPositions"></param>
        /// <returns>ResultData</returns>
        public ResultData FetchResults(Dictionary<int, string> resultPositions)
        {
            ResultData result = null;

            var distinct = resultPositions.Keys.Distinct().ToList();

            if (distinct.Any())
            {
                result = new ResultData
                {
                    TotalResults = distinct.Count().ToString(),
                    Occurences = Iterate(distinct)
                };
            }

            return result;
        }

        /// <summary>
        /// Iterate through the List to add commas after each value.
        /// </summary>
        /// <param name="occurances"></param>
        /// <returns>String with comma seperated values.</returns>
        private string Iterate(List<int> occurances)
        {
            string occur = string.Join(", ", occurances.ToArray());

            return occur;
        }
    }
}
