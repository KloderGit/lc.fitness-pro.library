using System;
using System.Collections.Generic;

namespace lc.fitness_pro.library.Interface
{
    public interface IDocument
    {
        //ICollection<IRegisterUnit> Registry { get; }

        void AddRegisterUnit(IRegisterUnit item);
        void RemoveRegisterUnit(IRegisterUnit item);
    }
}
