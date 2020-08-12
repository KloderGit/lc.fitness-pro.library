using System;
using System.Linq;
using lc.fitnesspro.library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lc.library.test
{
    [TestClass]
    public class ContractTest
    {
        [TestMethod]
        public void AddedStudenUnittHasLineNumber()
        {
            var contract = new Contract();

            var key = Guid.NewGuid();

            var student = new RegisterStudent()
            {
                StudentKey = key
            };

            contract.AddRegisterUnit(student);

            var unit = contract.Registry.FirstOrDefault(x => x.StudentKey == key);

            Assert.IsNotNull(unit);
            Assert.IsFalse(String.IsNullOrEmpty(unit.LineNumber));
            Assert.AreEqual("1", unit.LineNumber);
        }

        [TestMethod]
        public void AddedStudensRecountLineNumber()
        {
            var contract = new Contract();

            var student1 = new RegisterStudent() { StudentKey = Guid.NewGuid() };
            var student2 = new RegisterStudent() { StudentKey = Guid.NewGuid() };
            var student3 = new RegisterStudent() { StudentKey = Guid.NewGuid() };

            contract.AddRegisterUnit(student1);
            contract.AddRegisterUnit(student2);
            contract.AddRegisterUnit(student3);

            Assert.AreEqual(3, contract.Registry.Count);

            var count = 1;
            foreach(var item in contract.Registry)
            {
                Assert.AreEqual(count.ToString(), item.LineNumber);
                count++;
            }
        }

        [TestMethod]
        public void RemovertudensRecountLineNumber()
        {
            var contract = new Contract();

            var key = Guid.NewGuid();
            var student1 = new RegisterStudent() { StudentKey = Guid.NewGuid() };
            var student2 = new RegisterStudent() { StudentKey = key };
            var student3 = new RegisterStudent() { StudentKey = Guid.NewGuid() };

            contract.AddRegisterUnit(student1);
            contract.AddRegisterUnit(student2);
            contract.AddRegisterUnit(student3);

            var removingUnit = contract.Registry.FirstOrDefault(x=>x.StudentKey == key);

            contract.RemoveRegisterUnit(removingUnit);

            var count = 1;
            foreach (var item in contract.Registry)
            {
                Assert.AreEqual(count.ToString(), item.LineNumber);
                count++;
            }
        }
    }
}
