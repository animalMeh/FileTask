using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileWork
{
    class Program
    {
        static void Main(string[] args)
        {

            int [] numbers;
            string path = @"D:\Programming\SPZ lections\lab4\FileWork\FileWork\";
            string filename = "file.txt";
            string text = "";
           
                using (StreamReader sr = new StreamReader(path + filename, System.Text.Encoding.Default))
                {
                    text = sr.ReadToEnd();
                }

            var umbers = text.Split(' ');
            numbers = new int[umbers.Length];
           
            numbers = (from c in umbers select int.Parse(c)).ToArray();

            using (StreamWriter sw = new StreamWriter(path + "out" + filename, true, System.Text.Encoding.ASCII))
            {
                sw.WriteLine($" Last time the most common number was referenced {GetSequence(numbers)}  times");
            }
     
            
        }
        static int GetSequence( int [] seq)
        {
           var newSeq = seq.OrderByDescending(s => s).ToArray();
           int MaxCounting = 0 , ind = 0;
            for (int i = 0; i < newSeq.Length; i++)
            {
                ind++;
                if (i == newSeq.Length - 1)
                {
                    if (MaxCounting < ind)
                        MaxCounting = ind;
                }
                else if (newSeq[i] != newSeq[i + 1])
                {
                    if (MaxCounting < ind)
                        MaxCounting = ind;
                    ind = 0;
                }
            }
           return MaxCounting;
        }
    }
}
