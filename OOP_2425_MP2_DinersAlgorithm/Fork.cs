using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2425_MP2_DinersAlgorithm
{
    internal class Fork
    {
        private bool _inUse = false;

        public bool getForkStatus() { return !_inUse; }

        public void setStatus(bool newStatus) { _inUse = newStatus; }
    }
}
