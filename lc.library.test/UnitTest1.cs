using lc.fitness_pro.library;
using lc.fitness_pro.library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lc.library.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connection = new Connection(new Account("Kloder", "Kaligula2"));

            var repos = new Repository<Person>(connection);

            //var person = repos.GetById(new System.Guid("c41cb2da-8977-11e6-8102-10c37b94684b")).Result;

            var www = repos.GetByQuery("$filter=Гражданство_Key eq guid'4e127564-d74f-4dd9-bced-0327f0f4e061'&$top=100").Result;

        }
    }
}
