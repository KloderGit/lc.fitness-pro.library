using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library
{
    public class ProgramRepository : Repository<Program>
    {
        public ProgramRepository(IConnection connection)
            : base(connection)
        { }


    }
}
