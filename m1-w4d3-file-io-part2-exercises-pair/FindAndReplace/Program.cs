using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a phrase you wish to search for: ");
            string phraseInput = Console.ReadLine();
            Console.Write("Please enter a phrase to replace it with: ");
            string phraseReplace = Console.ReadLine();
            Console.Write("Please enter a file path: ");
            string filePath = Console.ReadLine();
            bool filePathExists = File.Exists(filePath);
            while(!filePathExists)
            {
                Console.WriteLine("Sorry, this destination does not exist. Please enter another file path: ");
                filePath = Console.ReadLine();
                filePathExists = File.Exists(filePath);
            }
            Console.Write("Please enter a destination file path: ");
            string destinationFilePath = Console.ReadLine();
            bool destinationFilePathExists = File.Exists(destinationFilePath);
            if(destinationFilePathExists == true)
            {
                IOException error = 
                    new IOException();
                Console.WriteLine("This directory already exists");
                Console.WriteLine(error.Message);
                Console.WriteLine("Press any key to exit....");
                Console.ReadLine();
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    using (StreamWriter sw = new StreamWriter(destinationFilePath, false))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string newLine = line.Replace(phraseInput, phraseReplace);
                            sw.WriteLine(newLine);
                        }
                    }
                        
                        
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

        }
    }
}
