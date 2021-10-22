using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjminPOO
{
    class Coords
    {
        private int _x;
        public int x { get { return _x; } set { _x = value; } }

        private int _y;
        public int y { get { return _y; } set { _y = value; } }

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() { return _x + " / " + _y; }
    }
}
