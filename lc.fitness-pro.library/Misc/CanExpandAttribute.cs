using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    public class CanExpandAttribute : Attribute
    {
        public string FieldTitle { get; set; }

        public CanExpandAttribute(string name) : base()
        {
            FieldTitle = name;
        }
    }
}
