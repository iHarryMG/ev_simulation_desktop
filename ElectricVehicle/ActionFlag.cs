using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricVehicle
{
    class ActionFlag
    {
        private bool _Flag;
     
        public void SetFlag(bool flag)
        {
            this._Flag = flag;
        }
        public bool GetFlag()
        {
            return _Flag;
        }
    }
}
