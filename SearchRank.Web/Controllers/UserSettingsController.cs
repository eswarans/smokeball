using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SearchRank.Interfaces.Data;
using SearchRank.Interfaces.Ioc;
using SearchRank.Models;

namespace SearchRank.Web.Controllers
{
    public class UserSettingsController : Controller
    {
        protected IServiceContainer _serviceContainer;
        protected IConfiguration _configuration;
        protected string filepth;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="serviceContainer"></param>
        public UserSettingsController(IConfiguration configuration, IServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
            _configuration = configuration;
            filepth = _configuration.GetValue<string>("XmlFilePath:filepath");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSetting"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Save([FromBody] UserSetting userSetting)
        {
            IDataUpdates dataUpdates = (IDataUpdates)_serviceContainer.GetService(typeof(IDataUpdates));
            dataUpdates.Init(filepth);
            bool resut = dataUpdates.SetUserSetting(userSetting);
            return new JsonResult(resut);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        public JsonResult Get(string user)
        {
            IDataRetreive dataRetreive = (IDataRetreive)_serviceContainer.GetService(typeof(IDataRetreive));
            dataRetreive.Init(filepth);
            var result = dataRetreive.GetUserSetting(user);
            return new JsonResult(result);
        }
    }
}
