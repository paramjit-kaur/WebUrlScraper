using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;

namespace UrlScraper.Web.Constants
{
    static class ScraperConstants
    {
        public const string Keywords = "online search title";
        public const string WebsiteUrl = "www.infotrack.com.au";
        public const string TotalSearchRecords = "100";

        public static ReadOnlyCollection<SelectListItem> ResultsLookup
        {
            get { return _resultLookup; }
        }

        private static readonly ReadOnlyCollection<SelectListItem> _resultLookup =
    new ReadOnlyCollection<SelectListItem>(new[]
        {
            new SelectListItem {Text = "10", Value = "10"},
                        new SelectListItem {Text = "20", Value = "20"},
                          new SelectListItem {Text = "30", Value = "30"},
                            new SelectListItem {Text = "40", Value = "40"},
                              new SelectListItem {Text = "50", Value = "50"},
                                new SelectListItem {Text = "60", Value = "60"},
                                new SelectListItem {Text = "70", Value = "70"},
                                new SelectListItem {Text = "80", Value = "80"},
                                  new SelectListItem {Text = "90", Value = "90"},
                                    new SelectListItem {Text = "100", Value = "100"}

        });



    }
}

