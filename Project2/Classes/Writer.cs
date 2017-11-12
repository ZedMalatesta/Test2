using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Classes
{
    static class Writer
    {
        public static void ConcordanceWriter(string textfilepath, Concordance concord)
        {
            using (StreamWriter file = new StreamWriter(textfilepath, false, Encoding.GetEncoding("windows-1251")))
            {
                file.WriteLine(concord.ToString());
            }
        }
    }
}
