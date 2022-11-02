using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace ElectricVehicle
{
    class InteriorLights
    {
        /*
         * InteriorLights LED: 0.5W
         */
        private ImageFile imageFile;
        private PartsState state;

        public InteriorLights(PartsState state)
        {
            this.state = state;
        }

        public Bitmap SetTurnOn()
        {
            state.InteriorLightState = true;
            imageFile = new ImageFile("salonlight_small_size.png");
            return (Bitmap)imageFile.GetImage();
        }

        public int TURNON(int energy)
        {
            while (energy != 0)
            {
                energy--;
                Thread.Sleep(1000);
            }
            return energy;
        }

        public Bitmap TURNOFF()
        {
            state.InteriorLightState = false;
            return null;
        }

        
    }
}
