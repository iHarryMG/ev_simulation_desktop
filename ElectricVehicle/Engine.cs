using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ElectricVehicle
{
    class Engine
    {
        private PartsState state;
        private ImageFile imageFile;
        private ActionSound actionSound;
        private PictureBox enginePicBox;

        public Engine(PartsState state, PictureBox enginePicBox)
        {
            this.state = state;
            this.enginePicBox = enginePicBox;
        }

        public void SetStart()
        {
            SetImage(enginePicBox, "Engine_On.png");
            PlaySound("enginestart.wav");
        }

        public int START(int energy)
        {        
            while (energy != 0)
            {
                energy--;
                Thread.Sleep(1000);
            }
            return energy;
        }

        public void STANDBY(ActionFlag flag)
        {
            state.EngineState = true;
            flag.SetFlag(true);
            SetImage(enginePicBox, "Engine_On.png");
            PlaySound("enginekey.wav");
        }

        public void STOP(ActionFlag flag)
        {
            state.EngineState = false;
            flag.SetFlag(false);
            enginePicBox.Image = null;
            PlaySound("enginekey.wav");
        }       

        #region Support Methods
        public void SetImage(PictureBox image, string name)
        {
            imageFile = new ImageFile(name);
            image.Image = imageFile.GetImage();
        }

        public void PlaySound(string name)
        {
            actionSound = new ActionSound();
            actionSound.SetSound(name);
            actionSound.Play();
        }
        #endregion
    }
}
