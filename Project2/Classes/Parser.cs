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
        public static IEnumerable<IWord> CreateConcordance(IEnumerable<IWord> en)
        {
            var concord = en.OrderBy(x => x.Value).GroupBy(x => x.Value.Substring(0, 1).ToUpper()).ToDictionary(x => x.Key, x => x.Select(y=>y));
            foreach (var u in concord.Keys)
            {
                Console.WriteLine(u);
                foreach (var a in concord[u])
                {
                    Console.Write(a.Value + ":" + a.CountInText + ":");
                    foreach (int z in a.LineNumber)
                    {
                        Console.Write(z + ",");
                    }
                    Console.WriteLine();
                }
                
            }
            return concord;
        }
        public static IEnumerable<IWord> UnionEn(IEnumerable<IWord> en1, IEnumerable<IWord> en2)
        {
            var union = en1.Concat(en2)
                .GroupBy(x => x.Value)
                .Select(x => new Word { Value=x.Key, CountInText=x.Sum(y => y.CountInText), LineNumber = new HashSet<int>(x.SelectMany(y=>y.LineNumber)) });

            return union;
        }
        public static IEnumerable<IWord> SplitIntoWords(string text, int number)
        {
            var concat = Regex.Matches(text, @"\b[A-Za-zА-Яа-я-']+\b")
                .OfType<Match>()
                .Select(x => x.Value.ToLower())
                .GroupBy(x => x)
                .Select(x => new Word { Value = x.Key, CountInText = x.Count(), LineNumber = new HashSet<int> { number } });

            return concat;                      
        }
        /*public static Dictionary<char, IWord> AllTextConvocation(string text)
        {
            var concat = Regex.Matches(text, @"\b[A-Za-zА-Яа-я-']+\b")
                .Cast<Match>()
                .Select(x => x.Value.ToLower())
                .GroupBy(x => x)
                .Select(x => new Word { Value = x.Key, CountInText = x.Count(), LineNumber = new HashSet<int> { number } });

            return concat;
        }*/
    }
}
