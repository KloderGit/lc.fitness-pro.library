using lc.fitnesspro.library.Misc;
using lc.fitnesspro.library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lc.library.test
{
    [TestClass]
    public class QueryTest
    {
        [TestMethod]
        public void QueryTreeTest()
        {
            var query = new QueryBuilder<Person>();

            query.Filter(x => x.Key == Guid.NewGuid());
            query.And();
            query.Filter(x => x.DeletionMark == false);

            query.Build();
        }

        [TestMethod]
        public void QueryNestedTreeTest()
        {
            var query = new QueryBuilder<Person>();

            query.Filter(x => x.DeletionMark == false);
            query.AndAlso();
            query.Filter(x => x.Contacts.Any(y => y.Phone == "8 (909) 563-57-96"));
            query.Or();
            query.Filter(x => x.Contacts.Any(y => y.Phone == "8 (904) 658-20-76"));
            query.Or();
            query.Filter(x => x.Contacts.Any(y => y.Phone == "8 (926) 889-24-71"));
            query.Or();
            query.Filter(x => x.Contacts.Any(y => y.Email == "makesa1@yandex.ru"));
            query.Or();
            query.Filter(x => x.Contacts.Any(y => y.Email == "elenahrupalova@yandex.ru"));
            query.Or();
            query.Filter(x => x.Contacts.Any(y => y.Email == "olyazubkova2000@mail.ru"));

            var tret = query.Build();
        }
    }
}
