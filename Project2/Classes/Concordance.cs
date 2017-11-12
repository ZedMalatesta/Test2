using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Concordance
    {
        private Dictionary<string, IEnumerable<IWord>> ABIndex { get; set; }

        public Concordance(Dictionary<string, IEnumerable<IWord>> abindex)
        {
            ABIndex = abindex;
        }

        public override string ToString()
        {
             return String.Join("\n", (ABIndex.Select(x => x.Key+"\n"+String.Join("\n", x.Value.Select(y=>y.ToString())))));
        }
    }
}
