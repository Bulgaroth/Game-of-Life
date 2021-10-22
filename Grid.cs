using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjminPOO
{
    class Grid
    {
        private int _n { get; set; }
        public int n { get { return _n; } set { _n = value; } }
        public Cell[,] TabCells;

        public Grid(int nbCells, List<Coords> AliveCellCoords)
        {
            n = nbCells;
            TabCells = new Cell[n, n];
            bool state = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    foreach (Coords c in AliveCellCoords)
                    {
                        state = c.x == i && c.y == j;
                        if (state) break;
                    }
                    TabCells[i, j] = new Cell(state);
                }
            }
        }

        public int getNbAliveNeighboor(int i, int j)
        {
            int nbAliveNeighboor = 0;
            foreach (Coords n in getCoordsNeighboor(i, j))
            {
                nbAliveNeighboor += TabCells[n.x, n.y].isAlive ? 1 : 0;
            }

            return nbAliveNeighboor;
        }

        public List<Coords> getCoordsNeighboor(int x, int y)
        {
            int startI = x == 0 ? x : x - 1;
            int startJ = y == 0 ? y : y - 1;
            int EndI = x == n ? x : x + 1;
            int EndJ = y == n ? y : y + 1;

            List<Coords> coordNeighboors = new();
            for (int i = startI; i <= EndI; i++)
            {
                for (int j = startJ; j <= EndJ; j++)
                {
                    if (!(i == x && j == y) && i<n && j<n) coordNeighboors.Add(new Coords(i, j));
                }
            }
            return coordNeighboors;
        }

        public List<Coords> getCoordsCellsAlive()
        {
            List<Coords> coordCellsAlive = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (TabCells[i, j].isAlive) coordCellsAlive.Add(new Coords(i, j));
                }
            }

            return coordCellsAlive;
        }

        public void UpdateGrid()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int neighboorCount = getNbAliveNeighboor(i, j);
                    TabCells[i, j].nextState = TabCells[i, j].isAlive ? neighboorCount == 3 || neighboorCount == 2 : neighboorCount == 3;
                }
            }

            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) TabCells[i, j].Update();
        }

        public void DisplayGrid()
        {
            string sep = "+---";
            for (int i = 0; i < n-1; i++) sep += "+---";
            sep += "+";

            List<Coords> coordAlive = getCoordsCellsAlive();

            for (int i = 0; i<n; i++)
            {
                Console.WriteLine(sep);
                Console.Write("| ");
                for(int j = 0; j<n; j++)
                {
                    if (TabCells[i,j].isAlive) Console.Write("X");
                    else Console.Write(" ");
                    Console.Write(" | ");
                }
                Console.Write("\n");
            }
            Console.WriteLine(sep);
        }
    }
}
