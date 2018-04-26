using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using ToDoList.Domain;

namespace TotDoList.DAL.Repository
{

    public class ToDoRepository:IReposotory<ToDo>, IDisposable
    {

        public ToDoRepository()
        {
         //   _context.Database.Initialize(false);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public void Deconstruct(out ToDoListDbContext context)
        {
            context = _context;
        }

        private readonly ToDoListDbContext _context =new ToDoListDbContext();

        private static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public async Task AddAsync(ToDo toDo)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.ToDos.Add(toDo);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    transaction.Rollback();
                }

            }
        }

        public async Task Delete(ToDo toDo)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.ToDos.Remove(toDo);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    transaction.Rollback();
                }

            }
        }

        public async Task Update(ToDo toDo)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                     _context.ToDos.AddOrUpdate(toDo);
                     await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    transaction.Rollback();
                }

            }
        }

        public  Task<List<ToDo>> All()
        {
            return  _context.ToDos.ToListAsync<ToDo>();
        }

        public Task<ToDo> Get(int id)
        {
            return _context.ToDos.FindAsync(id);
        }

        public async Task DeleteAll()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await Task.Run(() => _context.Database.ExecuteSqlCommand($"TRUNCATE TABLE {typeof(ToDo).Name}"));

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    transaction.Rollback();
                }

            }
        }

        public  async Task Delete(int idDelete)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await Task.Run(()=> _context.ToDos.Remove(Get(idDelete).Result));

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    transaction.Rollback();
                }

            }
        }
    }
}
