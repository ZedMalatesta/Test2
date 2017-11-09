using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Word : IWord
    {
        public string Value { get; set; }
        public HashSet<int> SentenceNumbers { get; set; }
        public int CountInText { get; set; }

        /*public Word(string value)
        {
            this.Value = value;
        }*/




    }
}
