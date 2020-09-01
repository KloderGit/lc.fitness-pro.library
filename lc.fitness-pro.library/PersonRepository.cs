using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lc.fitnesspro.library;
using lc.fitnesspro.library.Extension;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;

namespace lc.fitnesspro.library
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(IConnection connection)
            : base(connection)
        {}

        public async Task<IEnumerable<Person>> GetByPhones(IEnumerable<string> phones)
        {
            var array = CreatePhoneQueryStringArray(phones);
            return await GetContactQuery(array);
        }

        public async Task<IEnumerable<Person>> GetByEmails(IEnumerable<string> emails)
        {
            var array = CreateEmailQueryStringArray(emails);
            return await GetContactQuery(array);
        }

        public async Task<IEnumerable<Person>> GetByContacts(PersonContactDto contacts)
        {
            var array = CreatePhoneQueryStringArray(contacts.phones)
                        .Concat(CreateEmailQueryStringArray(contacts.emails));
            return await GetContactQuery(array);
        }

        private async Task<IEnumerable<Person>> GetContactQuery(IEnumerable<string> array)
        {
            var query = "?$filter= DeletionMark eq false and (" + String.Join(" or ", array) + ")" + "&$format=json";
            var result = await GetByQuery(query);
            return result;
        }

        private IEnumerable<string> CreatePhoneQueryStringArray(IEnumerable<string> phones)
        {
            if (phones == null || phones.Count() == 0) return new List<string>();

            var array = phones.Select(x => PhoneToQuery(x));

            return array;

            string PhoneToQuery(string phone) => $"endswith(КонтактнаяИнформация/НомерТелефона, '{phone.PhoneWithoutCode()}')";
            
        }

        private IEnumerable<string> CreateEmailQueryStringArray(IEnumerable<string> emails)
        {
            if (emails == null || emails.Count() == 0) return new List<string>();

            var array = emails.Select(x => EmailToQuery(x));

            return array;

            string EmailToQuery(string email) => $"КонтактнаяИнформация/АдресЭП eq '{email.ClearEmail()}'";
        }
    }

    public class PersonContactDto
    {
        public IEnumerable<string> phones { get; set; }
        public IEnumerable<string> emails { get; set; }

    }
}
