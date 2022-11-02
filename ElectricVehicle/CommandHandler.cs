using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricVehicle
{
    class CommandHandler
    {
        /*
         * ***** EV Control Commands Reference *******
         * 
         * 1. Engine StandBy/Start/Stop => ENGINE.STANDBY/.START/.STOP
         * 2. HeadLights On/Off => HEADLIGHTS.ON/.OFF
         * 3. InteriorLight On/Off => INTERIORLIGHT.ON/.OFF
         * 4. Doors Lock/Unlock => DOORS.LOCK/.UNLOCK
         * 5. Trunk Lock/Unlock => TRUNK.LOCK/.UNLOCK
         * 6. SecurityAlarm On/Off => SECURITYALARM.ON/.OFF
         * 7. GPS On/Off => GPS.ON/.OFF
         * 8. AudioPlayer On/Off => AUDIOPLAYER.ON/OFF
         * 
         * *******************************************
         */

        private ElectricCar electricCar;
        private MainController mainController;
        
        public CommandHandler(ElectricCar electricCar, MainController mainController)
        {
            this.electricCar = electricCar;
            this.mainController = mainController;
        }

        public void ExecuteCommand(string cmd)
        {
            if (cmd != null)
            {
                string[] Command = SplitCommand(cmd);
                switch (Command[0])
                {
                    case "ENGINE":
                        switch (Command[1])
                        {
                            case "STANDBY":
                                mainController.StandByEngine();
                                electricCar.actionFlag = mainController.GetFlag();
                                break;
                            case "START":
                                mainController.StartEngine();
                                break;
                            case "STOP":
                                mainController.StopEngine();
                                break;
                        }
                        break;
                    case "HEADLIGHTS":
                        switch (Command[1])
                        {
                            case "ON":
                                electricCar.trackBar_FrontLight.Value = 1;
                                mainController.TurnOnHeadLights(electricCar.actionFlag);
                                electricCar._FrontLight = mainController.GetImage();
                                break;
                            case "OFF":
                                electricCar.trackBar_FrontLight.Value = 0;
                                mainController.TurnOnHeadLights(electricCar.actionFlag);
                                electricCar._FrontLight = mainController.GetImage();
                                break;
                        }
                        break;
                    case "INTERIORLIGHT":
                        switch (Command[1])
                        {
                            case "ON":
                                electricCar.trackBar_SalonLight.Value = 1;
                                mainController.TurnOnInteriorLight(electricCar.actionFlag);
                                electricCar._SalonLight = mainController.GetImage();
                                break;
                            case "OFF":
                                electricCar.trackBar_SalonLight.Value = 0;
                                mainController.TurnOnInteriorLight(electricCar.actionFlag);
                                electricCar._SalonLight = mainController.GetImage();
                                break;
                        }
                        break;
                    case "DOORS":
                        switch (Command[1])
                        {
                            case "LOCK":
                                electricCar.trackBar_Doors.Value = 1;
                                mainController.LockUnlockDoors();
                                break;
                            case "UNLOCK":
                                electricCar.trackBar_Doors.Value = 0;
                                mainController.LockUnlockDoors();
                                break;
                        }
                        break;
                    case "TRUNK":
                        switch (Command[1])
                        {
                            case "LOCK":
                                electricCar.trackBar_Trunk.Value = 1;
                                mainController.LockUnlockTrunk();
                                break;
                            case "UNLOCK":
                                electricCar.trackBar_Trunk.Value = 0;
                                mainController.LockUnlockTrunk();
                                break;
                        }
                        break;
                    case "SECURITYALARM":
                        switch (Command[1])
                        {
                            case "ON":
                                electricCar.trackBar_Alarm.Value = 1;
                                electricCar.alarmFlag = mainController.GetAlarmFlag();
                                break;
                            case "OFF":
                                electricCar.trackBar_Alarm.Value = 0;
                                electricCar.alarmFlag = mainController.GetAlarmFlag();
                                break;
                        }
                        break;
                    case "GPS":
                        switch (Command[1])
                        {
                            case "ON":
                                electricCar.trackBar_GPS.Value = 1;
                                mainController.TurnOnOffGPS();
                                break;
                            case "OFF":
                                electricCar.trackBar_GPS.Value = 0;
                                mainController.TurnOnOffGPS();
                                break;
                        }
                        break;
                    case "AUDIOPLAYER":
                        switch (Command[1])
                        {
                            case "ON":
                                mainController.TurnOnOffAudioPlayer(electricCar.actionFlag);
                                break;
                            case "OFF":
                                mainController.TurnOnOffAudioPlayer(electricCar.actionFlag);
                                break;
                        }
                        break;
                }
            }
        }

        public string[] SplitCommand(string command)
        {
            return command.Split('.');
        }
    }
}
