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
        private RateRepository rateRepository;
        private ControlRepository controlRepository;
        private EmployeeRepository employeeRepository;
        private AssignDisciplineRepository assignDisciplineRepository;

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

        public RateRepository Rate
        {
            get
            {
                if (rateRepository == null) { rateRepository = new RateRepository(connection); return rateRepository; }
                else return rateRepository;
            }
        }

        public ControlRepository Control
        {
            get
            {
                if (controlRepository == null) { controlRepository = new ControlRepository(connection); return controlRepository; }
                else return controlRepository;
            }
        }

        public EmployeeRepository Employee
        {
            get
            {
                if (employeeRepository == null) { employeeRepository = new EmployeeRepository(connection); return employeeRepository; }
                else return employeeRepository;
            }
        }

        public AssignDisciplineRepository AssignDiscipline
        {
            get
            {
                if (assignDisciplineRepository == null) { assignDisciplineRepository = new AssignDisciplineRepository(connection); return assignDisciplineRepository; }
                else return assignDisciplineRepository;
            }
        }

    }
}
