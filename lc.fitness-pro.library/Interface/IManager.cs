using System;
namespace lc.fitnesspro.library.Interface
{
    public interface IManager
    {
        PersonRepository Person { get; }
        StudentRepository Student { get; }
        ContractRepository Contract { get; }
        ProgramRepository Program { get; }
    }
}
