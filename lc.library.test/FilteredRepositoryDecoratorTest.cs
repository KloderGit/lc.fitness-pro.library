using System;
using lc.fitness_pro.library;
using lc.fitness_pro.library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lc.library.test
{
    [TestClass]
    public class FilteredRepositoryDecoratorTest
    {
        [TestMethod]
        public void PerformFilters()
        {
            var connection = new Connection(new Account("Kloder", "Kaligula2"));

            var repos = new FilteredRepositoryDecorator<Contract>(new Repository<Contract>(connection));

            repos.Filter(x => x.Number == "00-000405")
                .Top(10);

            //var raw = repos.GetByQuery("$filter=Слушатели/any(d: d/Слушатель_Key eq guid'cfcca0d8-70b8-11e9-8105-0cc47a4b75cc')").Result;

            var res = repos.GetByFilter().Result;
        }

        [TestMethod]
        public void GetPersonByContact()
        {
            var connection = new Connection(new Account("Kloder", "Kaligula2"));

            var repos = new FilteredRepositoryDecorator<Person>(new Repository<Person>(connection));

            var raw = repos.GetByQuery("$filter=КонтактнаяИнформация/НомерТелефона eq '89035681122'").Result;

            //var res = repos.GetByFilter().Result;
        }
    }
}
//"guid'c41cb2da-8977-11e6-8102-10c37b94684b'"