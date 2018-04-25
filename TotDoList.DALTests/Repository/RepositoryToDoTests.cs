using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Domain;
using TotDoList.DAL.Repository;

namespace TotDoList.DALTests.Repository
{
    [TestClass()]
    public class RepositoryToDoTests
    {
        [TestMethod()]
        public async Task AddTest()
        {

            IReposotory<ToDo> repositoryToDo = new ToDoRepository();
            ToDo toDo=new ToDo("test1",new DateTime(),new DateTime(),Status.Created );
           await repositoryToDo.AddAsync(toDo);
            Assert.AreEqual(1,repositoryToDo.All().Result.Count);

        }

        [TestMethod()]
        public async Task AddBulkTest()
        {
            
            IReposotory<ToDo> repositoryToDo = new ToDoRepository();
            for (int i = 0; i < 20; i++)
            {

               await repositoryToDo.AddAsync(new ToDo("test1", new DateTime(), new DateTime(), Status.Created));
                
            }
            Assert.AreEqual(20, repositoryToDo.All().Result.Count);


        }


        [TestMethod()]
        public async Task DeleteTest()
        {
            IReposotory<ToDo> repositoryToDo = new ToDoRepository();
            ToDo toDo = new ToDo("test1", new DateTime(), new DateTime(), Status.Created);
            await repositoryToDo.AddAsync(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Result.Count);
            await repositoryToDo.Delete(toDo);
            Assert.AreEqual(0, repositoryToDo.All().Result.Count);

        }

        [TestMethod()]
        public async Task UpdateTest()
        {
            IReposotory<ToDo> repositoryToDo = new ToDoRepository();
            ToDo toDo =  new ToDo("test1", new DateTime(), new DateTime(), Status.Created);
            await repositoryToDo.AddAsync(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Result.Count);
            toDo.Description=("sdfsdf");
            await repositoryToDo.Update(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Result.Count);
           ToDo toDo2= repositoryToDo.Get(1).Result;
            Assert.AreEqual("sdfsdf", toDo.Description);
        }

    }
}