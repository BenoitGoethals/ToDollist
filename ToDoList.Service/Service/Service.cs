using System;
using System.Collections.Generic;
using ToDoList.BusLayer.Domain;
using TotDoList.DAL.Repository;

namespace ToDoList.Service.Service
{
    public  class Service:IService<ToDo>,IService<Person>
    {

        private static readonly Service InstanceDoService=new Service();


        private static readonly IReposotory<ToDo> Reposotory=new Repository<ToDo>();

        private static readonly IReposotory<Person> ReposotoryPerson = new Repository<Person>();


        public void Add(ToDo toDo)
        {
            Reposotory.Add(toDo);
        }

        public void Delete(ToDo toDo)
        {
           Reposotory.Delete(toDo);
        }

       

        public void Update( ToDo toDo)
        {
          Reposotory.Update(toDo);
        }

        public void Add(Person t)
        {
            ReposotoryPerson.Add(t);
        }

        public void Delete<T>(int idDelete)
        {
            if(typeof(T) == typeof(ToDo))
                Reposotory.Delete(idDelete);
            if (typeof(T) == typeof(Person))
                ReposotoryPerson.Delete(idDelete);
        }

        public void Delete(Person t)
        {
            ReposotoryPerson.Delete(t);
        }
        

        public void Update(Person t)
        {
            ReposotoryPerson.Update(t);
        }

        public void Update(int idUpdate, string descUpdate)
        {
            throw new NotImplementedException();
        }

        Person IService<Person>.Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Identity> All<T>() 
        {
            if (typeof(T) == typeof(ToDo))
               return Reposotory.All();
            if (typeof(T) == typeof(Person))
                return ReposotoryPerson.All();
            return null;
        }

        ToDo IService<ToDo>.Get(int Id)
        {
            return Reposotory.Get(Id);
        }


        public static Service Instance()
        {
            return InstanceDoService;
        }


    }
}
