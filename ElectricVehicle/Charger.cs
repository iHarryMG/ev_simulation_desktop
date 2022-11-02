using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ElectricVehicle
{
    class Charger
    {
        BatteryController batteryController;
        private Battery battery;
        private Thread normalChargeThread = null;

        public bool QuickCharge(BatteryController batteryController)
        {
            this.battery = batteryController.GetBattery();
            while(batteryController.GetBatteryPB().Value != batteryController.GetBatteryPB().Maximum)
            {
                battery.SetEnergy(1);
            }
            return true;
        }

        public bool StopQuickCharge(BatteryController batteryController)
        {
            return false;
        }

        public bool NormalCharge(BatteryController batteryController)
        {
            this.batteryController = batteryController;
            normalChargeThread = new Thread(new ThreadStart(ChargeNormal));
            normalChargeThread.Start();
            return true;
        }

        public void ChargeNormal()
        {
            this.battery = batteryController.GetBattery();
            while (batteryController.GetBatteryPB().Value != batteryController.GetBatteryPB().Maximum)
            {
                battery.SetEnergy(1);
                Thread.Sleep(100);
            }
        }

        public bool StopNormalCharge(BatteryController batteryController)
        {
            normalChargeThread.Abort();
            return false;
        }

        
    }
}
