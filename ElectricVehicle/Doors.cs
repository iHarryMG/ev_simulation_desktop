using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ElectricVehicle
{
    class Doors
    {
        private ImageFile imageFile;
        private ActionSound actionSound;

        public void LOCK(PictureBox lockDoor)
        {
            SetBackgroundImage(lockDoor, "lock.png");
            PlaySound("doorlock.wav");
        }

        public void UNLOCK(PictureBox unlockDoor)
        {
            SetBackgroundImage(unlockDoor, "un_lock.png");
            PlaySound("doorlock.wav");
        }

        #region Support Methods
        public void SetBackgroundImage(PictureBox image, string name)
        {
            imageFile = new ImageFile(name);
            image.BackgroundImage = imageFile.GetImage();
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
