using System;
using System.Collections.Generic;
using ToDollist.Domain;
using ToDollist.Repository;

namespace ToDollist.Service
{
    public  class Facade:IFacade<ToDo>,IFacade<Person>
    {

        private static readonly Facade InstanceDoFacade=new Facade();


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

        Person IFacade<Person>.Get(int Id)
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

        ToDo IFacade<ToDo>.Get(int Id)
        {
            return Reposotory.Get(Id);
        }


        public static Facade Instance()
        {
            return InstanceDoFacade;
        }


    }
}
