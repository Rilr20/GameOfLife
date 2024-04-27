using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConwayGameOfLife
{
    public class Cells
    {


        //private List<int[]> cellList = new List<int[]>();
        //private List<int[]> coordinates = new List<int[]>();
        private Hashtable cells = new Hashtable();
        public void Cell(int x, int y, bool is_alive)
        {
            //cellList.Add(new int[] { x, y, (is_alive) ? 1 : 0 });
            cells.Add($"{x},{y}", is_alive);
        }
        public void Simulate()
        {
            //List<int[]> newCellList = new List<int[]>();
            Hashtable newCells = new Hashtable();
            foreach (DictionaryEntry cell in cells)
            {
                //update it and check neighbours
                CellStatus(cell, cell.Key.ToString());
                
            }
            cells = newCells;
        }
        public Hashtable FindSurroundingCells(int x, int y)
        {
            /*
                [x-1, y+1] [x, y+1] [x+1, y+1]
                [x-1, y  ] [x, y  ] [ x+1,y  ]
                [x-1, y-1] [x,y-1 ] [x+1, y-1]
             */
            Hashtable surroundingCells = new Hashtable();
            int[] x_positions = { x - 1, x, x + 1 };
            int[] y_positions = { y - 1, y, y + 1 };


            foreach (DictionaryEntry cell in cells)
            {
                string[] coordinates = cell.Key.ToString().Split(',');
                if (x_positions.Contains(Convert.ToInt32(coordinates[0])) && y_positions.Contains(Convert.ToInt32(coordinates[1])))
                {
                    if (Convert.ToInt32(coordinates[0]) != x && Convert.ToInt32(coordinates[1]) != y)
                    {
                        surroundingCells.Add(cell.Key, cell.Value);
                    }
                }
            }

            return surroundingCells;
        }
        public void CellStatus(DictionaryEntry cell, string key)
        {
            /**
             * Any live cell with fewer than two live neighbors dies, as if by underpopulation.
             * Any live cell with two or three live neighbors lives on to the next generation.
             * Any live cell with more than three live neighbors dies, as if by overpopulation.
             * Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
             **/
            string[] coordinates = cell.Key.ToString().Split(',');
            Hashtable neighbourCells = FindSurroundingCells(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));
            if (neighbourCells.Count < 2 || neighbourCells.Count > 3)
            {
                cells.Remove(key);
            }
        }
        public void NewCell(int x, int y)
        {
            //int[] cell = { x, y, 1 };
            //cellList.Add(cell);
            cells.Add($"{x},{y}", true);
        }
        public void NewCells(int x, int y)
        {
            Hashtable neighbourCells = FindSurroundingCells(x, y);
            if (neighbourCells.Count == 3)
            {
                //int[] newCell = { x, y, 1 };
                //cellList.Add(newCell);
                cells.Add($"{x},{y}", true);
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
            foreach (DictionaryEntry cell in cells)
            {
                string[] coordinates = cell.Key.ToString().Split(',');

                Console.SetCursorPosition(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));

                if ((bool)cell.Value == true)
                {
                    Console.WriteLine("█");
                }

            }
        }
    }
}
