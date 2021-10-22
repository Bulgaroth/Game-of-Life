using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EnjminPOO
{
    class Game
    {
        private int n;
        private int iter;
        private bool untilEndOfTimes = true;
        public Grid grid;

        List<Coords> AliveCellCords  = new List<Coords> { new Coords(1, 0),
                                                          new Coords(0, 2),
                                                          new Coords(1, 2),
                                                          new Coords(2, 2),
                                                          new Coords(2, 1) }; // Glider

        public Game(int nbCells)
        {
            n = nbCells;
            grid = new Grid(n, AliveCellCords);
        }

        public Game(int nbCells, int nbIterations) : this(nbCells)
        {
            n = nbCells;
            iter = nbIterations;
            grid = new Grid(n, AliveCellCords);
            untilEndOfTimes = false;
        }

        public void RunGameConsole()
        {
            Console.WriteLine("Press Enter to run the game of life !");
            grid.DisplayGrid();
            Console.ReadLine();

            if (untilEndOfTimes) while (grid.getCoordsCellsAlive().Count >= 0) Run();
            else for (int i = 0; i < iter; i++) Run();
        }

        public void Run()
        {
            grid.UpdateGrid();
            grid.DisplayGrid();
            Thread.Sleep(500);
            Console.Clear();
        }
    }
}
