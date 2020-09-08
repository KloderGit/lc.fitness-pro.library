using System;
using System.Collections.Generic;
using System.Linq;
using lc.fitnesspro.library;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace lc.library.test
{
    [TestClass]
    public class PersonRepositoryIntegativeTest
    {
        [TestMethod]
        public void GenerateQuery()
        {
            var conn = new Connection(new Account("Kloder", "Kaligula2"));
            var pero = new Repository<Contract>(conn);

            var gd = new Guid("ec4bf44a-e06b-11ea-812d-0cc47a4b75cc");

            var sdr = pero.Filter(x => x.Registry.Any(y => y.StudentKey == gd));

            var tert = sdr.GetByFilter().Result;

        }



        [TestMethod]
        public void GetByPhone()
        {
            var manager = new Manager("Kloder", "Kaligula2");

            var sdr = manager.Person.GetByPhones(new List<string> { " 8(903)1453412" }).Result;
        }

        [TestMethod]
        public void GetByEmail()
        {
            var connection = new Connection(new Account("Kloder", "Kaligula2"));

            var repository = new PersonRepository(connection);

            var sdr = repository.GetByEmails(new List<string> { "kloder@mail.ru ", " kloder3@sdf.com" }).Result;
        }

        [TestMethod]
        public void GetByContacts()
        {
            var mock = new Mock<IConnection>();
            var repository = new PersonRepository(mock.Object);

            var sdr = repository.GetByContacts(new PersonContactDto
            {
                phones = new List<string> { " 8(903)1453412", "+79996785443 " },
                emails = new List<string> { "kloder@mail.ru ", " kloder3@sdf.com" }
            });
            
        }
    }
}
