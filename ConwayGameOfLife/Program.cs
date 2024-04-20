using System;
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
            var cell = new Cell(2, 3, false);
            cell.sayPosition();
            Console.ReadLine();
        }
    }
}
