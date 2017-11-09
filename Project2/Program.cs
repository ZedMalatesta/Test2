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
            /*using (StreamReader reader = new StreamReader("azimov.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    sequence += reader.ReadLine();
                    var substrings = Regex.Split(sequence, @"\b[.!?]+\b").Select(x => x);
                    if (substrings.Last().Trim() != "") Console.WriteLine(sequence);
                    if (substrings.Last().Trim()!="") Console.WriteLine(substrings.Last().Trim()[substrings.Last().Trim().Length-1]);

                    if (Regex.IsMatch(sequence, @"\b[A-Za-zА-Яа-я]+\b"))
                    {
                        stack = Parser.UnionEn(stack, Parser.SplitIntoWords(sequence, num));
                        foreach (var a in stack)
                        {

                            Console.Write(a.Value + ":" + a.CountInText + ":");
                            foreach (int u in a.SentenceNumbers)
                            {
                                Console.Write(u + ",");
                            }
                            Console.WriteLine();
                        }
                        num++;
                        Console.Write(sequence);
                    }
                    sequence = "";
                }
            }*/
            
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    while ((char)reader.Peek() != '.' && (char)reader.Peek() != '!' && (char)reader.Peek() != '?')
                    {
                        sequence += Convert.ToString((char)reader.Read());
                    }
                    reader.Read();
                    if (Regex.IsMatch(sequence, @"\b[A-Za-zА-Яа-я]+\b"))
                    {
                        stack = Parser.UnionEn(stack, Parser.SplitIntoWords(sequence, num));
                        foreach (var a in stack)
                        {
                          
                            Console.Write(a.Value + ":" + a.CountInText + ":");
                            foreach (int u in a.SentenceNumbers)
                            {
                              Console.Write(u+",");
                            }
                            Console.WriteLine();
                        }
                        num++;
                        Console.Write(sequence);
                    }
                    sequence = "";
                }
            }
            using (StreamWriter file = new System.IO.StreamWriter("out.txt"))
            {
                foreach (var a in stack)
                {
                    //stack = Parser.UnionEn(stack, Parser.SplitIntoWords(sequence, num));
                    file.Write(a.Value + ":" + a.CountInText + ":");
                    foreach (int u in a.SentenceNumbers)
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
