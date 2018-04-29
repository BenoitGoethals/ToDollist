using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using ToDoList.Domain;

namespace TotDoList.DAL.Repository
{

    public class ToDoRepository:IReposotory<ToDo>
    {

        public ToDoRepository()
        {
         //   _context.Database.Initialize(false);
        }
        

       

       // private readonly ToDoListDbContext _context =new ToDoListDbContext();

        private static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public async Task AddAsync(ToDo toDo)
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                using (var transaction = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    context.ToDos.Add(toDo);
                    await context.SaveChangesAsync();

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

        public async Task Delete(ToDo toDo)
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                using (var transaction = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    context.ToDos.Attach(toDo);
                        context.ToDos.Remove(toDo);
                    await context.SaveChangesAsync();

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

        public async Task Update(ToDo toDo)
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                using (var transaction = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    context.ToDos.Attach(toDo);
                        context.ToDos.AddOrUpdate(toDo);
                     await context.SaveChangesAsync();

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

        public async Task<List<ToDo>> All()
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                    return await context.ToDos.ToListAsync();
            }
            
        }

        public Task<ToDo> Get(int id)
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                return context.ToDos.FindAsync(id);
            }
        }

        public async Task DeleteAll()
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                using (var transaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    await Task.Run(() => context.Database.ExecuteSqlCommand($"TRUNCATE TABLE {typeof(ToDo).Name}"));

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

        public  async Task Delete(int idDelete)
        {
            using (ToDoListDbContext context = new ToDoListDbContext())
            {
                using (var transaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    await Task.Run(()=> context.ToDos.Remove(Get(idDelete).Result));

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
}
