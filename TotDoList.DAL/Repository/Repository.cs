using System.Collections.Generic;
using System.Linq;
using ToDoList.BusLayer.Domain;

namespace TotDoList.DAL.Repository
{
    public class Repository<T>:IReposotory<T> where T:Identity
    {

        private readonly List<Identity> _list =new List<Identity>();


        public void Add(T t)
        {
            int highst = 0;
           if (_list.Count>0)
                 highst = _list.Max(x => x.Id);
          
            t.Id = highst + 1;
           _list.Add(t);
        }

        public void Delete(T t)
        {
            _list.Remove(t);
        }

        public void Update(T t)
        {
            if (_list.Contains(t))
            {
                _list.Remove(t);
                _list.Add(t);
            }
        }

       

        public List<Identity> All()
        {
           return _list;
        }

        public T Get(int id)
        {
            foreach (var identity in _list)
            {
                var toDo = (T) identity;
                if (toDo.Id.Equals(id)) return toDo;
            }
            return null;
        }

        public void Delete(int idDelete)
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
            if (delete != null) _list.Remove(delete);
        }

        

        
    }
}
