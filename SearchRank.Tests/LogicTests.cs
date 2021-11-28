using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchRank.Interfaces.Data;
using SearchRank.Interfaces.Ioc;
using SearchRank.Interfaces.Logic;
using SearchRank.Ioc;
using SearchRank.Models;

namespace SearchRank.Tests
{
    [TestClass]
    public class LogicTests
    {
        private IServiceContainer _serviceContainer;
        
        private void SetupIoc()
        {
            _serviceContainer = new ServiceContainer();
        }

        [TestMethod]
        public void TestMethodUrlGenerator()
        {
            if (_serviceContainer == null)
            {
                SetupIoc();
            }

            IDataRetreive dataRetreive = (IDataRetreive)_serviceContainer.GetService(typeof(IDataRetreive));
            dataRetreive.Init("c:\\temp\\smokeball.xml");
            UserSetting result = dataRetreive.GetUserSetting("");

            IUrlBuilder urlBuilder = (IUrlBuilder)_serviceContainer.GetService(typeof(IUrlBuilder));
            string url = urlBuilder.SearchUrl(result.SearchKey);
            Assert.AreEqual("https://www.google.com.au/search?num=100&q=conveyancing+software", url);
        }


        [TestMethod]
        public void TestMethodPagedownloader()
        {
            if (_serviceContainer == null)
            {
                SetupIoc();
            }

            IDataRetreive dataRetreive = (IDataRetreive)_serviceContainer.GetService(typeof(IDataRetreive));
            dataRetreive.Init("c:\\temp\\smokeball.xml");
            UserSetting result = dataRetreive.GetUserSetting("");

            IUrlBuilder urlBuilder = (IUrlBuilder)_serviceContainer.GetService(typeof(IUrlBuilder));
            string url = urlBuilder.SearchUrl(result.SearchKey);

            ISearch search = (ISearch)_serviceContainer.GetService(typeof(ISearch));
            string googlepage = search.SearchIt(url);
            int index = googlepage.IndexOf("<!doctype html>", 0);
            Assert.AreEqual(0, index);
        }


        [TestMethod]
        public void TestMethodRankLogic()
        {
            if (_serviceContainer == null)
            {
                SetupIoc();
            }

            IDataRetreive dataRetreive = (IDataRetreive)_serviceContainer.GetService(typeof(IDataRetreive));
            dataRetreive.Init("c:\\temp\\smokeball.xml");
            UserSetting result = dataRetreive.GetUserSetting("");

            IUrlBuilder urlBuilder = (IUrlBuilder)_serviceContainer.GetService(typeof(IUrlBuilder));
            string url = urlBuilder.SearchUrl(result.SearchKey);

            ISearch search = (ISearch)_serviceContainer.GetService(typeof(ISearch));
            string googlepage = search.SearchIt(url);

            IRank rank = (IRank)_serviceContainer.GetService(typeof(IRank));
            int position = rank.GetRank(googlepage, "www.smokeball.com.au");

            Assert.IsTrue(position >= 0);

        }
    }
}
