using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace TotDoList.DAL.Repository
{
    public interface IReposotory<T> where T:Identity
    {
        void Add(T toDo);
        void Delete(T toDo);
        void Update(T toDo);
        Task<List<T>> All();
        Task<T> Get(int id);
        void Delete(int idDelete);
    }
}
