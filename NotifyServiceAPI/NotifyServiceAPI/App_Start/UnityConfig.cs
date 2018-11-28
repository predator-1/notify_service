using System.Web.Http;
using NotifyServiceAPI.Interfaces;
using NotifyServiceAPI.Services;
using Unity;
using Unity.WebApi;

namespace NotifyServiceAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<INotifyService, NotifyService>();
            container.RegisterType<IPushService, PushService>();
            container.RegisterType<IStorage, Storage>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}