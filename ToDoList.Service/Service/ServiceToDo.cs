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
    public class ServiceToDo:IService<ToDo>
    {
        private static IService<ToDo> service=new ServiceToDo();

        private readonly  IReposotory<ToDo> _reposotory = new ToDoRepository();

        private static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public ServiceToDo()
        {
        }

        public ServiceToDo(IReposotory<ToDo> reposotory)
        {
            this._reposotory = reposotory;
        }



        public async  Task Add(ToDo toDo)
        {
           await _reposotory.AddAsync(toDo);
            Logger.Info($"add : {toDo}");
        }

        public async Task Delete(ToDo toDo)
        {
            await _reposotory.Delete(toDo);
            Logger.Info($"add : {toDo}");
        }

        public async Task Delete(int idDelete)
        {
            await _reposotory.Delete(idDelete);
            Logger.Info($"delete : {idDelete}");
        }


        public async Task Update(ToDo toDo)
        {
            await _reposotory.Update(toDo);
            Logger.Info($"add : {toDo}");
        }

        public async  Task<List<ToDo>> All()
        {
            return await _reposotory.All();
        }

        public async Task<ToDo> Get(int Id)
        {
            return await _reposotory.Get(Id);
        }

        public async Task DeleteAll()
        {
            await _reposotory.DeleteAll();
            Logger.Info($"Delete all");
        }


        public void Delete<T>(int idDelete)
        {
      
                _reposotory.Delete(idDelete);
            Logger.Info($"delete : {idDelete}");

        }


        
        public override string ToString()
        {
            return $"{nameof(_reposotory)}: {_reposotory}";
        }



        public static IService<ToDo> Instance()
        {
            return service;
        }
    }
}
