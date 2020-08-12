using System;
using System.Collections.Generic;

namespace lc.fitnesspro.library.Model
{
    public class ODataResponse<T>
    {
        public IEnumerable<T> value { get; set; }
    }
}
