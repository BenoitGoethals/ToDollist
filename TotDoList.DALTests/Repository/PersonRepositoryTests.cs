using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Domain;
using TotDoList.DAL.Repository;

namespace TotDoList.DALTests.Repository
{
    [TestClass()]
    public class PersonRepositoryTests
    {
        [TestMethod()]
        public async Task AddTest()
        {

            IReposotory<Person> repo = new PersonRepository();
            await repo.DeleteAll();
          Person person=new Person()
          {
              City = "Gent",
              ForName = "Benoit",
              Gender = Gender.Men,
              Name="benoit",
              Nr="65456",
              Street  ="LUlstaat",
              ZipCode = "9852"
          };
            await repo.AddAsync(person);
            Assert.AreEqual(1, repo.All().Result.Count);

        }

        [TestMethod()]
        public async Task AddBulkTest()
        {

            IReposotory<Person> repo = new PersonRepository();
            await repo.DeleteAll();
            for (int i = 0; i < 20; i++)
            {

                await repo.AddAsync(new Person()
                {
                    City = "Gent",
                    ForName = "Benoit"+i,
                    Gender = Gender.Men,
                    Name = "benoit"+i,
                    Nr = "65456",
                    Street = "LUlstaat",
                    ZipCode = "9852"
                });

            }
            Assert.AreEqual(20, repo.All().Result.Count);


        }


        [TestMethod()]
        public async Task DeleteTest()
        {
            IReposotory<Person> repo = new PersonRepository();
            await repo.DeleteAll();
            Person person = new Person()
            {
                City = "Gent",
                ForName = "Benoit",
                Gender = Gender.Men,
                Name = "benoit",
                Nr = "65456",
                Street = "LUlstaat",
                ZipCode = "9852"
            };
            await repo.AddAsync(person);
            Assert.AreEqual(1, repo.All().Result.Count);
            await repo.Delete(person);
            Assert.AreEqual(0, repo.All().Result.Count);

        }

        [TestMethod()]
        public async Task UpdateTest()
        {
            IReposotory<Person> repo = new PersonRepository();
            await repo.DeleteAll();
            Person person = new Person()
            {
                City = "Gent",
                ForName = "Benoit",
                Gender = Gender.Men,
                Name = "benoit",
                Nr = "65456",
                Street = "LUlstaat",
                ZipCode = "9852"
            };
            await repo.AddAsync(person);
            Assert.AreEqual(1, repo.All().Result.Count);
            person.City = "antwerp";
            await repo.Update(person);
            Assert.AreEqual(1, repo.All().Result.Count);
            Person pers2 = repo.Get(1).Result;
            Assert.AreEqual("antwerp", pers2.City);
        }
    }
}