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
            string textfilepath = @"C:\Users\Zedd\Documents\Visual Studio 2015\Projects\Project2\Resources\poe.txt";
            int N = 1;

            Writer.ConcordanceWriter(@"C:\Users\Zedd\Documents\Visual Studio 2015\Projects\Project2\Resources\out.txt", Reader.CorcondanceCreator(textfilepath, N));
        }
    }
}
