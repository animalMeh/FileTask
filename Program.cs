using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace FileWork
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string filename = "file.txt";
            string text = File.ReadAllText(filename);
            var splitedNumbers = text.Split(' ');

            var mostPopularNumberCount = numbers.GroupBy(n => n).Select(g => g.Count()).Max();
            
            using (StreamWriter sw = new StreamWriter("out" + filename, true, Encoding.ASCII))
            {
                sw.WriteLine($" Last time the most common number was referenced {mostPopularNumberCount}  times");
            }            
        }
    }
}
