using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {

            string directory = @"C:\Users\nfalkoff\Pair Exercises\team5-c-week4-pair-exercises\m1-w4d2-file-io-part1-exercises-pair";
            string filename = @"alices_adventures_in_wonderland.txt";

            // Create the full path
            string fullPath = Path.Combine(directory, filename);
            List<string> wordList = new List<string>();
            List<string> newList = new List<string>();
            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    // Read in the line
                    string line = sr.ReadLine();

                    string[] wordArray = line.Split(' ');

                    for (int i = 0; i < wordArray.Length; i++)
                    {
                        wordList.Add(wordArray[i]);
                    }
                    
                }
            }
            int wordCount = wordList.Count;
            int sentenceCount = 0;
            foreach (string x in wordList)
            {
                if (x.Contains('.') || x.Contains('!') || x.Contains('?'))
                {
                    sentenceCount++;
                }
            }
            Console.WriteLine("The number of words is: " + wordCount);
            Console.WriteLine("The number of sentences is: " + sentenceCount);
            Console.ReadLine();
        }
    }
}
