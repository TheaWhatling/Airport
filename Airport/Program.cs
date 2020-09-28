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

                
                string[] code = new string[rows.Length];
                string[] name = new string[rows.Length];
                string[] distanceL = new string[rows.Length];
                string[] distanceB = new string[rows.Length];

                string[] fields;
                for(int z = 0; z < rows.Length; z = z + 1)
                {
                    fields = rows[z].Split(',');
                    code[z] = fields[0];
                    name[z] = fields[1];
                    distanceL[z] = fields[2];
                    distanceB[z] = fields[3];
                }

            }
            catch // if file is not found - its following code will not work
            {
                Console.WriteLine("error - can not open file");
            }


        }
    }
}
