using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain;

namespace TotDoList.DAL.Repository
{

    public class ToDoRepository:IReposotory<ToDo>
    {

        private readonly ToDoListDbContext _context =new ToDoListDbContext();

        public void Add(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
            _context.SaveChangesAsync();
        }

        public void Delete(ToDo toDo)
        {
            _context.ToDos.Remove(toDo);
            _context.SaveChangesAsync();
        }

        public void Update(ToDo toDo)
        {
            _context.ToDos.AddOrUpdate(toDo);
            _context.SaveChangesAsync();
        }

        public Task<List<ToDo>> All()
        {
            return _context.ToDos.ToListAsync<ToDo>();
        }

        public Task<ToDo> Get(int id)
        {
            return _context.ToDos.FindAsync(id);
        }

        public  void Delete(int idDelete)
        {
             _context.ToDos.Remove(Get(idDelete).Result);
        }
    }
}
