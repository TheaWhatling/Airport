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

        static string ukname;
        static string OSairportname;
        static string planetype;
        static int num1stseats;
        static int price1stseat;
        static int pricestandardseat;

        struct planebodyvalues
        {
         public string planebodytype;
         public int runningcostperseatper100km;
         public int maximumflightrangekm;
         public int capacityifallseatsarestandardclass;
         public int minimumnumoffirstclassseats;
        }

        struct calculatedvalues
        {
            public int numberofstandardclassseats;
            public int flightcostperseat;
            public int flightcost;
            public int flightincome;
            public int flightprofit;

            public calculatedvalues(int numberofstandardclassseats, int flightcostperseat, int flightcost, int flightincome, int flightprofit)
            {

                this.numberofstandardclassseats = a;
                this.flightcostperseat = b;
                this.flightcost = c;
                this.flightincome = d;
                this.flightprofit = e;
            }

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
            
            string option;

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
                    // check complies with minimum allowed for plane type
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
                    // parameters 
                    // what are passing back? need to pass back?
                    // what if not all variables have a value yet?





                    calculatedvalues = Calculate(num1stseats, price1stseat, pricestandardseat);






                    /* sample code from website changed to fit own variable names
                     
                        struct calculatedvalues
                        {
                                public int numberofstandardclassseats;
                                public int flightcostperseat;
                                public int flightcost;
                                public int flightincome;
                                public int flightprofit;

                                public calculatedvalues(int numberofstandardclassseats, int flightcostperseat, int flightcost, int flightincome, int flightprofit)
                                {
                                    this.numberofstandardclassseats = a;
                                    this.flightcostperseat = b;
                                    this.flightcost = c;
                                    this.flightincome = d;
                                    this.flightprofit = e;
                                }
                        }

                        calculatedvalues point = new calculatedvalues(10, 20, 30, 40, 50);

                        Console.WriteLine(point.numberofstandardclassseats); //output: 10  
                        Console.WriteLine(point.flightcostperseat); //output: 20  
                        Console.WriteLine(point.flightcost); //output: 30 
                        Console.WriteLine(point.flightincome); //output: 40 
                        Console.WriteLine(point.flightprofit); //output: 50 

                     */





                    Console.WriteLine("number of standard class seats = ");
                    Console.WriteLine(point.numberofstandardclassseats);
                    Console.WriteLine("flight cost per seat = ");
                    Console.WriteLine(point.flightcostperseat);
                    Console.WriteLine("flight cost = ");
                    Console.WriteLine(point.flightcost);
                    Console.WriteLine("flight income = ");
                    Console.WriteLine(point.flightincome);
                    Console.WriteLine("flight profit = ");
                    Console.WriteLine(point.flightprofit);



                }

                if (option == "8")
                {
                    //clear();
                }

            } while (option != "9"); // exit "message" needed here 

            Console.WriteLine("now quitting session"); // check displays and they can read it (not too fast to read)

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

                    planebodyvalues point;
                    point.planebodytype = "mediumnarrow";
                    point.runningcostperseatper100km = 8;
                    point.maximumflightrangekm = 2650;
                    point.capacityifallseatsarestandardclass = 180;
                    point.minimumnumoffirstclassseats = 8;
    }

                if (planetype == "Large narrow body")
                {
                    plane = true;

                    planebodyvalues point;
                    point.planebodytype = "largenarrow";
                    point.runningcostperseatper100km = 7;
                    point.maximumflightrangekm = 5600;
                    point.capacityifallseatsarestandardclass = 220;
                    point.minimumnumoffirstclassseats = 10;
                }

                if (planetype == "Medium wide body")
                {
                    plane = true;

                    planebodyvalues point;
                    point.planebodytype = "mediumwide";
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
            // check complies with minimum allowed for plane type
             
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

        static string Calculate(int num1stseats, int price1stseat, int pricestandardseat)
        {

            int numberofstandardclassseats;
            int flightcostperseat;
            int flightcost;
            int flightincome;
            int flightprofit;
            // do i need to declare these if they are in a stuct?


            numberofstandardclassseats = capacityifallseatsarestandardclass - (num1stseats * 2);  
            //Each first-class seat takes up space for two standard-class seats.
           
            flightcostperseat = runningcostperseatper100km * /*distance between the UK airport and the overseas airport*/ / 100;
            // need to find distance from which uk airport is to the overseas airport

            flightcost = flightcostperseat * (num1stseats + numberofstandardclassseats);
           
            flightincome = (num1stseats * price1stseat) + (numberofstandardclassseats * pricestandardseat); 
            
            flightprofit = flightincome - flightcost;


        calculatedvalues point = new calculatedvalues(numberofstandardclassseats, flightcostperseat, flightcost, flightincome, flightprofit); 
            // should this be above the actual calculations being done?

            return calculatedvalues; 
            // how/what do you return if values are stored in a struct? or do you not return anything?

        }

       //  static string clear()
       //  {
                 // clear all inputs

       //  }
       // // not optional as they may want to go through it all again with a different flight/start again!
    }
}

