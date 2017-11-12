using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Word : IWord
    {
        public string Value { get; private set; }
        public int CountInText { get; private set; }
        public HashSet<int> PageNumber { get; private set; }

        public Word(string value, int countintext, int number)
        {
            Value = value;
            CountInText = countintext;
            PageNumber = new HashSet<int> { number };          
        }

        public Word(string value, int countintext, IEnumerable<int> numbers)
        {
            Value = value;
            CountInText = countintext;
            PageNumber = new HashSet<int>(numbers);
        }      

        public override string ToString()
        {
            return Value.PadRight(40, '.') + CountInText + " : " + String.Join(" ", PageNumber.Select(x => Convert.ToString(x)));
        }
    }
}
