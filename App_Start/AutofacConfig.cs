using Autofac;
using Autofac.Integration.WebApi;
using GisSystemServer.Context;
using GisSystemServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace GisSystemServer.App_Start
{
    public class AutofacConfig
    {
        private static IContainer Container { get; set; }
        private static ILifetimeScope MainScope { get; set; }

        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UserContext>().As<UserContext>().InstancePerRequest(); ;
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest(); ;
            builder.RegisterType<FactoryRepository>().As<IFactoryRepository>().InstancePerRequest(); ;
            Container = builder.Build();
            MainScope = Container;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

        public static T GetObjectInstance<T>()
        {
            T ret;
            MainScope.TryResolve(out ret);
            return ret;
        }

        public static void Init()
        {
            AutofacConfig.RegisterComponents();
        }
    }
}




