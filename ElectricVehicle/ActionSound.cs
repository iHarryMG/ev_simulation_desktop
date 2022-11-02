using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace ElectricVehicle
{
    class ActionSound
    {
        private SoundPlayer soundPlayer;

        public ActionSound()
        {
            soundPlayer = new SoundPlayer();
        }

        public void SetSound(string soundName)
        {
            string Path = "C:/Users/BMG/Documents/4학년/1학기/종합설계/EV/Sounds/";
            soundPlayer.SoundLocation = Path + soundName;          
        }

        public void Play()
        {
            soundPlayer.Play();
        }

        public void Stop()
        {
            soundPlayer.Stop();
            soundPlayer.Dispose();
        }
    }
}
