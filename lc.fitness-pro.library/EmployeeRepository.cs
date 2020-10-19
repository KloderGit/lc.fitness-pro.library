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
    public class EmployeeRepository : Repository<Control>
    {
        public EmployeeRepository(IConnection connection)
            : base(connection)
        {}
    }
}
