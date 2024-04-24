using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife
{
    public class Cells
    {


        private List<int[]> cellList = new List<int[]>();
        private List<int[]> coordinates = new List<int[]>();

        public void Cell(int x, int y, bool is_alive)
        {
            cellList.Add(new int[] { x, y, (is_alive) ? 1 : 0 });
        }
        public void Simulate()
        {
            List<int[]> newCellList = new List<int[]>();
            foreach (int[] cell in cellList)
            {
                //update it and
            }
        }
        public List<int[]> FindSurroundingCells(int x, int y)
        {
            /*
                [x-1, y+1] [x, y+1] [x+1, y+1]
                [x-1, y  ] [x, y  ] [ x+1,y  ]
                [x-1, y-1] [x,y-1 ] [x+1, y-1]
             */
            List<int[]> surroundingCells = new List<int[]>();
            int[] x_positions = { x - 1, x, x + 1 };
            int[] y_positions = { y - 1, y, y + 1 };


            foreach (int[] cell in cellList)
            {
                if (x_positions.Contains(cell[0]) && y_positions.Contains(cell[1]))
                {
                    if (cell[0] != x && cell[1] != y)
                    {
                        surroundingCells.Add(cell);
                    }
                }
            }

            return surroundingCells;
        }
        public void CellStatus(int[] cell)
        {
            /**
             * Any live cell with fewer than two live neighbors dies, as if by underpopulation.
             * Any live cell with two or three live neighbors lives on to the next generation.
             * Any live cell with more than three live neighbors dies, as if by overpopulation.
             * Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
             **/
            List<int[]> neighbourCells = FindSurroundingCells(cell[0], cell[1]);

            if (neighbourCells.Count < 2 || neighbourCells.Count > 3)
            {
                cellList.Remove(cell);
            }
        }
        public void NewCell(int x, int y)
        {
            int[] cell = { x, y, 1 };
            cellList.Add(cell);
        }
        public void NewCells(int x, int y)
        {
            List<int[]> neighbourCells = FindSurroundingCells(x, y);
            if (neighbourCells.Count == 3)
            {
                int[] newCell = { x, y, 1 };
                cellList.Add(newCell);
            }
        }
        public List<int[]> AdjacentCoordinates(int x, int y)
        {
            List<int[]> coordinates = new List<int[]>
            {
                new int[] { x - 1, y + 1 },
                new int[] { x, y + 1 },
                new int[] { x + 1, y + 1 },
                new int[] { x - 1, y },
                new int[] { x + 1, y },
                new int[] { x - 1, y - 1 },
                new int[] { x, y - 1 },
                new int[] { x + 1, y - 1 }
            };
            return coordinates;
        }
        public void Print()
        {
            Console.Clear();
            foreach (int[] cell in cellList)
            {
                Console.SetCursorPosition(cell[0], cell[1]);
                if (cell[2] == 1)
                {
                    Console.WriteLine("█");
                }

            }
        }
    }
}
