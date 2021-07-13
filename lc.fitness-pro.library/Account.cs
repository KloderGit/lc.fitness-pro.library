using System;
using System.Collections.Generic;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;

namespace lc.fitnesspro.library
{
    public class Account : IAccount
    {
        private string login;
        private string password;

        private IDictionary<Type, string> dictionary = new Dictionary<Type, string>();

        public Account()
        {
            FillDictionary();
        }
        public Account(string login, string password) : this()
        {
            this.login = login;
            this.password = password;
        }

        public string GetEndPoint(Type key)
        {
            return dictionary[key];
        }

        private void FillDictionary()
        {
            dictionary.Add(typeof(Person), "1CDB_FPA_DPO/odata/standard.odata/Catalog_ФизическиеЛица");
            dictionary.Add(typeof(Group), "1CDB_FPA_DPO/odata/standard.odata/Catalog_Группы");
            dictionary.Add(typeof(SubGroup), "1CDB_FPA_DPO/odata/standard.odata/Catalog_УчебныеПодгруппы");
            dictionary.Add(typeof(Student), "1CDB_FPA_DPO/odata/standard.odata/Catalog_СлушателиКурсов");
            dictionary.Add(typeof(Contract), "1CDB_FPA_DPO/odata/standard.odata/Document_ДоговорСлушателя");
            //dictionary.Add(typeof(Order), "1CDB_FPA_DPO/odata/standard.odata/Document_ПриказПоСлушателям");
            dictionary.Add(typeof(Program), "1CDB_FPA_DPO/odata/standard.odata/Catalog_ЦиклыДПО");
            //dictionary.Add(typeof(Counterpart), "1CDB_FPA_DPO/odata/standard.odata/Catalog_Контрагенты");
            dictionary.Add(typeof(Discipline), "1CDB_FPA_DPO/odata/standard.odata/Catalog_Дисциплины");
            dictionary.Add(typeof(Rate), "1CDB_FPA_DPO/odata/standard.odata/Catalog_Оценки");
            dictionary.Add(typeof(Control), "1CDB_FPA_DPO/odata/standard.odata/Catalog_ФормыКонтроляДПО");
            dictionary.Add(typeof(Employee), "1CDB_FPA_DPO/odata/standard.odata/Catalog_Сотрудники");
            dictionary.Add(typeof(AssignDiscipline), "1CDB_FPA_DPO/odata/standard.odata/Document_УстановкаДисциплинДляПреподавателя");
            
            dictionary.Add(typeof(EducationType), "1CDB_FPA_DPO/odata/standard.odata/Catalog_ВидыДопОбразования");
            dictionary.Add(typeof(EducationForm), "1CDB_FPA_DPO/odata/standard.odata/Catalog_ФормыОбучения");
            dictionary.Add(typeof(Qualification), "1CDB_FPA_DPO/odata/standard.odata/Catalog_Квалификации");
            dictionary.Add(typeof(EducationDirection), "1CDB_FPA_DPO/odata/standard.odata/Catalog_СпециальностиДПО");
            dictionary.Add(typeof(EducationVariant), "1CDB_FPA_DPO/odata/standard.odata/Catalog_ПФ_ТипМероприятия");
            dictionary.Add(typeof(EducationGroup), "1CDB_FPA_DPO/odata/standard.odata/Catalog_ПФ_ГруппыПрограммОбучения");
            dictionary.Add(typeof(AttestationTable), "1CDB_FPA_DPO/odata/standard.odata/Document_ЭкзаменационнаяВедомостьДПО");
            
            //dictionary.Add(typeof(PayDocument), "1CDB_FPA_DPO/odata/standard.odata/Document_РегистрацияОплатИВозвратов");
        }

        public string GetLogin()
        {
            return login;
        }

        public string GetPassword()
        {
            return password;
        }
    }

}
