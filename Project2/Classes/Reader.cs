using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Classes
{
    static class Reader
    {
        public static Concordance CorcondanceCreator(string textfilepath, int pageseparator)
        {
            string sequence;
            int liner = 1, pager = 1;            
            IEnumerable<IWord> stack = Enumerable.Empty<IWord>();

            using (StreamReader reader = new StreamReader(textfilepath, Encoding.GetEncoding("windows-1251")))
            {
                while (reader.Peek() >= 0)
                {                                        
                    sequence = reader.ReadLine();
                    stack = Parser.UnionWordEnumerable(stack, Parser.SplitIntoWords(sequence, pager));
                    if (liner == pageseparator)
                    {
                        pager++;
                        liner = 0;
                    }
                    liner++;
                }
            }

            return new Concordance(Parser.CreateConcordance(stack));
        }
    }
}
