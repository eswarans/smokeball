using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SearchRank.Interfaces.Data;
using SearchRank.Interfaces.Ioc;
using SearchRank.Interfaces.Logic;
using SearchRank.Models;


namespace SearchRank.Web.Controllers
{
    public class ResultsController : Controller
    {
        protected IServiceContainer _serviceContainer;
        protected IConfiguration _configuration;
        protected string filepth;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="serviceContainer"></param>
        public ResultsController(IConfiguration configuration, IServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
            _configuration = configuration;
            filepth = _configuration.GetValue<string>("XmlFilePath:filepath");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Get()
        {
            IDataRetreive dataRetreive = (IDataRetreive)_serviceContainer.GetService(typeof(IDataRetreive));
            dataRetreive.Init(filepth);
            UserSetting result = dataRetreive.GetUserSetting("");

            IUrlBuilder urlBuilder = (IUrlBuilder)_serviceContainer.GetService(typeof(IUrlBuilder));
            string url = urlBuilder.SearchUrl(result.SearchKey);

            ISearch search = (ISearch)_serviceContainer.GetService(typeof(ISearch));
            string googlepage = search.SearchIt(url);

            IRank rank = (IRank)_serviceContainer.GetService(typeof(IRank));
            int position = rank.GetRank(googlepage, "www.smokeball.com.au");

            return new JsonResult(position);
        }
    }
}
