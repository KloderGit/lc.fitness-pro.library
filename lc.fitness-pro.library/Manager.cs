using System;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;

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
        
        private Repository<Group> groupRepository;
        private Repository<SubGroup> subGroupRepository;
        
        private Repository<EducationType> educationTypeRepository;
        private Repository<EducationForm> educationFormRepository;
        private Repository<Qualification> qualificationRepository;
        private Repository<EducationDirection> educationDirectionRepository;
        private Repository<EducationVariant> educationVariantRepository;
        private Repository<EducationGroup> educationGroupRepository;

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

        public Repository<EducationType> EducationType
        {
            get
            {
                if (educationTypeRepository == null) { educationTypeRepository = new Repository<EducationType>(connection); return educationTypeRepository; }
                else return educationTypeRepository;
            }
        }
        
        public Repository<EducationForm> EducationForm
        {
            get
            {
                if (educationFormRepository == null) { educationFormRepository = new Repository<EducationForm>(connection); return educationFormRepository; }
                else return educationFormRepository;
            }
        }
        
        public Repository<Qualification> Qualification
        {
            get
            {
                if (qualificationRepository == null) { qualificationRepository = new Repository<Qualification>(connection); return qualificationRepository; }
                else return qualificationRepository;
            }
        }
        
        public Repository<EducationDirection> EducationDirection
        {
            get
            {
                if (educationDirectionRepository == null) { educationDirectionRepository = new Repository<EducationDirection>(connection); return educationDirectionRepository; }
                else return educationDirectionRepository;
            }
        }
        
        public Repository<EducationVariant> EducationVariant
        {
            get
            {
                if (educationVariantRepository == null) { educationVariantRepository = new Repository<EducationVariant>(connection); return educationVariantRepository; }
                else return educationVariantRepository;
            }
        }
        
        public Repository<EducationGroup> EducationGroup
        {
            get
            {
                if (educationGroupRepository == null) { educationGroupRepository = new Repository<EducationGroup>(connection); return educationGroupRepository; }
                else return educationGroupRepository;
            }
        }
        
        public Repository<Group> Group => groupRepository ?? (groupRepository = new Repository<Group>(connection));
        public Repository<SubGroup> SubGroup => subGroupRepository ?? (subGroupRepository = new Repository<SubGroup>(connection));
    }
}
