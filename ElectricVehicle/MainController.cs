using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricVehicle
{
    class MainController
    {
        // Classes ****************************************************      
        private ElectricCar electricCar;
        private NetworkController netController;
        private Battery battery;
        private BatteryController batteryController;
        private ChargeController chargeController;
        private EngineController engineController;
        private LightsController lightsController;
        private DoorController doorController;
        private SecurityAlarmController alarmController;
        private GPSController gpsController;
        private AudioPlayerController playerController;
        private ActionFlag actionFlag;
        private PartsState state;

        // Variables ***************************************************
        private System.Drawing.Image Lights = null;

        public MainController(ElectricCar electricCar, System.Media.SoundPlayer soundPlayer)
        {
            state = new PartsState();            
            this.electricCar = electricCar;
            battery = new Battery(electricCar.progressBar_Battery);
            batteryController = new BatteryController(battery);
            chargeController = new ChargeController(electricCar);
            engineController = new EngineController(state, electricCar, batteryController);
            lightsController = new LightsController(state, electricCar, batteryController);
            playerController = new AudioPlayerController(state, electricCar, batteryController, soundPlayer);
            gpsController = new GPSController(state, electricCar.pictureBox_GPS);
            alarmController = new SecurityAlarmController(state, electricCar.is_attacked, electricCar.pictureBox_SecurityAlarm);
            netController = new NetworkController(state, electricCar, this);
        }            

        public void StandByEngine()
        {            
            engineController.StandByEngine();
        }

        public ActionFlag GetFlag()
        {
            return engineController.GetFlag();
        }

        public void StartEngine()
        {
            engineController.StartEngine();
        }

        public void StopEngine()
        {
            engineController.StopEngine();
        }

        public void TurnOnOffAudioPlayer(ActionFlag actionFlag)
        {            
            playerController.TurnOnOff(actionFlag);
        }

        public void SelectMusic()
        {
            playerController.SelectMusic();
            electricCar.textBox_NowPlayingMusic.Text = playerController.GetSongName();
        }

        public void PlayMusic()
        {
            playerController.Play();
        }

        public void StopMusic()
        {
            playerController.Stop();
        }

        public void TurnOnHeadLights(ActionFlag actionFlag)
        {
            lightsController.TurnOnOffHeadLights(actionFlag, electricCar.trackBar_FrontLight.Value);
            Lights = lightsController.GetImage();
            electricCar.pictureBox_VehicleSkin.Invalidate();
        }       

        public void TurnOnInteriorLight(ActionFlag actionFlag)
        {
            lightsController.TurnOnOffInteriorLights(actionFlag, electricCar.trackBar_SalonLight.Value);
            Lights = lightsController.GetImage();
            electricCar.pictureBox_VehicleSkin.Invalidate();
        }

        public System.Drawing.Image GetImage()
        {
            return Lights;
        }

        public void LockUnlockDoors()
        {
            doorController = new DoorController("DOORS", electricCar.trackBar_Doors.Value, electricCar.pictureBox_LockDoor);
        }

        public void LockUnlockTrunk()
        {
            doorController = new DoorController("TRUNK", electricCar.trackBar_Trunk.Value, electricCar.button_TrunkOpen, electricCar.button_TrunkClose, electricCar.pictureBox_Trunk);
        }

        public void OpenTrunk()
        {
            doorController = new DoorController(electricCar.trackBar_Trunk.Value, electricCar.button_TrunkOpen.Name, electricCar.button_TrunkOpen, electricCar.button_TrunkClose, electricCar.pictureBox_Trunk);           
        }

        public void CloseTrunk()
        {
            doorController = new DoorController(electricCar.trackBar_Trunk.Value, electricCar.button_TrunkClose.Name, electricCar.button_TrunkOpen, electricCar.button_TrunkClose, electricCar.pictureBox_Trunk); 
        }

        public void TurnOnOffAlarm()
        {
            alarmController.TurnOnOffAlarm(electricCar.trackBar_Alarm.Value);
        }

        public ActionFlag GetAlarmFlag()
        {
            return alarmController.GetAlarmFlag();
        }

        public void TurnOnOffGPS()
        {
            gpsController.SwitchOnOff(electricCar.trackBar_GPS.Value);
        }

        public void QuickChargeBattery(ActionFlag chargerFlag)
        {
            chargeController.SetComponents(electricCar.button_QuickCharge, electricCar.pictureBox_QuickCharge, electricCar.label_QuickCharge);
            chargeController.QuickCharge(chargerFlag, batteryController);
        }

        public void NormalChargeBattery(ActionFlag chargerFlag)
        {
            chargeController.SetComponents(electricCar.button_NormalCharge, electricCar.pictureBox_NormalCharge, electricCar.label_NormalCharge);
            chargeController.NormalCharge(chargerFlag, batteryController);
        }

        public void EnableDisableNetConnection()
        {
            netController.SetComponents(electricCar.button_3GConnection);
            netController.EnableDisable();
        }

        public void InsertLocation(string location)
        {
            gpsController.InsertLocation(location);
        }
    }
}
