using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    internal class Tree
    {
        public LinkedList<ReduceExpressionInfo> NodeExpression { get; set; } = new LinkedList<ReduceExpressionInfo>();
        public Tree Child { get; set; }
        public string JoinType { get; set; }
    }
}
