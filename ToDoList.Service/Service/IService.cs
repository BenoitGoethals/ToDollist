using System.Collections.Generic;
using ToDoList.BusLayer.Domain;

namespace ToDoList.Service.Service
{
    public interface IService<T> where T : Identity

    {
    void Add(T t);
    void Delete(T t);
    void Delete<T>(int idDelete);
    void Update(T t);
    List<Identity> All<T>();
    T Get(int Id);

    }
}
