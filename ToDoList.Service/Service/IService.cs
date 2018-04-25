using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace ToDoList.Service.Service
{
    public interface IService<T> where T : Identity

    {
    void Add(T t);
    void Delete(T t);
    void Delete(int idDelete);
    void Update(T t);
    Task<List<T>> All();
    Task<T> Get(int Id);

    }
}
