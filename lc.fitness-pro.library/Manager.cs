using System;
using lc.fitnesspro.library.Interface;

namespace lc.fitnesspro.library
{
    public class Manager
    {
        private IConnection connection;

        private PersonRepository personRepository;
        private StudentRepository studentRepository;
        private ContractRepository contractRepository;


        public Manager(string login, string pass)
        {
            connection = new Connection(new Account(login, pass));
        }


        public PersonRepository Person {
            get {
                if (personRepository == null) { personRepository = new PersonRepository(connection); return personRepository; }
                else return personRepository;
            }
        }

        public StudentRepository Student
        {
            get
            {
                if (studentRepository == null) { studentRepository = new StudentRepository(connection); return studentRepository; }
                else return studentRepository;
            }
        }

        public ContractRepository Contract
        {
            get
            {
                if (contractRepository == null) { contractRepository = new ContractRepository(connection); return contractRepository; }
                else return contractRepository;
            }
        }

    }
}
