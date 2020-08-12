using System;
using System.Collections.Generic;
using lc.fitnesspro.library;
using lc.fitnesspro.library.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace lc.library.test
{
    [TestClass]
    public class PersonRepositoryTest
    {
        [TestMethod]
        public void GetByPhone()
        {
            var mock = new Mock<IConnection>();
            var repository = new PersonRepository(mock.Object);

            var sdr = repository.GetByPhones(new List<string> { " 8(903)1453412", "+79996785443 " });
        }

        [TestMethod]
        public void GetByEmail()
        {
            var mock = new Mock<IConnection>();
            var repository = new PersonRepository(mock.Object);

            var sdr = repository.GetByEmails(new List<string> { "kloder@mail.ru ", " kloder3@sdf.com" });
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
