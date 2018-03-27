using System;
using System.Collections.Generic;
using ToDollist.Domain;

namespace ToDollist.Service
{
    public interface IFacade<T> where T:Identity
    {
        void Add(T t);
        void Delete(T t);
        void Delete<T>(int idDelete);
        void Update(T t);
        List<Identity> All<T>();
        T Get(int Id);
        
    }
}
