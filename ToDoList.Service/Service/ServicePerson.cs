using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;
using TotDoList.DAL.Repository;

namespace ToDoList.Service.Service
{
   public class ServicePerson:IService<Person>
    {
    
        private readonly IReposotory<Person> _reposotoryPerson = new RepositoryMeM<Person>();

        public ServicePerson()
        {
        }

        public ServicePerson(IReposotory<Person> reposotoryPerson)
        {
            this._reposotoryPerson = reposotoryPerson;
        }

        public  void Add(Person t)
        {
            _reposotoryPerson.AddAsync(t);
        }

        public void Delete(int idDelete)
        {
        
   
                _reposotoryPerson.Delete(idDelete);
        }

        public void Delete(Person t)
        {
            _reposotoryPerson.Delete(t);
        }

       


        public void Update(Person t)
        {
            _reposotoryPerson.Update(t);
        }

       
        

     

        public async Task<List<Person>> All()
        {

            return await  _reposotoryPerson.All();
           
        }

        public async Task<Person> Get(int id)
        {
            return await _reposotoryPerson.Get(id);
        }


        public override string ToString()
        {
            return $"{nameof(_reposotoryPerson)}: {_reposotoryPerson}";
        }


    }
}
