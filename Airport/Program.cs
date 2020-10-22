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

        static int distance;
          

        static string ukname;
        static string OSairportname;
        // Oh two variables with the same name !!!!!!
        //static int num1stseats;
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

                this.numberofstandardclassseats = numberofstandardclassseats;
                this.flightcostperseat = flightcostperseat;
                this.flightcost = flightcost;
                this.flightincome = flightincome;
                this.flightprofit = flightprofit;
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
                for (int z = 0; z < rows.Length; z = z + 1)
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
            planebodyvalues p;
            p.planebodytype = "";
            p.minimumnumoffirstclassseats = 0;
            p.maximumflightrangekm = 0;
            p.runningcostperseatper100km = 0;
            p.capacityifallseatsarestandardclass = 0;
            int noSeats=0;
            calculatedvalues cv;
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

                    if (OSairportname == "JFK")
                    {
                        Console.WriteLine("John F Kennedy International");
                    }

                    if (OSairportname == "ORY")
                    {
                        Console.WriteLine("Paris-Orly");
                    }

                    if (OSairportname == "MAD")
                    {
                        Console.WriteLine("Adolfo Suarez Madrid-Barajas");
                    }

                    if (OSairportname == "AMS")
                    {
                        Console.WriteLine("Amsterdam Schiphol");
                    }

                    if (OSairportname == "CAI")
                    {
                        Console.WriteLine("Cairo International");
                    }

                    // quicker way to do this? and so if airports text file changes these can change to

                }

                if (option == "3")
                {
                    p = typeplane();

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
                    noSeats = Convert.ToInt32(numfirstseats(p));
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
                    

                    if (noSeats != 0 && price1stseat != 0 && pricestandardseat != 0 && p.planebodytype != "")
                    {

                        cv = Calculate(noSeats, price1stseat, pricestandardseat, p);

                        Console.WriteLine("number of standard class seats = ");
                        Console.WriteLine(cv.numberofstandardclassseats);
                        Console.WriteLine("flight cost per seat = ");
                        Console.WriteLine(cv.flightcostperseat);
                        Console.WriteLine("flight cost = ");
                        Console.WriteLine(cv.flightcost);
                        Console.WriteLine("flight income = ");
                        Console.WriteLine(cv.flightincome);
                        Console.WriteLine("flight profit = ");
                        Console.WriteLine(cv.flightprofit);

                    }



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








                }

                if (option == "8")
                {
                    //clear();
                }

            } while (option != "9"); // exit "message" needed here - see below

            Console.WriteLine("now quitting session"); // check displays and they can read it (not too fast to read) 

        }
        static string ukairport()
        {
            string ukname;
            bool validUKairportname = false;
            do
            {
                Console.WriteLine("please enter Uk airports name: enter LPL for Liverpool John Lennon or BOH for Bournemouth International");
                ukname = Console.ReadLine();

                validUKairportname = false;

                if (ukname == "LPL")
                {
                    Console.WriteLine("Liverpool John Lennon");
                    validUKairportname = true;
                }


                if (ukname == "BOH")
                {
                    Console.WriteLine("Bournemouth International");
                    validUKairportname = true;
                }

                if (validUKairportname == false)
                {
                    Console.WriteLine("this does not exist");
                }

            } while (validUKairportname == false);

            return ukname;
        }

        static string overseaairport()
        {
           //string OSairportname; // can comment out because now global?
            bool validAirport = false;
            do
            {
                Console.WriteLine("please enter overseas airports name using its three letter code");
                OSairportname = Console.ReadLine();

                validAirport = false;

                for (int s = 0; s < code.Length; s = s + 1)
                {
                    if (code[s] == OSairportname)
                    {
                        validAirport = true;
                    }
                }

                if (validAirport == false)

                {
                    Console.WriteLine("this does not exist");
                }

            } while (validAirport == false);

            return OSairportname;
        }

        static planebodyvalues typeplane() //changed return type
        {
            string planetype;
            Console.WriteLine("Three plane types: Medium narrow body, Large narrow body, Medium wide body");
            bool plane = false;
           
            planebodyvalues point; // moved point to have scope across whole function
            point.planebodytype = "";
            point.runningcostperseatper100km = 0;
            point.maximumflightrangekm = 0;
            point.capacityifallseatsarestandardclass = 0;
            point.minimumnumoffirstclassseats = 0;

            do
            {
                Console.WriteLine("please enter type of plane");
                planetype = Console.ReadLine();

                plane = false;

                if (planetype == "Medium narrow body")
                {
                    plane = true;


                    point.planebodytype = "mediumnarrow";
                    point.runningcostperseatper100km = 8;
                    point.maximumflightrangekm = 2650;
                    point.capacityifallseatsarestandardclass = 180;
                    point.minimumnumoffirstclassseats = 8;
                }

                if (planetype == "Large narrow body")
                {
                    plane = true;


                    point.planebodytype = "largenarrow";
                    point.runningcostperseatper100km = 7;
                    point.maximumflightrangekm = 5600;
                    point.capacityifallseatsarestandardclass = 220;
                    point.minimumnumoffirstclassseats = 10;
                }

                if (planetype == "Medium wide body")
                {
                    plane = true;

                    point.planebodytype = "mediumwide";
                    point.runningcostperseatper100km = 5;
                    point.maximumflightrangekm = 4050;
                    point.capacityifallseatsarestandardclass = 406;
                    point.minimumnumoffirstclassseats = 14;

                    //Console.WriteLine(point.maximumflightrangekm); // outputs value in this point (4050) see https://www.tutorialsteacher.com/csharp/csharp-struct
                }

            } while (plane == false);

            return point;
        }

        static int numfirstseats(planebodyvalues p1)
        {
        
            string num1stseatst;
            int num1seats;

            bool seats = false;

            do
            {
                Console.WriteLine("please enter then number of first class seats");
                num1stseatst = Console.ReadLine();

                num1seats = Convert.ToInt32(num1stseatst);

                seats = false;
                /// oh used the wrong variable
                if (num1seats >= p1.capacityifallseatsarestandardclass || num1seats < p1.minimumnumoffirstclassseats) //needs to be; if num1stseats >= number of standard class seats/2
                {
                    Console.WriteLine("error");
                    seats = false;

                }else
                {
                    seats = true;
                }

              //  if ()
              //  {
             //       Console.WriteLine("error");
//seats = false;
                
                // ok this is the problem. first number of seats will be checked against max seats, lets say it is below capacity
                // then it is compared to minimum seats. The else is(was) attached to the minimum seats comparison. Therefore seats could be set
                // to true even if the user selected too many seats
                

            } while (seats == false);

            //Convert.ToString(num1stseatst);

            return num1seats;

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

        static calculatedvalues Calculate(int num1stseats, int price1stseat, int pricestandardseat, planebodyvalues pb)
        {

            int numberofstandardclassseats;
            int flightcostperseat;
            int flightcost;
            int flightincome;
            int flightprofit;
            // do i need to declare these if they are in a stuct? No


            bool validdistancematch = false;

            bool validAirportagain = false;


            do
            {

                validAirportagain = false;

                for (int x = 0; x < code.Length; x = x + 1) //searches though overseas three letter codes
                {
                    if (code[x] == OSairportname) //finds match
                    {

                        do
                        {
                            //following uses value of x (row) in another field (determined by which UK airport) to find correspondidng distance 

                            validdistancematch = false;

                            if (ukname == "LPL")
                            {
                                distance = Convert.ToInt32(distanceL[x]);
                                validdistancematch = true;

                            }

                            if (ukname == "BOH")
                            {
                                distance = Convert.ToInt32(distanceB[x]);
                                validdistancematch = true;

                            }

                            // distance is changed as a global variable


                        } while (validdistancematch == false);


                        validAirportagain = true;

                    }
                }


            } while (validAirportagain == false);

           

            


            numberofstandardclassseats = pb.capacityifallseatsarestandardclass - (num1stseats * 2);
            //Each first-class seat takes up space for two standard-class seats.

            flightcostperseat = pb.runningcostperseatper100km * distance / 100;
            // need to find distance from which uk airport is to the overseas airport

            flightcost = flightcostperseat * (num1stseats + numberofstandardclassseats);

            flightincome = (num1stseats * price1stseat) + (numberofstandardclassseats * pricestandardseat);

            flightprofit = flightincome - flightcost;


            calculatedvalues point = new calculatedvalues(numberofstandardclassseats, flightcostperseat, flightcost, flightincome, flightprofit);
            // should this be above the actual calculations being done?

            return point;
            // how/what do you return if values are stored in a struct? or do you not return anything?

            // you can retuen an instance of the struct, as you have you just need to add calculated values as a return type
            // in the method signiture

        }
  //  static string clear()
  //  {
  // clear all inputs
  //  }
  // // not optional as they may want to go through it all again with a different flight/start again!

    }

}

/*
To Do list
0. needs to be; if num1stseats >= number of standard class seats/2 

1. check plane type for flight can do flight distance complying to its max flight distance.

2. what if not all variables in options in menu have a value yet? when passed to calculate - will give incorrect results - i think is already sorted - test when have sorted entering number of 1st class seats error

4. clear all inputs (or could give option to only clear certain options inputs?)

5. re read actual task sheet to check not missing anything

 */ 