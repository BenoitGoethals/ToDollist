using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Domain;
using ToDoList.Service.Service;

namespace ToDoList.ServiceTests1.Service
{
    [TestClass()]
    public class ServiceToDoTests
    {
        [TestMethod()]
        public async Task AddTest()
        {

            IService<ToDo> service = new ServiceToDo();
            await service.DeleteAll();
            var toDo = new ToDo("test1", new DateTime(), new DateTime(), Status.Created);
            await service.Add(toDo);
            Assert.AreEqual(1, service.All().Result.Count);

        }

        [TestMethod()]
        public async Task AddBulkTest()
        {

            IService<ToDo> service = new ServiceToDo();
            await service.DeleteAll();
            
            for (int i = 0; i < 20; i++)
            {

                await service.Add(new ToDo("test1", new DateTime(), new DateTime(), Status.Created));

            }
            Assert.AreEqual(20, service.All().Result.Count);


        }


        [TestMethod()]
        public async Task DeleteTest()
        {
            IService<ToDo> service = new ServiceToDo();
            await service.DeleteAll();
            ToDo toDo = new ToDo("test1", new DateTime(), new DateTime(), Status.Created);
            await service.Add(toDo);
            Assert.AreEqual(1, service.All().Result.Count);
            await service.Delete(toDo);
            Assert.AreEqual(0, service.All().Result.Count);

        }

        [TestMethod()]
        public async Task UpdateTest()
        {
            IService<ToDo> service = new ServiceToDo();
            await service.DeleteAll();
            ToDo toDo = new ToDo("test1", new DateTime(), new DateTime(), Status.Created);
            await service.Add(toDo);
            Assert.AreEqual(1, service.All().Result.Count);
            toDo.Description = ("sdfsdf");
            await service.Update(toDo);
            Assert.AreEqual(1, service.All().Result.Count);
            ToDo toDo2 = service.Get(1).Result;
            Assert.AreEqual("sdfsdf", toDo.Description);
        }
    }
}