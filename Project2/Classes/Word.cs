using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Word
    {
        public string Value { get; private set; }
        public HashSet<int> SestenseNumbers { get; private set; }
        public int CountInText { get; private set; }

        public Word(string value)
        {
            this.Value = value;
        }



    }
}
