using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using ToDoList.Domain;
using ToDoList.Service.Service;
using TotDoList.DAL.Repository;
using WebApiNetToDo.Controllers;

namespace WebApiNetToDo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.

            
            builder.RegisterInstance(new ToDoRepository())
                .As<IReposotory<ToDo>>();
            builder.RegisterInstance(new PersonRepository())
                .As<IReposotory<Person>>();
            builder.Register(c => new ServiceToDo(c.Resolve<IReposotory<ToDo>>()))
                .As<IService<ToDo>>().SingleInstance();
            builder.Register(c => new ServicePerson(c.Resolve<IReposotory<Person>>()))
                .As<IService<Person>>().SingleInstance();
            builder.Register(c => new ServicePerson(c.Resolve<IReposotory<Person>>()))
                .As<IService<Person>>().SingleInstance();
            //ToDoRepository:IReposotory<ToDo>
            // Register individual components

            //builder.RegisterType<TaskController>();
            //builder.Register(c => new LogManager(DateTime.Now))
            //    .As<ILogger>();

            //// Scan an assembly for components
            //builder.RegisterAssemblyTypes(myAssembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces();

         
         

            builder.RegisterType<ToDoController>().InstancePerRequest();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
