using SearchRank.Interfaces.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using SearchRank.Interfaces.Logic;
using SearchRank.Logic;
using SearchRank.Interfaces.Data;
using SearchRank.data.xml;
using SearchRank.Data.Updates.xml;

namespace SearchRank.Ioc
{
    /// <summary>
    /// DI Container
    /// </summary>
    public class ServiceContainer : IServiceContainer, IServiceProvider
    {
        private ServiceCollection serviceCollection;
        private ServiceProvider serviceResolver;

        /// <summary>
        /// 
        /// </summary>
        public ServiceContainer()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IUrlBuilder, GoogleSearchUrlBuilder>();
            serviceCollection.AddTransient<ISearch, Search>();
            serviceCollection.AddTransient<IRank, GoogleRank>();
            serviceCollection.AddTransient<IDataUpdates, XUpdate>();
            serviceCollection.AddTransient<IDataRetreive, XRead>();
            serviceResolver = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisposeContainer()
        {
            if (serviceCollection != null)
            {
                serviceCollection.Clear();
                serviceCollection = null;
            }

            if (serviceResolver != null)
            {
                serviceResolver.Dispose();
                serviceResolver = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return serviceResolver.GetService(serviceType);
        }
    }
}