using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ElectricVehicle
{
    class BatteryController
    {
        private Battery battery;
        private int TimerInterval = 1000;

        public BatteryController(Battery battery)
        {
            this.battery = battery;
        }     

        public int GetEnergy()
        {
            return battery.GetEnergy();
        }

        public Battery GetBattery()
        {
            return battery;
        }

        public ProgressBar GetBatteryPB()
        {
            return battery.GetBattery();
        }
        
    }
}
