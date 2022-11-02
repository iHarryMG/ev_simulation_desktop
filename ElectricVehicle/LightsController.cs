using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace ElectricVehicle
{
    class LightsController
    {
        private ElectricCar electricCar;
        private BatteryController batteryController;
        private HeadLights headLights;
        private InteriorLights interiorLights;
        private Thread headLightsThread = null;
        private Thread interiorLightThread = null;
        private ActionFlag actionFlag;
        private Bitmap _Light = null;
        private int HeadLightsEnergy = 0;
        private int InteriorLightEnergy = 0;

        public LightsController(PartsState state, ElectricCar electricCar, BatteryController batteryController)
        {
            this.electricCar = electricCar;
            this.batteryController = batteryController;
            actionFlag = new ActionFlag();
            headLights = new HeadLights(state);
            interiorLights = new InteriorLights(state); 
        }

        public void TurnOnOffHeadLights(ActionFlag flag, int lightState)
        {
            this.actionFlag = flag;
            if (flag.GetFlag() != false)
            {
                if (lightState != 0)
                {
                    _Light = headLights.SetTurnOn();
                    headLightsThread = new Thread(new ThreadStart(TurnOnHeadLights));
                    headLightsThread.Start();
                }
                else
                {
                    _Light = headLights.TURNOFF();
                    if (headLightsThread != null)
                        headLightsThread.Abort();                    
                }
            }
        }

        private void TurnOnHeadLights()
        {
            do
            {
                if (actionFlag.GetFlag() != true)
                    break;

                if (HeadLightsEnergy > 0)
                    HeadLightsEnergy = headLights.TURNON(HeadLightsEnergy);

                HeadLightsEnergy = batteryController.GetEnergy();
            }
            while (HeadLightsEnergy != 0);
            TurnOffHeadLights();
        }

        private void TurnOffHeadLights()
        {
            electricCar._FrontLight = null;
            electricCar.pictureBox_VehicleSkin.Invalidate();
            electricCar.trackBar_FrontLight.Value = 0;
        }
        
        public void TurnOnOffInteriorLights(ActionFlag actionFlag, int lightState)
        {
            if (actionFlag.GetFlag() == true)
            {
                if (lightState != 0)
                {
                    _Light = interiorLights.SetTurnOn();
                    interiorLightThread = new Thread(new ThreadStart(TurnOnInteriorLight));
                    interiorLightThread.Start();
                }
                else
                {
                    _Light = interiorLights.TURNOFF();
                    if (interiorLightThread != null)
                        interiorLightThread.Abort();  
                }
            }
        }

        private void TurnOnInteriorLight()
        {
            do
            {
                if (actionFlag.GetFlag() != true)
                    break;

                if (InteriorLightEnergy > 0)
                    InteriorLightEnergy = interiorLights.TURNON(InteriorLightEnergy);

                InteriorLightEnergy = batteryController.GetEnergy();
            }
            while (InteriorLightEnergy != 0);
            TurnOffInteriorLights();
        }

        private void TurnOffInteriorLights()
        {
            electricCar._SalonLight = null;
            electricCar.pictureBox_VehicleSkin.Invalidate();
            electricCar.trackBar_SalonLight.Value = 0;
        }

        public Bitmap GetImage()
        {
            return _Light;
        }

    }
}
