using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace TotDoList.DAL.Repository
{
    public class RepositoryMeM<T>:IReposotory<T> where T:Identity
    {

        private readonly List<T> _list =new List<T>();


        public async Task AddAsync(T t)
        {
            int highst = 0;
           if (_list.Count>0)
                 highst = _list.Max(x => x.Id);
          
            t.Id = highst + 1;
            await Task.Run(() => { _list.Add(t); });
        }

        public async Task Delete(T t)
        {
            await Task.Run(() => { _list.Remove(t);});
        }

        public async Task Update(T t)
        {
            if (_list.Contains(t))
            {
                await Task.Run(() => {
                    _list.Remove(t);
                _list.Add(t);
                });
            }
        }

       

        public async Task<List<T>> All()
        {
            return await Task.FromResult(_list);
        }

        public Task<T> Get(int id)
        {
            foreach (var identity in _list)
            {
                var toDo = (T) identity;
                if (toDo.Id.Equals(id)) return Task.FromResult(toDo);
            }
            return null;
        }

        public async Task Delete(int idDelete)
        {
            T delete =default(T) ;
            foreach (var identity in _list)
            {
                var t = (T) identity;
                if (t.Id.Equals(idDelete))
                {
                    delete = t;
                    break;
                };
            }
            if (delete != null)
                await Task.Run(() => {
                    _list.Remove(delete);
                });
        }

        

        
    }
}
