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
        private AttestationTableRepository attestationTableRepository;
        
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

        public PersonRepository Person => personRepository ?? (personRepository = new PersonRepository(connection));
        public StudentRepository Student => studentRepository ?? (studentRepository = new StudentRepository(connection));
        public ContractRepository Contract => contractRepository ?? (contractRepository = new ContractRepository(connection));
        public ProgramRepository Program => programRepository ?? (programRepository = new ProgramRepository(connection));
        public DisciplineRepository Discipline => disciplineRepository ?? (disciplineRepository = new DisciplineRepository(connection));
        public RateRepository Rate => rateRepository ?? (rateRepository = new RateRepository(connection));
        public ControlRepository Control => controlRepository ?? (controlRepository = new ControlRepository(connection));
        public EmployeeRepository Employee => employeeRepository ?? (employeeRepository = new EmployeeRepository(connection));
        public AssignDisciplineRepository AssignDiscipline => assignDisciplineRepository ?? (assignDisciplineRepository = new AssignDisciplineRepository(connection));
        public Repository<EducationType> EducationType => educationTypeRepository ?? (educationTypeRepository = new Repository<EducationType>(connection));
        public Repository<EducationForm> EducationForm => educationFormRepository ?? (educationFormRepository = new Repository<EducationForm>(connection));
        public Repository<Qualification> Qualification => qualificationRepository ?? (qualificationRepository = new Repository<Qualification>(connection));
        public Repository<EducationDirection> EducationDirection => educationDirectionRepository ?? (educationDirectionRepository = new Repository<EducationDirection>(connection));
        public Repository<EducationVariant> EducationVariant => educationVariantRepository ?? (educationVariantRepository = new Repository<EducationVariant>(connection));
        public Repository<EducationGroup> EducationGroup => educationGroupRepository ?? (educationGroupRepository = new Repository<EducationGroup>(connection));
        public Repository<Group> Group => groupRepository ?? (groupRepository = new Repository<Group>(connection));
        public Repository<SubGroup> SubGroup => subGroupRepository ?? (subGroupRepository = new Repository<SubGroup>(connection));
        public Repository<AttestationTable> AttestationTable => attestationTableRepository ?? (attestationTableRepository = new AttestationTableRepository(connection));
    }
}
