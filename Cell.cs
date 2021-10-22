using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjminPOO
{
    class Cell
    {
        private bool _isAlive;
        public bool isAlive { get { return _isAlive; } set { _isAlive = value; } }

        private bool _nextState;
        public bool nextState { get { return _nextState; } set { _nextState = value; } }

        public Cell(bool state) { _isAlive = state; }

        public void ComeAlive() { _nextState = true; }
        public void PassAway() { _nextState = false; }
        public void Update() { _isAlive = _nextState; }
    }
}
