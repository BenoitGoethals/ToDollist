using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.Owin;
using Owin;
using ToDoList.Domain;
using ToDoList.Service.Service;
using TotDoList.DAL.Repository;

[assembly: OwinStartup(typeof(WebApiNetToDo.Startup))]

namespace WebApiNetToDo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            ConfigureAuth(app);
        }
    }
}
