using System;
using System.Collections.Generic;

namespace lc.fitness_pro.library.Model
{
    public class ODataResponse<T>
    {
        public IEnumerable<T> value { get; set; }
    }
}
