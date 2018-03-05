using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace UrlScraper.Application.Entities
{
    public class RequestData
    {
        public string Keywords { get; set; }

        public string WebsiteUrl { get; set; }

        public string RecordsToSearch { get; set; }

        public List<SelectListItem> LookupRecords { get; set; }
    }
}
