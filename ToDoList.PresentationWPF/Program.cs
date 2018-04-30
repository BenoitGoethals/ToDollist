using System;
using Autofac;
using ToDoList.Domain;
using ToDoList.Service.Service;
using TotDoList.DAL.Repository;

namespace ToDoList.PresentationWPF
{
    class Program
    {
        public static IContainer Container;

        [STAThread]
       public static  void Main(string[] args)
        {

            var builder = new ContainerBuilder();
            builder.RegisterInstance(new ToDoRepository())
                .As<IReposotory<ToDo>>();
            builder.RegisterInstance(new PersonRepository())
                .As<IReposotory<Person>>();
            builder.Register(c =>new ServiceToDo(c.Resolve<IReposotory<ToDo>>()))
                .As<IService<ToDo>>().SingleInstance();
            builder.Register(c =>new ServicePerson(c.Resolve<IReposotory<Person>>()))
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

             Container = builder.Build();
            IService<ToDo> service = Container.Resolve<IService<ToDo>>();

              ToDoList.PresentationWPF.App app = new ToDoList.PresentationWPF.App();
            app.InitializeComponent();
            app.Run();

        }
    }
}
