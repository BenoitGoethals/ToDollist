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
       public static  void Main(string[] args)
        {
            IService<ToDo> service=new ServiceToDo();

           // Task.Delay(TimeSpan.FromMilliseconds(1000));


        Task task= Task.Run(()=> service.DeleteAll());
          task.Wait();
           // Task.WaitAll();


              List<Task> list=new List<Task>();
              for (int i = 0; i < 20; i++)
              {

                Task ta=  service.Add(new ToDo("test1-" + i, new DateTime(), new DateTime(), Status.Created));
                list.Add(ta);
              }
            Task.WhenAll(list);
            
            
         //   service.All().Result.ForEach(action: Console.WriteLine);


            Console.WriteLine("done");

            Console.ReadLine();
        }
    }
}
