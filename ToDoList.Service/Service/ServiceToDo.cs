using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;
using TotDoList.DAL.Repository;

namespace ToDoList.Service.Service
{
    public class ServiceToDo:IService<ToDo>
    {
       
        private readonly  IReposotory<ToDo> _reposotory = new RepositoryMeM<ToDo>();


        public ServiceToDo()
        {
        }

        public ServiceToDo(IReposotory<ToDo> reposotory)
        {
            this._reposotory = reposotory;
        }



        public void Add(ToDo toDo)
        {
            _reposotory.Add(toDo);
        }

        public void Delete(ToDo toDo)
        {
            _reposotory.Delete(toDo);
        }

        public void Delete(int idDelete)
        {
           _reposotory.Delete(idDelete);
        }


        public void Update(ToDo toDo)
        {
            _reposotory.Update(toDo);
        }

        public async Task<List<ToDo>> All()
        {
            return await _reposotory.All();
        }

        public async Task<ToDo> Get(int Id)
        {
            return await _reposotory.Get(Id);
        }


        public void Delete<T>(int idDelete)
        {
      
                _reposotory.Delete(idDelete);
          
        }


        
        public override string ToString()
        {
            return $"{nameof(_reposotory)}: {_reposotory}";
        }
    }
}
