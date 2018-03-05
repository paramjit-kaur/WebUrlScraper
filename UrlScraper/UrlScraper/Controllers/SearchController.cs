using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlScraper.Web.ViewModel;
using UrlScraper.Application.Services;
using UrlScraper.Application.Entities;
using UrlScraper.Web.Constants;

namespace UrlScraper.Controllers
{
    public class SearchController : Controller
    {
        public readonly IScraperService scraperService;

        public SearchController(IScraperService _scraper)
        {
            scraperService = _scraper;
        }

        public IActionResult Index()
        {
            RequestDataViewModel model = new RequestDataViewModel
            {
                LookupRecords = ScraperConstants.ResultsLookup
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RequestDataViewModel model)
        {
            try
            {
                if (model == null || string.IsNullOrEmpty(model.WebsiteUrl))
                {
                    throw new Exception("Missing values.");
                }

                if (ModelState.IsValid)
                {
                    RequestData request = new RequestData
                    {
                        Keywords = model.Keywords,
                        WebsiteUrl = model.WebsiteUrl,
                        RecordsToSearch = model.RecordsToSearch
                    };

                    ResultData result = await scraperService.Execute(request);

                    ResultDataViewModel resultData = new ResultDataViewModel();

                    resultData = new ResultDataViewModel
                    {
                        WebsiteUrl = request.WebsiteUrl,
                        RecordsToSearch = request.RecordsToSearch,
                        CurrentDateTime = DateTime.Now.ToString(),
                        Occurrences = result.Occurences,
                        TotalResults = result.TotalResults
                    };
                    return RedirectToAction("SearchResult", "Search", resultData);
                }

                model.LookupRecords = ScraperConstants.ResultsLookup;

                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult SearchResult(ResultDataViewModel model)
        {
            return PartialView("_SearchResultPartial", model);
        }


        /// <summary>
        /// Partial view to render the results
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult _SearchResultPartial(ResultDataViewModel model)
        {
            return PartialView();
        }
    }
}