using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using UrlScraper.Application.Services;
using UrlScraper.Web.Controllers;
using UrlScraper.Application.Entities;
using Microsoft.AspNetCore.Mvc;
using UrlScraper.Web.ViewModel;
using Moq;

namespace UrlScraper.Test
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        private Moq.Mock<IScraperService> scraperServiceMock;

        private HomeController target;

        [TestInitialize]
        public void Init()
        {
            scraperServiceMock = new Mock<IScraperService>();

            target = new HomeController(scraperServiceMock.Object);
        }

        [TestMethod]
        public async Task HomeController_Get_UnitTest()
        {
            scraperServiceMock.Setup(service => service.Execute(new RequestData()))
                .Returns(Task.FromResult(new ResultData()));

            // Act
            var result = await target.Index();

            // Assert
            var model = (result as ViewResult).Model as ResultDataViewModel;
            Assert.AreEqual("0", model.Occurrences);

        }       
    }
}
