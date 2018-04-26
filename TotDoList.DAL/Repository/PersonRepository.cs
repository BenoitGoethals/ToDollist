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
   public class PersonRepository : IReposotory<Person>, IDisposable
    {
        public PersonRepository()
        {
            _context.Database.Initialize(false);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public void Deconstruct(out ToDoListDbContext context)
        {
            context = _context;
        }

        private readonly ToDoListDbContext _context = new ToDoListDbContext();
        private static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public async Task AddAsync(Person person)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _context.Persons.Add(person);
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

        public async Task Delete(Person person)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _context.Persons.Remove(person);
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

        public async Task Update(Person person)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _context.Persons.AddOrUpdate(person);
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

        public Task<List<Person>> All()
        {
            return _context.Persons.ToListAsync<Person>();
        }

        public Task<Person> Get(int id)
        {
            return _context.Persons.FindAsync(id);
        }

        public async Task DeleteAll()
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var all= _context.Persons.ToListAsync<Person>();
                        foreach (var pers in all.Result)
                        {
                            _context.Persons.Remove(pers);

                        }
                        _context.SaveChangesAsync();
                        // return _context.Database.ExecuteSqlCommand($"TRUNCATE TABLE {typeof(Person).Name}");
                    });

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    transaction.Rollback();
                }

            }
        }

        public async Task Delete(int idDelete)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    await Task.Run(() => _context.Persons.Remove(Get(idDelete).Result));

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

