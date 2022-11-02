using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElectricVehicle
{
    class Trunk
    {
        private ImageFile imageFile;
        private ActionSound actionSound;

        public void OPEN(PictureBox trunkParam)
        {
            SetBackgroundImage(trunkParam, "Trunk_Open.png"); 
            PlaySound("trunkopen.wav");
        }

        public void CLOSE(PictureBox trunkParam)
        {
            SetBackgroundImage(trunkParam, "Trunk_Close.png"); 
            PlaySound("trunkclose.wav");
        }

        public void LOCK(PictureBox trunkParam)
        {
            SetImage(trunkParam, "Trunk_Locked.png");
            PlaySound("doorlock.wav");
        }

        public void UNLOCK(PictureBox trunkParam)
        {
            trunkParam.Image = null;
            PlaySound("doorlock.wav");
        }

        #region Support Methods
        public void SetBackgroundImage(PictureBox image, string name)
        {
            imageFile = new ImageFile(name);
            image.BackgroundImage = imageFile.GetImage();
        }

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
