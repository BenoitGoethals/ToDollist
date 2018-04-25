using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Domain;
using TotDoList.DAL.Repository;

namespace TotDoList.DALTests.Repository
{
    [TestClass()]
    public class RepositoryToDoTests
    {
        [TestMethod()]
        public void AddTest()
        {
  
            IReposotory<ToDo> repositoryToDo=new RepositoryMeM<ToDo>();
            ToDo toDo=new ToDo("test1",new DateTime(),new DateTime(),Status.Created );
            repositoryToDo.Add(toDo);
            Assert.AreEqual(1,repositoryToDo.All().Result.Count);

        }

        [TestMethod()]
        public void AddBulkTest()
        {
            
            IReposotory<ToDo> repositoryToDo = new RepositoryMeM<ToDo>();
            for (int i = 0; i < 20; i++)
            {

                repositoryToDo.Add(new ToDo("test1", new DateTime(), new DateTime(), Status.Created));
                
            }
            Assert.AreEqual(20, repositoryToDo.All().Result.Count);


        }


        [TestMethod()]
        public void DeleteTest()
        {
            IReposotory<ToDo> repositoryToDo = new RepositoryMeM<ToDo>();
            ToDo toDo = new ToDo("test1", new DateTime(), new DateTime(), Status.Created);
            repositoryToDo.Add(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Result.Count);
            repositoryToDo.Delete(toDo);
            Assert.AreEqual(0, repositoryToDo.All().Result.Count);

        }

        [TestMethod()]
        public void UpdateTest()
        {
            IReposotory<ToDo> repositoryToDo = new RepositoryMeM<ToDo>();
            ToDo toDo =  new ToDo("test1", new DateTime(), new DateTime(), Status.Created);
            repositoryToDo.Add(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Result.Count);
            toDo.Description=("sdfsdf");
            repositoryToDo.Update(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Result.Count);
           ToDo toDo2= repositoryToDo.Get(1).Result;
            Assert.AreEqual("sdfsdf", toDo.Description);
        }

    }
}