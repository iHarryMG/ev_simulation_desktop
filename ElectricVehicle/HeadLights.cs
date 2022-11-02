using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ElectricVehicle
{
    class HeadLights
    {
        /*
         * HeadLight LED: 50W
         */
        private ImageFile imageFile;
        private PartsState state;

        public HeadLights(PartsState state)
        {
            this.state = state;
        }

        public Bitmap SetTurnOn()
        {
            state.HeadLightsState = true;
            imageFile = new ImageFile("frontlight_small_size.png");
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
            state.HeadLightsState = false;
            return null;
        }


        
    }
}
