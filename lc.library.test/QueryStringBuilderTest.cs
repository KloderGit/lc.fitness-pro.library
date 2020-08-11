using System;
using System.Linq.Expressions;
using lc.fitness_pro.library;
using lc.fitness_pro.library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lc.library.test
{
    [TestClass]
    public class QueryStringBuilderTest
    {
        [TestMethod]
        public void AddKey()
        {
            var qsb = new QueryStringBuilder();

            var key = Guid.NewGuid();

            qsb.AddKey(key);

            var pattern = $"(guid'{key}')?$format=json";
            var result = qsb.Build();

            Assert.AreEqual(pattern, result);
        }

        [TestMethod]
        public void AddFilter()
        {
            var qsb = new QueryStringBuilder();
            var key = Guid.NewGuid();
            Expression<Func<Person, bool>> exp1 = x => x.Key == key;

            qsb.AddFilter(exp1);

            var pattern = $"?$filter=Ref_Key eq guid'{key}'&$format=json";
            var result = qsb.Build();

            Assert.AreEqual(pattern, result);
        }
    }
}
