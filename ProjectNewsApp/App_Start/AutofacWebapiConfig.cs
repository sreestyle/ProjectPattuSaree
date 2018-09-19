using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PattuSaree.Data.DbContext;
using PattuSaree.Data.Infrastructure;
using PattuSaree.Data.Repositories;
using PattuSaree.Service;

namespace ProjectNewsApp
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // EF 
            builder.RegisterType<PattuSareeContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterGeneric(typeof(EntityBaseRepository<>)).As(typeof(IEntityBaseRepository<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(EntityReadOnlyBaseRepository<>)).As(typeof(IEntityReadOnlyBaseRepository<>)).InstancePerRequest();
            
            builder.RegisterType<SQLSPHelper>().As<ISQLSPHelper>().InstancePerRequest();
            builder.RegisterType<SqlHelper>().As<ISqlHelper>().InstancePerRequest();

            // Services
            // Generic Data Repository Factorys

            builder.RegisterAssemblyTypes(typeof(SingUpService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            //builder.RegisterAssemblyTypes(typeof(Logic).Assembly).Where(t => t.Name.EndsWith("Logic")).AsImplementedInterfaces().InstancePerRequest();


            Container = builder.Build();

            return Container;
        }
    }
}