using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lc.fitnesspro.library
{
    public class ProgramRepository : Repository<Program>
    {
        private bool includeDiscipline = false;

        public ProgramRepository(IConnection connection)
            : base(connection)
        { }

        public ProgramRepository IncludeDiscipline(bool value)
        {
            includeDiscipline = value;
            return this;
        }

        public override async Task<IEnumerable<Program>> GetByFilter()
        {
            var programs = await base.GetByFilter();

            if (includeDiscipline) programs = await IncludeDiscipline(programs);

            return programs;
        }

        private async Task<IEnumerable<Program>> IncludeDiscipline(IEnumerable<Program> programs)
        {
            var disciplineKeys = programs.SelectMany(x => x.Disciplines.Select(d => d.DisciplineKey));

            var repository = new DisciplineRepository(connection);

            var query = disciplineKeys.Aggregate(repository,
                    (repo, val) =>
                    {
                        repo.Filter(x => x.Key == val);
                        _ = val == disciplineKeys.Last() ? repository : repository.Or();
                        return repo;
                    }
                );

            var disciplines = await query.GetByFilter();

            var extend = programs.ToList();

            extend.ForEach( x=>
                    {
                        var disciplineInfo = x.Disciplines.ToList();

                        disciplineInfo.ForEach( di =>
                                di.Discipline = disciplines.FirstOrDefault(g=>di.DisciplineKey == g.Key)
                            );
                    }
                );

            return extend;
        }
    }
}
