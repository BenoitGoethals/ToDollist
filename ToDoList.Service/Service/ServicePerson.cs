using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using ToDoList.Domain;
using TotDoList.DAL.Repository;

namespace ToDoList.Service.Service
{
   public class ServicePerson:IService<Person>
    {
    
        private readonly IReposotory<Person> _reposotoryPerson = new PersonRepository();

        private static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public ServicePerson()
        {
        }

        public ServicePerson(IReposotory<Person> reposotoryPerson)
        {
            this._reposotoryPerson = reposotoryPerson;
            
        }

        public async  Task Add(Person t)
        {
            Logger.Info($"add : {t}");
            await _reposotoryPerson.AddAsync(t);
           
        }

        public async Task Delete(int idDelete)
        {
        
      Logger.Info($"delete : {idDelete}");
             await   _reposotoryPerson.Delete(idDelete);
         
        }

        public async Task Delete(Person t)
        {
            Logger.Info($"delete : {t}");
            await _reposotoryPerson.Delete(t);
           
        }




        public async Task Update(Person t)
        {
            Logger.Info($"Update : {t}");
            await _reposotoryPerson.Update(t);
          
        }

       
        

     

        public async Task<List<Person>> All()
        {

            return await  _reposotoryPerson.All();
           
        }

        public async Task<Person> Get(int id)
        {
            return await _reposotoryPerson.Get(id);
        }

        public async Task DeleteAll()
        {
            Logger.Info($"Delete all : ");
            await _reposotoryPerson.DeleteAll();
          
        }


        public override string ToString()
        {
            return $"{nameof(_reposotoryPerson)}: {_reposotoryPerson}";
        }


    }
}
