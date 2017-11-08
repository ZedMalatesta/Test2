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
        /*public static IEnumerable<string> SplitIntoWords(string text)
        {
            return Regex.Matches(text, @"\b[А-яа-яA-Za-z-']+\b")
                     .Cast<Match>()
                     .Select(match => match.Value.ToLower());
        }*/
        public static IEnumerable<IWord> UnionEn(IEnumerable<IWord> en1, IEnumerable<IWord> en2)
        {
            var union1 = en1.Concat(en2);
            /*var union2 = union1
                .GroupBy(x => x.Value)
                .Select(x => new Word { Value = x.Key, CountInText = x.Select, SestenseNumbers = new HashSet<int> { number } })*/
            //var union1 = en1.Select(x => new Word { Value = x.Value, CountInText = x.CountInText+en2.Where(y=>y.Value==x.Value).Sum(y=>y.CountInText), SestenseNumbers = x.SestenseNumbers });
            /*var union = en1.GroupJoin(
                en2,
                x => x.Value,
                y => y.Value,
                (x, ys) => new Word { Value = x.Value, CountInText = ys.Sum(y => y.CountInText), SestenseNumbers = x.SestenseNumbers }
                );
                /*.Union(en2.GroupJoin(
                    en1,
                    x=>x.Value,
                    y=>y.Value,
                    (x, ys) => new Word { Value = x.Value, CountInText = ys.Sum(y => y.CountInText), SestenseNumbers = x.SestenseNumbers }
                ));*/
            return union1;
        }
        public static HashSet<int> UnionHashSet(HashSet<int> hs1, HashSet<int> hs2)
        {
           hs1.UnionWith(hs2);
           return hs1;
        }
        public static IEnumerable<IWord> SplitIntoWords(string text, int number)
        {
            var concat = Regex.Matches(text, @"\b[А-яа-яA-Za-z-']+\b")
                .Cast<Match>()
                .Select(x => x.Value.ToLower())
                .GroupBy(x => x)
                .Select(x => new Word { Value = x.Key, CountInText = x.Count(), SestenseNumbers = new HashSet<int> { number } });
                     
            return concat;                      
        }
    }
}
