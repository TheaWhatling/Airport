using FSharp.Compiler.SourceCodeServices;
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

        struct mediumnarrowbodyvalues
        {
         public int runningcostperseatper100km;
         public int maximumflightrangekm;
         public int capacityifallseatsarestandardclass;
         public int minimumnumoffirstclassseats;
        }

        struct largenarrowbodyvalues
        {
            public int runningcostperseatper100km;
            public int maximumflightrangekm;
            public int capacityifallseatsarestandardclass;
            public int minimumnumoffirstclassseats;
        }

        struct mediumwidebodyvalues
        {
            public int runningcostperseatper100km;
            public int maximumflightrangekm;
            public int capacityifallseatsarestandardclass;
            public int minimumnumoffirstclassseats;
        }

        struct calculate
        {
            public int numberofstandardclassseats;
            public int flightcostperseat;
            public int flightcost;
            public int flightincome;
            public int flightprofit;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("");

            read();

            menu();

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

        static void menu()
        {
            string ukname;
            string OSairportname;
            string planetype;
            int num1stseats;
            int price1stseat;
            int pricestandardseat;
            string option;
            // will need more variables for calculate and clear returns

            do
            {
                Console.WriteLine("enter option number:");
                Console.WriteLine("1 = UK airport");
                Console.WriteLine("2 = overseas airport");
                Console.WriteLine("3 = type of aircraft");
                Console.WriteLine("4 = number of first class seats");
                Console.WriteLine("5 = price of first class seat");
                Console.WriteLine("6 = price of standard class seat");
                Console.WriteLine("7 = calculate");
                Console.WriteLine("8 = clear");
                Console.WriteLine("9 = exit");

                option = Console.ReadLine();

                if (option == "1")
                {
                   ukname = ukairport();
                    
                }

                if (option == "2")
                {
                    OSairportname = overseaairport();
                }

                if (option == "3")
                {
                    planetype = typeplane();

                    /*       Type         Running cost               Maximum flight            Capacity if all         Minimum
                                          per seat per 100 km        range(km)                 seats are               number of firstclass 
                                                                                               standard -class         seats(if there are any)                                                                  
                       Medium narrow body         £8                  2650                         180                     8   
                       Large narrow body          £7                  5600                         220                     10
                       Medium wide body           £5                  4050                         406                     14
                    */

                }

                if (option == "4")
                {
                   num1stseats = Convert.ToInt32(numfirstseats());
                }

                if (option == "5")
                {
                   price1stseat = Convert.ToInt32(pricefirstseat());
                }

                if (option == "6")
                {
                   pricestandardseat = Convert.ToInt32(pricestanseat());
                }

                if (option == "7")
                {
                              // will need paramenters 
                    calculate(ukname, OSairportname, planetype, num1stseats, price1stseat, pricestandardseat);
                    // what are passing back?
                    // what if not all variables have a value yet?
                }

                if (option == "8")
                {
                    //clear();
                }

            } while (option != "9"); // what happens after they exit? // exit "message" needed here (clear as well?)
        }
        static string ukairport()
        {
            string ukname;
            bool validUKairportname = false;
            do
            {
                Console.WriteLine("please enter Uk airports name");
                ukname = Console.ReadLine();

                validUKairportname = false;

                if (ukname == "Liverpool John Lennon")
                {
                    validUKairportname = true;
                }
                

                if (ukname == "Bournemouth International")
                {
                    validUKairportname = true;
                }

            } while (validUKairportname == false);

            return ukname;
        }

        static string overseaairport()
        {
            string OSairportname;
            bool validAirport = false;
            do
            {
                Console.WriteLine("please enter overseas airports name");
                OSairportname = Console.ReadLine();

                validAirport = false;

                for (int s = 0; s < name.Length; s = s + 1)
                {
                    if (name[s] == OSairportname)
                    {
                        validAirport = true;
                    }
                }

                if (validAirport == false)

                {
                    Console.WriteLine("doesnt exist");
                }

            } while (validAirport == false);

            return OSairportname;
        }

        static string typeplane()
        {
            string planetype;
            Console.WriteLine("Three plane types: Medium narrow body, Large narrow body, Medium wide body");
            bool plane = false;

            do
            {
                Console.WriteLine("please enter type of plane");
                planetype = Console.ReadLine();

                plane = false;

                if (planetype == "Medium narrow body")
                {
                    plane = true;

                    mediumnarrowbodyvalues point;
                    point.runningcostperseatper100km = 8;
                    point.maximumflightrangekm = 2650;
                    point.capacityifallseatsarestandardclass = 180;
                    point.minimumnumoffirstclassseats = 8;
    }

                if (planetype == "Large narrow body")
                {
                    plane = true;

                    largenarrowbodyvalues point;
                    point.runningcostperseatper100km = 7;
                    point.maximumflightrangekm = 5600;
                    point.capacityifallseatsarestandardclass = 220;
                    point.minimumnumoffirstclassseats = 10;
                }

                if (planetype == "Medium wide body")
                {
                    plane = true;

                    mediumwidebodyvalues point;
                    point.runningcostperseatper100km = 5;
                    point.maximumflightrangekm = 4050;
                    point.capacityifallseatsarestandardclass = 406;
                    point.minimumnumoffirstclassseats = 14;

                    //Console.WriteLine(point.maximumflightrangekm); // outputs value in this point (4050) see https://www.tutorialsteacher.com/csharp/csharp-struct
                }

            } while (plane == false);

            return planetype;        
        }

        static string numfirstseats()
        {
            string num1stseats;

            Console.WriteLine("please enter then number of first class seats");
            num1stseats = Console.ReadLine();
             
            return num1stseats;

        }

        static string pricefirstseat()
        {
            string price1stseat;

            Console.WriteLine("please enter the current price of a first class seat");
            price1stseat = Console.ReadLine();

            return price1stseat;

        }

        static string pricestanseat()
        {
            string pricestandardseat;

            Console.WriteLine("please enter the current price of a standard class seat");
            pricestandardseat = Console.ReadLine();

            return pricestandardseat;

        }

        static string calculate()
        {
            // pass parameters
            // what if not all variables have a value yet

            /*
            Number of standardclass seats Capacity if all seats are standard-class – Number of first-class seats x 2

            Flight cost per seat running cost per seat per 100 km (for the selected type of aircraft) × distance between the UK airport and the overseas airport / 100

            Flight cost flight cost per seat × (number of first-class seats + number of standardclass seats)

            Flight income number of first-class seats × price of a first-class seat + number of standard-class seats × price of a standard-class seat

            Flight profit flight income - flight cost 
            */
            calculate point;
            point.numberofstandardclassseats = 8;
            point.flightcostperseat = 2650;
            point.flightcost= 180;
            point.flightincome = 8;
            point.flightprofit = 2;

        }

       //  static string clear()
       //  {
                 // clear all inputs

       //  }

    }
}
