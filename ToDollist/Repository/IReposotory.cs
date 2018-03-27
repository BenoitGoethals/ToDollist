using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDollist.Domain;

namespace ToDollist.Repository
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
