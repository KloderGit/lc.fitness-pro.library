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

            var request = new StudentRepository.FilterStudentInfoRequest
            {
                //EducationProgramKeys = new List<Guid>{Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()},
                //GroupKeys = new List<Guid>{Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()},
                //SubGroupKeys = new List<Guid>{Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()},
                Top = 10,
                Skip = 5
            };

            var programFilter = request.EducationProgramKeys.Count == 0
                ? " and (ПрограммаОбучения_Key ne '00000000-0000-0000-0000-000000000000')"
                : " and (" + String.Join(" or ", request.EducationProgramKeys.Select(x => GetItemFilter("ПрограммаОбучения_Key", x))) + ")";
            
            var groupFilter = request.GroupKeys.Count == 0
                ? " and (ГруппаСлушателя_Key ne '00000000-0000-0000-0000-000000000000')"
                : " and (" + String.Join(" or ", request.GroupKeys.Select(x=>GetItemFilter("ГруппаСлушателя_Key", x))) + ")";
            
            var subGroupFilter = request.SubGroupKeys.Count == 0
                ? ""
                : " and" + String.Join(" or ", request.SubGroupKeys.Select(x=>GetItemFilter("ПодгруппаСлушателя_Key", x))) + ")";
            
            var topFilter = request.Top is null
                ? ""
                : $"&$top={request.Top}";
            
            var skipFilter = request.Skip is null
                ? ""
                : $"&$skip={request.Skip}";
            
            var requestStringTemplate =
                "$format=json" +
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
                " and (ГрупповойДоговор eq false)"
                + programFilter + groupFilter + subGroupFilter + topFilter + skipFilter;
            ;
            
            string GetItemFilter(string field, Guid programKey) => $"{field} eq '{programKey}'";
        }
    }
}
