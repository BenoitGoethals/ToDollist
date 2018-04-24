using System.Collections.Generic;
using ToDoList.BusLayer.Domain;

namespace TotDoList.DAL.Repository
{
    public interface IReposotory<T> where T:Identity
    {
        void Add(T toDo);
        void Delete(T toDo);
        void Update(T toDo);
        List<Identity> All();
        T Get(int id);
        void Delete(int idDelete);
    }
}
