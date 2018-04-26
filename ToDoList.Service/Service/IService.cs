using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace ToDoList.Service.Service
{
    public interface IService<T> where T : Identity

    {
    Task Add(T t);
        Task Delete(T t);
        Task Delete(int idDelete);
        Task Update(T t);
    Task<List<T>> All();
    Task<T> Get(int Id);
    Task DeleteAll();
    }
}
