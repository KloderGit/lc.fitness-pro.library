using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using lc.fitnesspro.library;
using lc.fitnesspro.library.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace lc.library.test
{
    [TestClass]
    public class ContractRepositoryTest
    {
        [TestMethod]
        public void GetByStudents()
        {
            var mock = new Mock<IConnection>();
            var repository = new ContractRepository(mock.Object);

            var sdr = repository.GetByStudents(new List<Guid> {
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
            });
        }

        [TestMethod]
        public void GetPerson()
        {
            var mock = new Mock<IConnection>();
            var repository = new PersonRepository(mock.Object);

            var sdr = repository.Filter(x=>x.Contacts.Any(e=>e.Phone.EndsWith("9206734970")))
                .Or()
                .Filter(x => x.Contacts.Any(e => e.Phone.EndsWith("9685468088")))
                .GetByFilter().Result;
        }
    }
}
