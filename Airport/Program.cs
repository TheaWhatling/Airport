using System;
using System.IO;

namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");

            read();
        }
        static void read()
        {
            string text;

            try
            {
                text = File.ReadAllText("Airports.txt");
                // reads all text in Airports file
                Console.WriteLine(text);
                // prints the text in airports file

                string[] rows = text.Split('\n');
                Console.WriteLine(rows.Length);
                Console.ReadLine();
                //Console.WriteLine(rows[1]);   //writes row 1

                string[] fields = rows.Split(',');
                Console.WriteLine(fields.Length);



            }
            catch // if file is not found - its following code will not work
            {
                Console.WriteLine("error - can not open file");
            }


        }
    }
}
