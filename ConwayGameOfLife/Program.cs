using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwayGameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool runninng = true;

            Cells cells = new Cells();
            while (runninng)
            {
                string Input = Console.ReadLine();
                Input = Input.ToUpper();
                switch (Input)
                {
                    case "H":
                        PrintHelp();
                        break;
                    case "A":
                        try
                        {
                            Console.WriteLine("X Y");
                            string cellCoords = Console.ReadLine();
                            string[] splitString = cellCoords.Split(' ');
                            cells.NewCell(Convert.ToInt32(splitString[0]), Convert.ToInt32(splitString[1]));
                            cells.Print();

                        } catch (Exception)
                        {
                            Console.WriteLine("incorrect format or non numerals entered");
                        }
                        break;
                    case "S":
                        Console.WriteLine("Specify amount of iteration");
                        int nums = 1;
                        try
                        {
                            nums  = Convert.ToInt32(Console.ReadLine());
                        } 
                        catch(Exception) {
                        }

                        for (int i = 0; i < nums; i++)
                        {
                            cells.Simulate();
                            cells.Print();
                            Thread.Sleep(500);
                        }
                        break;
                    case "Q":
                        runninng = false;
                        break;
                    default:
                        Console.WriteLine("Not a recognised command");
                        break;
                }
            }
        }
        public static void PrintHelp()
        {
            Console.WriteLine("H: See Options");
            Console.WriteLine("S: Simulate One Tick");
            Console.WriteLine("A: Add Cell");
            Console.WriteLine("Q: Quit");
        }
    }
}
