using System;

namespace SearchRank.Interfaces.Ioc
{
    /// <summary>
    /// Dependency injection interface
    /// </summary>
    public interface IServiceContainer
    {
        object GetService(Type serviceType);
        void DisposeContainer();
    }
}
