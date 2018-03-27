using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDollist.Domain;
using ToDollist.Repository;

namespace UnitTestToDoList.Repository
{
    [TestClass()]
    public class RepositoryToDoXmlTests
    {
        [TestMethod()]
        public void AddTest()
        {
            IReposotory<ToDo> repositoryToDo = new RepositoryXml<ToDo>();
            ToDo toDo = new ToDo("test1", new DateTime());
            repositoryToDo.Add(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Count);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            IReposotory<ToDo> repositoryToDo = new RepositoryXml<ToDo>();
            ToDo toDo = new ToDo( "test1", new DateTime());
            repositoryToDo.Add(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Count);
            repositoryToDo.Delete(toDo);
            Assert.AreEqual(0, repositoryToDo.All().Count);

        }

        [TestMethod()]
        public void UpdateTest()
        {
            IReposotory<ToDo> repositoryToDo = new RepositoryXml<ToDo>();
            ToDo toDo = new ToDo("test1", new DateTime());
            repositoryToDo.Add(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Count);
            toDo.Description = ("sdfsdf");
            repositoryToDo.Update(toDo);
            Assert.AreEqual(1, repositoryToDo.All().Count);
            ToDo toDo2 = repositoryToDo.Get(1);
            Assert.AreEqual("sdfsdf", toDo.Description);
        }
    }
}