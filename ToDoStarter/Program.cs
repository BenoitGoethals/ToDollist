using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;
using ToDoList.Service.Service;

namespace ToDoStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            IService<ToDo> service=new ServiceToDo();

           
             service.DeleteAll();

            for (int i = 0; i < 20; i++)
            {

                 service.Add(new ToDo("test1", new DateTime(), new DateTime(), Status.Created));

            }
          

        }
    }
}
