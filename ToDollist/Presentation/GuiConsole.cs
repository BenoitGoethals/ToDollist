using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using ToDollist.Domain;

namespace ToDollist.Presentation
{
    public class GuiConsole
    {
        


        public void Start()
        {
            String ret;
            do
            {
                PrintMenu();
                 ret = Console.ReadLine();

                switch (ret)
                {
                    case "1":
                       
                       
                        Console.WriteLine("Add description");
                       string desc= Console.ReadLine();
                       
                        Service.Facade.Instance().Add(new ToDo(desc,new DateTime()));
                        break;
                    case "2":
                        Console.Write("Delete id :");
                        int idDelete = Convert.ToInt32(Console.ReadLine());
                        Service.Facade.Instance().Delete<ToDo>(idDelete);
                        break;
                    case "3":
                        Console.WriteLine("update id");
                        int idUpdate = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Add description");
                        string descUpdate = Console.ReadLine();

                        Service.Facade.Instance().Update(new ToDo(descUpdate,new DateTime()){Id = idUpdate});
                        break;
                    case "4":
                        Console.WriteLine("List ToDo");
                        Console.WriteLine("-----");
                        List<Identity> list = Service.Facade.Instance().All<ToDo>();

                        foreach (var toDo in list)
                        {
                            Console.WriteLine(toDo);
                        }
                        Console.WriteLine("");
                        break;
                }
               
                       

            } while (ret!="5");

        }


        public void Stop()
        {

        }


        private void PrintMenu()
        {
            Console.WriteLine("Make a choose :");
            Console.WriteLine("1 Add");
            Console.WriteLine("2 Delete");
            Console.WriteLine("3 Update");
            Console.WriteLine("4 List");
            Console.WriteLine("5 end");
        }
    }
}