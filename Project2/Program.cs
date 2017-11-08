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
            string sequence = "";
            int num = 1, s=0;
            IEnumerable<IWord> stack = Parser.SplitIntoWords(sequence, num);
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    //Console.WriteLine(sequence);
                    while ((char)reader.Peek() != '.' && (char)reader.Peek() != '!' && (char)reader.Peek() != '?'/*!Regex.IsMatch(Convert.ToString((char)reader.Peek()), "[.!?]")*/)
                    {
                        //Console.Write(Convert.ToString((char)reader.Peek()));
                        sequence += Convert.ToString((char)reader.Read());
                    }
                    reader.Read();
                    if (Regex.IsMatch(sequence, @"\b[А-яа-яA-Za-z]+\b"))
                    {
                        /*if (s == 0) { stack = Parser.SplitIntoWords(sequence, num); s++; }
                        else stack = Parser.UnionEn(stack, Parser.SplitIntoWords(sequence, num));*/
                        stack = Parser.SplitIntoWords(sequence, num);
                        foreach (var a in stack)
                        {
                            stack = Parser.UnionEn(stack, Parser.SplitIntoWords(sequence, num));
                            Console.Write(a.Value + ":" + a.CountInText + ":");
                            foreach (int u in a.SestenseNumbers)
                            {
                                Console.Write(u+",");
                            }
                            Console.WriteLine();
                        }
                        num++;
                        Console.WriteLine("Wot i wse rebyata");
                    }
                    sequence = "";
                }
            }
            Console.ReadLine();
        }
    }
}
