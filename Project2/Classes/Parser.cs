using Project2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project2.Classes
{
    static class Parser
    {
        public static Dictionary<string, IEnumerable<IWord>> CreateConcordance(IEnumerable<IWord> en)
        {
            return en.OrderBy(x => x.Value)
                .GroupBy(x => x.Value.Substring(0, 1)
                .ToUpper())
                .ToDictionary(x => x.Key, x => x.Select(y=>y));
        }

        public static IEnumerable<IWord> UnionWordEnumerable(IEnumerable<IWord> en1, IEnumerable<IWord> en2)
        {
            return en1.Concat(en2)
                .GroupBy(x => x.Value)
                .Select(x => new Word (x.Key, x.Sum(y => y.CountInText), x.SelectMany(y=>y.PageNumber)));
        }

        public static IEnumerable<IWord> SplitIntoWords(string text, int number)
        {
            return Regex.Matches(text, @"\b[0-9-]*[A-Za-zА-Яа-я']+[A-Za-zА-Яа-я0-9-']*\b")
                .OfType<Match>()
                .Select(x => x.Value.ToLower())
                .GroupBy(x => x)
                .Select(x => new Word(x.Key, x.Count(), number));                  
        }
    }
}
