using System;
using System.Collections.Generic;
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
    }
}
