using Project2.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Project2
{
    class Program
    {   
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string sequence = "";
            int num = 1, s = 0;
            IEnumerable<IWord> stack = Parser.SplitIntoWords(sequence, num);
            /*using (StreamReader reader = new StreamReader("text.txt"))
            {
                sequence += reader.ReadToEnd();
                var t = Regex.Split(sequence, "[\r\n]");
                foreach (var a in t)
                {
                    Console.WriteLine(a);
                    Console.WriteLine("+++");
                }
            }*/
            
            using (StreamReader reader = new StreamReader("text.txt"))
           {
               while (reader.Peek() >= 0)
               {
                   sequence += reader.ReadLine();
                   //var substrings = sequence.Split(new char[] {'.', '?', '!' });
                   stack = Parser.UnionEn(stack, Parser.SplitIntoWords(sequence, num));                   
                    foreach (var a in stack)
                    {

                       // Console.Write(a.Value + ":" + a.CountInText + ":");
                        foreach (int u in a.LineNumber)
                        {
                           // Console.Write(u + ",");
                        }
                        //Console.WriteLine();
                    }
                    sequence = "";
                    num++;
                    //Console.Write(sequence);
                    
                }
                Parser.CreateConcordance(stack);
           }
            
            using (StreamWriter file = new System.IO.StreamWriter("out.txt"))
            {
                foreach (var a in stack)
                {
                    //stack = Parser.UnionEn(stack, Parser.SplitIntoWords(sequence, num));
                    file.Write(a.Value + ":" + a.CountInText + ":");
                    foreach (int u in a.LineNumber)
                    {
                        file.Write(u + ",");
                    }
                    file.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
