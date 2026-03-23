using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
        
        [TestMethod]
        public async Task GetStudentsInfoRequest()
        {
            var mock = new Mock<IConnection>();
            var repository = new StudentRepository(mock.Object);
            
                var educationProgramKeys = new List<Guid>{Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};
                var groupKeys = new List<Guid>{Guid.NewGuid()};
                List<Guid> subGroupKeys = null; // new List<Guid>();
                int? top = 10;
                int? skip = 5;
                bool? isArchivedIncluded = null;

                var programFilter = educationProgramKeys is null || educationProgramKeys.Count == 0
                    ? " and (ПрограммаОбучения_Key ne guid'00000000-0000-0000-0000-000000000000')"
                    : " and (" + String.Join(" or ", educationProgramKeys.Select(x => GetItemFilter("ПрограммаОбучения_Key", x))) + ")";
            
                var groupFilter = groupKeys is null || groupKeys.Count == 0
                    ? ""
                    : " and (" + String.Join(" or ", groupKeys.Select(x=>GetItemFilter("ГруппаСлушателя_Key", x))) + ")";
            
                var subGroupFilter = subGroupKeys is null || subGroupKeys.Count == 0
                    ? ""
                    : " and (" + String.Join(" or ", subGroupKeys.Select(x=>GetItemFilter("ПодгруппаСлушателя_Key", x))) + ")";
            
                var topFilter = top is null
                    ? ""
                    : $"&$top={top}";
            
                var skipFilter = skip is null
                    ? ""
                    : $"&$skip={skip}";

                var isArchivedFilter = isArchivedIncluded is null || isArchivedIncluded.Value == true
                    ? ""
                    : " and (ПрограммаОбучения/Статус ne 'Архивный')";
            
                var requestStringTemplate =
                    "?$format=json" +
                    "&$expand=ПрограммаОбучения,Слушатель,ГруппаСлушателя,ПодгруппаСлушателя" +
                    "&$select=ПрограммаОбучения/Ref_Key," +
                    "ПрограммаОбучения/Description," +
                    "Слушатель/Ref_Key," +
                    "Слушатель/Description," +
                    "ГруппаСлушателя/Ref_Key," +
                    "ГруппаСлушателя/Description," +
                    "ПодгруппаСлушателя/Ref_Key," +
                    "ПодгруппаСлушателя/Description" +
                    "&$filter=(DeletionMark eq false)" +
                    " and (ГрупповойДоговор eq false)" +
                    isArchivedFilter + 
                    programFilter + groupFilter + subGroupFilter + topFilter + skipFilter;
            ;
            
            string GetItemFilter(string field, Guid programKey) => $"{field} eq '{programKey}'";
        }
    }
}
