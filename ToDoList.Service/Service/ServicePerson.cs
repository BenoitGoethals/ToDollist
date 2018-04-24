using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BusLayer.Domain;

namespace ToDoList.Service.Service
{
   public class ServicePerson:IService<Person>
    {
        public void Add(Person t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person t)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(int idDelete)
        {
            throw new NotImplementedException();
        }

        public void Update(Person t)
        {
            throw new NotImplementedException();
        }

        public List<Identity> All<T>()
        {
            throw new NotImplementedException();
        }

        public Person Get(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
