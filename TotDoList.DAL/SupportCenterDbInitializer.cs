using System;
using System.Data.Entity;
using ToDoList.Domain;

namespace TotDoList.DAL
{
    public class SupportCenterDbInitializer
        : DropCreateDatabaseAlways<ToDoListDbContext>
    {
        protected override void Seed(ToDoListDbContext context)
        {
            /*
            for (int i = 0; i < 30; i++)
            {
                Person person=new Person()
                {
                    City = "sqdqsd"+i,
                    Gender = Gender.Female,
                    Name = "sfsdf"+i,
                    Nr = "dd"+i,
                    Street = "qdqdqdqd"+i,
                    ZipCode = "9810"
                };
                context.Persons.Add(person);
            }
            for (int i = 0; i < 20; i++)
            {
                 var toDo=new ToDo("es"+1,DateTime.Now, DateTime.Now.AddDays(1), Status.Created);
                context.ToDos.Add(toDo);
               
            }
            context.SaveChanges();
            base.Seed(context);
            */
        }
    }
}