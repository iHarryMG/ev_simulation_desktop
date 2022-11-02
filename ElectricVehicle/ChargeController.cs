using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ElectricVehicle
{
    class ChargeController
    {
        private Charger charger;
        private ElectricCar electricCar;
        private ImageFile imageFile;
        private ActionFlag chargerFlag;
        private System.Windows.Forms.Button btnCharge;
        private System.Windows.Forms.PictureBox pbCharge;
        private System.Windows.Forms.Label lblCharge;

        public ChargeController(ElectricCar electricCar)
        {
            charger = new Charger();
            this.electricCar = electricCar;
        }

        public void SetComponents(System.Windows.Forms.Button button, System.Windows.Forms.PictureBox pictureBox, System.Windows.Forms.Label label)
        {
            this.btnCharge = button;
            this.pbCharge = pictureBox;
            this.lblCharge = label;
        }

        public void QuickCharge(ActionFlag flag, BatteryController batteryController)
        {
            this.chargerFlag = flag;
            if (chargerFlag.GetFlag() == true)
            {
                chargerFlag.SetFlag(charger.StopQuickCharge(batteryController));
                SetCharger("un_pluggedin.png", "START", Color.Green);
            }
            else
            {
                chargerFlag.SetFlag(charger.QuickCharge(batteryController));
                SetCharger("pluggedin.png", "STOP", Color.Red);                
            }
            
        }        

        public void NormalCharge(ActionFlag flag, BatteryController batteryController)
        {
            this.chargerFlag = flag;
            if (chargerFlag.GetFlag() == true)
            {
                chargerFlag.SetFlag(charger.StopNormalCharge(batteryController));
                SetCharger("un_pluggedin.png", "START", Color.Green);
            }
            else
            {
                chargerFlag.SetFlag(charger.NormalCharge(batteryController));
                SetCharger("pluggedin.png", "STOP", Color.Red);
            }
        }

        private void SetCharger(string imageName, string text, Color color)
        {
            imageFile = new ImageFile(imageName);
            pbCharge.Image = imageFile.GetImage();
            btnCharge.Text = text;
            btnCharge.ForeColor = color;
        }
    }
}
