using System;
using lc.fitness_pro.library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lc.library.test
{
    [TestClass]
    public class QueryStringBuilderTest
    {
        [TestMethod]
        public void AddKeyDropsOtherParams()
        {
            var qsb = new QueryStringBuilder();

            var key = Guid.NewGuid().ToString();

            qsb.AddParam("first", "value");
            qsb.AddParam("second", "value");
            qsb.AddParam("key", key);

            var pattern = $"(guid'{key}')";
            var result = qsb.Build();

            Assert.AreEqual(pattern, result);
        }

        [TestMethod]
        public void AddParamsAproppriateToPattern()
        {
            var qsb = new QueryStringBuilder();

            var key = Guid.NewGuid().ToString();

            qsb.AddParam("first", "value");
            qsb.AddParam("second", "value");

            var pattern = $"?$first=value&$second=value";
            var result = qsb.Build();

            Assert.AreEqual(pattern, result);
        }
    }
}
