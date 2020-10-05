using System;
using lc.fitnesspro.library.Interface;

namespace lc.fitnesspro.library
{
    public class Manager : IManager
    {
        private IConnection connection;

        private PersonRepository personRepository;
        private StudentRepository studentRepository;
        private ContractRepository contractRepository;
        private ProgramRepository programRepository;
        private DisciplineRepository disciplineRepository;

        public Manager(string login, string pass)
        {
            connection = new Connection(new Account(login, pass));
        }

        public Manager(IConnection connection)
        {
            _ = connection ?? throw new ArgumentNullException(nameof(connection));
            this.connection = connection;
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

        public ProgramRepository Program
        {
            get
            {
                if (programRepository == null) { programRepository = new ProgramRepository(connection); return programRepository; }
                else return programRepository;
            }
        }

        public DisciplineRepository Discipline
        {
            get
            {
                if (disciplineRepository == null) { disciplineRepository = new DisciplineRepository(connection); return disciplineRepository; }
                else return disciplineRepository;
            }
        }
    }
}
