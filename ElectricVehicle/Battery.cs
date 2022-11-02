using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElectricVehicle
{
    class Battery
    {
        /*      
         * Battery Capacity:
         * 24kWh - 100miles (160km)         
         * 12V
         * 
         * Average Speed : 24mph
         * 120 V portable trickle charging cable
         * Normal charge uses the charging device (AC 220 - 240 volt, 20A)
         */

        private ProgressBar battery;        
        private int[] Lithium_ion_Battery;
        private int Watts;
        private int Voltage = 12;
        //private int Amphere = 100;

        public Battery(ProgressBar battery)
        {                     
            Initialize(battery);
        }

        public void Initialize(ProgressBar battery)
        {
            this.battery = battery;  
            Watts = battery.Maximum;
            Lithium_ion_Battery = new int[Watts];
            FillEnergy(Watts, Lithium_ion_Battery);
        }

        public void FillEnergy(int max, int[] battery)
        {
            for (int i = 0; i < max; i++)
            {
                battery[i] = 1;
            }
        }

        public ProgressBar GetBattery()
        {
            return this.battery;
        }

        public void SetEnergy(int energy)
        { 
            int count = 0;
            while(count != Watts)
            {
                if (Lithium_ion_Battery[count] == 0)
                {
                    Lithium_ion_Battery[count] = energy;
                    break;
                }
                count++;
            }
            ReSetBattery(this.battery, Lithium_ion_Battery);
        }

        public int GetEnergy()
        {
            int V = 0;
            int count = 0;
            
            while (Voltage != V)
            {
                V += Lithium_ion_Battery[count];
                Lithium_ion_Battery[count] = 0;
                count++;
                if (CheckExceed(count, Watts) == true)
                    break;
            }
            ReSetBattery(this.battery, Lithium_ion_Battery);
            return V;
        }

        public bool CheckExceed(int a, int b)
        {
            if (a == b)
            {
                return true;
            }
            else
                return false;
        }

        public void ReSetBattery(ProgressBar battery, int[] liBattery)
        {
            int RemainedEnergy = 0;
            for (int i = 0; i < liBattery.Length; i++)
            {
                RemainedEnergy += liBattery[i];
            }
            battery.Value = RemainedEnergy;            
        }

       
    }
}
