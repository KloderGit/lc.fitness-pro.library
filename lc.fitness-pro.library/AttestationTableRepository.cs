using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;

namespace lc.fitnesspro.library
{
    internal class AttestationTableRepository : Repository<AttestationTable>
    {
        public AttestationTableRepository(IConnection connection)
            : base(connection)
        { }
    }
}