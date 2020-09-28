using System;
using System.IO;

namespace Airport
{
    class Program
    {
        static string[] code;
        static string[] name;
        static string[] distanceL;
        static string[] distanceB;

        static void Main(string[] args)
        {
            Console.WriteLine("");

            read();

            //for (int x = 0; x < code.Length; x = x + 1)
            //{
            //    Console.WriteLine(code[x]);
            //}
            // prints the field 'code'

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

                
                code = new string[rows.Length];
                name = new string[rows.Length];
                distanceL = new string[rows.Length];
                distanceB = new string[rows.Length];
                // this creates 4 new arrays 

                string[] fields;
                for(int z = 0; z < rows.Length; z = z + 1)
                {
                    fields = rows[z].Split(',');
                    code[z] = fields[0];
                    name[z] = fields[1];
                    distanceL[z] = fields[2];
                    distanceB[z] = fields[3];
                    // each field has its own array filled with the airport files data
                }

            }
            catch 
            // if file is not found - its following code will not work
            {
                Console.WriteLine("error - can not open file");
            }


        }

        //When the program is used, the following details will need to be entered:
        //• UK airport
        //• overseas airport
        //• type of aircraft
        //• number of first-class seats
        //• price of a first-class seat
        //• price of a standard-class seat.

        /*need to create arrays/ an array to hold data about; 
         * plane type
         * running cost per seat per 100 km
         * maximum flight range(km)
         * capacity if all seats are standard-class
         * minimum number of firstclass seats(if there are any)
        */

        /*
          Number of standardclass seats Capacity if all seats are standard-class – Number of first-class seats x 2
Flight cost per seat running cost per seat per 100 km (for the selected type of aircraft) ×
distance between the UK airport and the overseas airport / 100
Flight cost flight cost per seat × (number of first-class seats + number of standardclass seats)
Flight income number of first-class seats × price of a first-class seat + number of
standard-class seats × price of a standard-class seat
Flight profit flight income - flight cost 
        */
    }
}
