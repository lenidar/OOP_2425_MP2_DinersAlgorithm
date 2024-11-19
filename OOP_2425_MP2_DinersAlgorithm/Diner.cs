using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2425_MP2_DinersAlgorithm
{
    internal class Diner
    {
        private int _status = 0; // -1 rest, 0 wait, 1 eating
        private int _timer = 0;
        private bool _hasActivated = false;
        
        public bool getHasActivated() {  return _hasActivated; }

        public int getStatus() { return _status; }

        public int getTimer() { return _timer; }

        public bool changeStatus()
        {
            bool rest = false;
            _status++;
            if (_status == 2)
            {
                _status = -1;
                rest = true;
                _hasActivated = true;
            }

            if (_status != 0)
                _timer = Globals._rnd.Next(0, 5) + 1;
            

            return rest;
        }

        public bool Tick()
        {
            bool rest = false;
            _timer--;
            if (_timer == 0)
                rest = changeStatus();

            return rest;
        }
    }
}
