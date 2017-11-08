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
            /* string sequence = "";
             using (StreamReader reader = new StreamReader("text.txt"))
             {
                 while (reader.Peek() >= 0)
                 {
                     Console.WriteLine(sequence);
                     while ((char)reader.Peek()!='.'&& (char)reader.Peek() != '!'&& (char)reader.Peek() != '?'!Regex.IsMatch(Convert.ToString((char)reader.Peek()), "[.!?]"))
                     {
                         //Console.Write(Convert.ToString((char)reader.Peek()));
                         sequence += Convert.ToString((char)reader.Read());
                     }
                     reader.Read();
                     Console.WriteLine(sequence);
                     sequence = "";
                 }
             }*/
            using (var textReader = File.OpenText("text.txt"))
            {
                //var lines = Regex.Split(textReader.ReadLine(), "["()]"]"));
            }
            Console.ReadLine();
        }
    }
}
