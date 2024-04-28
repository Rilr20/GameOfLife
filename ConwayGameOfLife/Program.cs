using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                        Console.WriteLine("X Y");
                        string cellCoords = Console.ReadLine();
                        string[] splitString = cellCoords.Split(' ');
                        cells.NewCell(Convert.ToInt32(splitString[0]), Convert.ToInt32(splitString[1]));
                        cells.Print();
                        break;
                    case "S":
                        cells.Simulate();
                        cells.Print();
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
