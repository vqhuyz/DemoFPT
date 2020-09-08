using OracleFPT.DI.Implements;
using OracleFPT.DI.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace OracleFPT
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IDapperRepository, DapperRepository>();
        }
    }
}