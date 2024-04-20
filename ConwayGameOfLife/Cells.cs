using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife
{
    internal class Cells
    {


        private List<int[]> cellList = new List<int[]>();

        public void Cell(int x, int y, bool is_alive)
        {
            cellList.Add(new int[] { x, y, (is_alive) ? 1 : 0 });
        }
        public void simulate()
        {

        }
        public List<int[]> findSurroundingCells(int x, int y)
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
        public void cellStatus(int[] cell)
        {
            /**
             * Any live cell with fewer than two live neighbors dies, as if by underpopulation.
             * Any live cell with two or three live neighbors lives on to the next generation.
             * Any live cell with more than three live neighbors dies, as if by overpopulation.
             * Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
             **/
            List<int[]> neighbourCells = findSurroundingCells(cell[0], cell[1]);

            if (neighbourCells.Count < 2 || neighbourCells.Count > 3)
            {
                //remove this cell from list
                cellList.Remove(cell);
            }
        }
        public void newCells(int x, int y)
        {
            List<int[]> neighbourCells = findSurroundingCells(x, y);
            if (neighbourCells.Count == 3)
            {
                int[] newCell = { x, y, 1 };
                cellList.Add(newCell);
            }
        }
    }
}
