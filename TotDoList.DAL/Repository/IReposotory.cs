using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace TotDoList.DAL.Repository
{
    public interface IReposotory<T> where T:Identity
    {
        Task AddAsync(T toDo);
        Task Delete(T toDo);
        Task Update(T toDo);
        Task<List<T>> All();
        Task<T> Get(int id);
        Task Delete(int idDelete);
        Task DeleteAll();
    }
}
