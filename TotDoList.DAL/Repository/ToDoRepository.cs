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

    public class ToDoRepository:IReposotory<ToDo>, IDisposable
    {
        public void Dispose()
        {
            _context?.Dispose();
        }

        public void Deconstruct(out ToDoListDbContext context)
        {
            context = _context;
        }

        private readonly ToDoListDbContext _context =new ToDoListDbContext();

        public async Task AddAsync(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ToDo toDo)
        {
            _context.ToDos.Remove(toDo);
           await _context.SaveChangesAsync();
        }

        public async Task Update(ToDo toDo)
        {
            _context.ToDos.AddOrUpdate(toDo);
           await _context.SaveChangesAsync();
        }

        public  Task<List<ToDo>> All()
        {
            return  _context.ToDos.ToListAsync<ToDo>();
        }

        public Task<ToDo> Get(int id)
        {
            return _context.ToDos.FindAsync(id);
        }

        public  async Task Delete(int idDelete)
        {
            await Task.Run(()=> _context.ToDos.Remove(Get(idDelete).Result));
        }
    }
}
