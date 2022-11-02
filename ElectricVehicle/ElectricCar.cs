using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace ElectricVehicle
{
    public partial class ElectricCar : Form
    {
        /*
         * Electric Car : Nissan Leaf 2011
         * Web site: www.nissanusa.com/leaf-electric-car/index#/leaf-electric-car/index
         * Reference website: nissanleafwiki.com/index.php?title=Battery,_Charging_System
         * 
         * Battery Capacity:
         * 34kWh - 100miles (160km) 
         * 12V
         * 
         * Average Speed : 24mph
         * 120 V portable trickle charging cable
         * Normal charge uses the charging device (AC 220 - 240 volt, 20A)
         */

        // Classes *********************************
        private MainController mainController;        
        private SoundPlayer soundPlayer;
        internal ActionFlag actionFlag;
        private ActionFlag chargerFlag;
        internal ActionFlag alarmFlag;
        internal ActionFlag is_attacked;

        
        // Variables *******************************
        internal Image _FrontLight = null;
        internal Image _SalonLight = null;

        public ElectricCar()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            is_attacked = new ActionFlag();            
            actionFlag = new ActionFlag();
            chargerFlag = new ActionFlag();
            mainController = new MainController(this, soundPlayer);
        }
        
        private void trackBar_FrontLight_Scroll_1(object sender, EventArgs e)
        {
            mainController.TurnOnHeadLights(actionFlag);
            _FrontLight = mainController.GetImage();            
        }

        private void trackBar_SalonLight_Scroll(object sender, EventArgs e)
        {
            mainController.TurnOnInteriorLight(actionFlag);
            _SalonLight = mainController.GetImage();             
        }

        private void trackBar_Doors_Scroll(object sender, EventArgs e)
        {
            mainController.LockUnlockDoors();
        }

        private void trackBar_Trunk_Scroll(object sender, EventArgs e)
        {
            mainController.LockUnlockTrunk();            
        }

        private void trackBar_Alarm_Scroll(object sender, EventArgs e)
        {
            mainController.TurnOnOffAlarm();
            alarmFlag = mainController.GetAlarmFlag();
        }

        private void trackBar_GPS_Scroll(object sender, EventArgs e)
        {
            mainController.TurnOnOffGPS();            
        }        

        private void button_TrunkOpen_Click(object sender, EventArgs e)
        {
            mainController.OpenTrunk();            
        }

        private void button_TrunkClose_Click(object sender, EventArgs e)
        {
            mainController.CloseTrunk();            
        }

        private void button_EngineStart_Click(object sender, EventArgs e)
        {
            mainController.StartEngine();            
        }

        private void button_EngineStandBy_Click(object sender, EventArgs e)
        {
            mainController.StandByEngine();
            actionFlag = mainController.GetFlag();
        }

        private void button_EngineStop_Click(object sender, EventArgs e)
        {
            mainController.StopEngine();                        
        }

        private void button_TurnOnOffPlayer_Click(object sender, EventArgs e)
        {
            mainController.TurnOnOffAudioPlayer(actionFlag);
        }

        private void button_SelectMusic_Click(object sender, EventArgs e)
        {
            mainController.SelectMusic();            
        }

        private void button_PlayMusic_Click(object sender, EventArgs e)
        {
            mainController.PlayMusic();            
        }

        private void button_StopMusic_Click(object sender, EventArgs e)
        {
            mainController.StopMusic();            
        }

        private void button_QuickCharge_Click(object sender, EventArgs e)
        {            
            mainController.QuickChargeBattery(chargerFlag);
        }

        private void button_NormalCharge_Click(object sender, EventArgs e)
        {            
            mainController.NormalChargeBattery(chargerFlag);
        }

        private void button_3GConnection_Click(object sender, EventArgs e)
        {
            mainController.EnableDisableNetConnection();
        }

        private void btn_LocationInsert_Click(object sender, EventArgs e)
        {
            mainController.InsertLocation(this.txt_Location.Text);
        }
        
       
    }
}
