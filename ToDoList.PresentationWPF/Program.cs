using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;
using ToDoList.PresentationWPF;
using ToDoList.PresentationWPF.viewModel;
using ToDoList.Service.Service;

namespace ToDoStarter
{
    class Program
    {
        [STAThread]
       public static  void Main(string[] args)
        {
           MainWindow main=new MainWindow();

            
            main.ShowDialog();

        }
    }
}
