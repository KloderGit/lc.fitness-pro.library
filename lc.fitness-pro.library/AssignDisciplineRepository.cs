using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library
{
    public class AssignDisciplineRepository : Repository<AssignDiscipline>
    {
        public AssignDisciplineRepository(IConnection connection)
            : base(connection)
        { }
    }
}
