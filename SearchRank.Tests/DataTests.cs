using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchRank.Interfaces.Data;
using SearchRank.Interfaces.Ioc;
using SearchRank.Ioc;
using SearchRank.Models;

namespace SearchRank.Tests
{
    [TestClass]
    public class DataTests
    {
        private IServiceContainer _serviceContainer = null;

        private void SetupIoc()
        {
            _serviceContainer = new ServiceContainer();
        }

        [TestMethod]
        public void TestMethodAddData()
        {
            if(_serviceContainer == null)
            {
                SetupIoc();
            }

            IDataUpdates dataUpdates = (IDataUpdates)_serviceContainer.GetService(typeof(IDataUpdates));
            dataUpdates.Init("c:\\temp\\smokeball.xml");

            UserSetting userSetting = new UserSetting()
            {
                UserName = "Test1",
                PreferredRank = 50,
                SearchEngineUrl = "Google",
                SearchKey = "conveyancing software"

            };
            bool resut = dataUpdates.SetUserSetting(userSetting);
            Assert.IsTrue(resut);

        }


        [TestMethod]
        public void TestMethodRetreiveData()
        {
            if (_serviceContainer == null)
            {
                SetupIoc();
            }

            IDataRetreive dataRetreive = (IDataRetreive)_serviceContainer.GetService(typeof(IDataRetreive));
            dataRetreive.Init("c:\\temp\\smokeball.xml");
            var result = dataRetreive.GetUserSetting("");


            Assert.AreEqual("Test1", result.UserName);

        }
    }
}
