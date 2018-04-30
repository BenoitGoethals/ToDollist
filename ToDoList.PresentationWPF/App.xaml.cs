using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using ToDoList.Domain;
using ToDoList.PresentationWPF.utils;
using ToDoList.Service.Service;
using TotDoList.DAL.Repository;

namespace ToDoList.PresentationWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Mediator mediator=new Mediator();
        
    }
}
