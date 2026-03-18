using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;

namespace lc.fitnesspro.library
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(IConnection connection)
            : base(connection)
        { }
    }
}
