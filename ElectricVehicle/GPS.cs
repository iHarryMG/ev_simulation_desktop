using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricVehicle
{
    class GPS
    {
        private PartsState state;

        public GPS(PartsState state)
        {
            this.state = state;
        }

        public void ON()
        {
            state.GPSState = true;
        }

        public void OFF()
        {
            state.GPSState = false;
        }
        
        public void SetLocation(string location)
        {
            state.LocationState = location;
        }
    }
}
