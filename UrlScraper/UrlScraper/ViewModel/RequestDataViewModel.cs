using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UrlScraper.Web.ViewModel
{
    public class RequestDataViewModel
    {
        [DisplayName("Search Keywords")]
        public string Keywords { get; set; }

        [DisplayName("Search Url")]
        [Required(ErrorMessage = "Url is required.")]
        [RegularExpression(@"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Please enter a valid url.")]
        //[Url(ErrorMessage = "Please enter a valid url.")] by default accepts http(s)://
        public string WebsiteUrl { get; set; }

        public string RecordsToSearch { get; set; }

        [DisplayName("Records to Search")]
        public IReadOnlyCollection<SelectListItem> LookupRecords { get; set; }
    }
}
