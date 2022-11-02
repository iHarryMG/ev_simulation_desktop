using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElectricVehicle
{
    class GPSController
    {
        private ElectricCar electricCar;
        private GPS gps;
        private PictureBox GPSpicbox;

        public GPSController(PartsState state, PictureBox gpsPicbox)
        {
            gps = new GPS(state);
            GPSpicbox = gpsPicbox;
        }

        public void SwitchOnOff(int gpsState)
        {
            if (gpsState != 0)
            {
                SwitchOn();
            }
            else
            {
                SwitchOff();
            }
        }

        public void SwitchOn()
        {   
            GPSpicbox.Visible = true;
            gps.ON();
        }

        private void SwitchOff()
        {
            GPSpicbox.Visible = false;
            gps.OFF();           
        }

        public void InsertLocation(string location)
        {
            gps.SetLocation(location);
        }
    }
}
