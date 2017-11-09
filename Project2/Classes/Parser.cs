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
        public static IEnumerable<IWord> UnionEn(IEnumerable<IWord> en1, IEnumerable<IWord> en2)
        {
            var union = en1.Concat(en2)
                .GroupBy(x => x.Value)
                .Select(x => new Word { Value=x.Key, CountInText=x.Sum(y => y.CountInText), SentenceNumbers = new HashSet<int>(x.SelectMany(y=>y.SentenceNumbers)) });

            return union;
        }
        public static IEnumerable<IWord> SplitIntoWords(string text, int number)
        {
            var concat = Regex.Matches(text, @"\b[A-Za-zА-Яа-я-']+\b")
                .Cast<Match>()
                .Select(x => x.Value.ToLower())
                .GroupBy(x => x)
                .Select(x => new Word { Value = x.Key, CountInText = x.Count(), SentenceNumbers = new HashSet<int> { number } });

            return concat;                      
        }
    }
}
