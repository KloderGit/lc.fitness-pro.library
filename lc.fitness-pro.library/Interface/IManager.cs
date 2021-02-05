using System;
using lc.fitnesspro.library.Model;

namespace lc.fitnesspro.library.Interface
{
    public interface IManager
    {
        PersonRepository Person { get; }
        StudentRepository Student { get; }
        ContractRepository Contract { get; }
        ProgramRepository Program { get; }
        DisciplineRepository Discipline { get; }
        RateRepository Rate { get; }
        ControlRepository Control { get; }
        EmployeeRepository Employee { get; }
        AssignDisciplineRepository AssignDiscipline { get; }
        Repository<EducationType> EducationType { get; }
        Repository<EducationForm> EducationForm { get; }
        Repository<Qualification> Qualification { get; }
        Repository<EducationDirection> EducationDirection { get; }
        Repository<EducationVariant> EducationVariant { get; }
        Repository<EducationGroup> EducationGroup { get; }
        Repository<Group> Group { get; }
        Repository<SubGroup> SubGroup { get; }
    }
}
