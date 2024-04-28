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
        private Hashtable cells = new Hashtable();

        public void Cell(int x, int y, bool is_alive)
        {

            cells.Add($"{x},{y}", is_alive);
        }
        public void Simulate()
        {

            Hashtable newCells = new Hashtable();
            foreach (DictionaryEntry cell in cells)
            {
                //update it and check neighbours
                bool status = CellStatus(cell, cell.Key.ToString());
                if  (status && !newCells.Contains(cell.Key))
                {
                   newCells.Add(cell.Key, cell.Value);
                }
                List<int[]> adjacent = AdjacentCoordinates(cell.Key.ToString());
                NewCells(adjacent, newCells);
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
            List<int[]> coords = AdjacentCoordinates($"{x},{y}");
            int foundCells = 0;
            foreach (int[] coord in coords)
            {
                if (cells.Contains($"{coord[0]},{coord[1]}"))
                {
                    surroundingCells.Add($"{coord[0]},{coord[1]}", cells[$"{coord[0]},{coord[1]}"]);
                    foundCells++;
                }
            }
            return surroundingCells;
        }
        public bool CellStatus(DictionaryEntry cell, string key)
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
                return false;
            }
            return true;
        }
        public void NewCell(int x, int y)
        {

            cells.Add($"{x},{y}", true);
        }
        public void NewCells(List<int[]> coordinates, Hashtable celltable)
        {
            foreach (int[] coordinate in coordinates)
            {
                Hashtable neighbourCells = FindSurroundingCells(coordinate[0], coordinate[1]);
                if (!celltable.Contains($"{coordinate[0]},{coordinate[1]}") && neighbourCells.Count == 3)
                {

                    celltable.Add($"{coordinate[0]},{coordinate[1]}", true);
                }

            }
        }
        public List<int[]> AdjacentCoordinates(string position)
        {
            string[] coordinates = position.Split(',');
            int x = Convert.ToInt32(coordinates[0]);
            int y = Convert.ToInt32(coordinates[1]);
            return new List<int[]>
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
