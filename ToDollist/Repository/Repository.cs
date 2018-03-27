using System.Collections.Generic;
using System.Linq;
using ToDollist.Domain;

namespace ToDollist.Repository
{
    public class Repository<T>:IReposotory<T> where T:Identity
    {

        private readonly List<Identity> _list =new List<Identity>();


        public void Add(T toDo)
        {
            int highst = 0;
           if (_list.Count>0)
                 highst = _list.Max(x => x.Id);
          
            toDo.Id = highst + 1;
           _list.Add(toDo);
        }

        public void Delete(T toDo)
        {
            _list.Remove(toDo);
        }

        public void Update(T toDo)
        {
            if (_list.Contains(toDo))
            {
                _list.Remove(toDo);
                _list.Add(toDo);
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
            T toDoDelete =default(T) ;
            foreach (var identity in _list)
            {
                var toDo = (T) identity;
                if (toDo.Id.Equals(idDelete))
                {
                    toDoDelete = toDo;
                    break;
                };
            }
            if (toDoDelete != null) _list.Remove(toDoDelete);
        }

        

        
    }
}
