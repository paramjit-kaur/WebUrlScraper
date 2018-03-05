using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlScraper.Application.Entities;
using UrlScraper.Application.Services;
using UrlScraper.Web.Constants;
using UrlScraper.Models;
using UrlScraper.Web.ViewModel;

namespace UrlScraper.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IScraperService scraper;

        public HomeController(IScraperService _scraper)
        {
            scraper = _scraper;
        }

        public async Task<IActionResult> Index()
        {
            RequestData request = new RequestData
            {
                Keywords = ScraperConstants.Keywords,
                WebsiteUrl = ScraperConstants.WebsiteUrl,
                RecordsToSearch = ScraperConstants.TotalSearchRecords
            };

            ResultData result = await scraper.Execute(request);

            ResultDataViewModel resultData = new ResultDataViewModel
            {
                WebsiteUrl = request.WebsiteUrl,
                RecordsToSearch = request.RecordsToSearch,
                CurrentDateTime = DateTime.Now.ToString()
            };

            resultData.Occurrences = result == null ? "0" : result.Occurences;
            resultData.TotalResults = result == null ? "0" : result.TotalResults;

            return View(resultData);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
