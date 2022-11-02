using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricVehicle
{
    class PartsState
    {
        private bool Engine;     
        private bool HeadLights;
        private bool InteriorLight;
        private bool Doors;
        private bool Trunk;
        private bool SecurityAlarm;
        private bool GPS;         
        private bool AudioPlayer;
        private bool _is_attacked;
        private string Location = "";

        public string GetStates()
        {
            string[] States = new string[10];
            string StatesPacket = null;

            States[0] = "ENGINE." + Engine.ToString();
            States[1] = "HEADLIGHTS." + HeadLights.ToString();
            States[2] = "INTERIORLIGHT." + InteriorLight.ToString();
            States[3] = "DOORS." + Doors.ToString();
            States[4] = "TRUNK." + Trunk.ToString();
            States[5] = "ALARM." + SecurityAlarm.ToString();
            States[6] = "GPS." + GPS.ToString();
            States[7] = "AUDIOPLAYER." + AudioPlayer.ToString();
            States[8] = "LOCATION." + Location;
            States[9] = "ISATTACKED." + _is_attacked.ToString();

            for (int i = 0; i < States.Length-1; i++)
            {
                StatesPacket += States[i] + ":";
            }
            StatesPacket += States[9];

            return StatesPacket;
        }

        public bool EngineState 
        {
            get { return Engine; }
            set { Engine = value; }
        }

        public bool HeadLightsState
        {
            get { return HeadLights; }
            set { HeadLights = value; }
        }

        public bool InteriorLightState
        {
            get { return InteriorLight; }
            set { InteriorLight = value; }
        }

        public bool DoorsState 
        {
            get { return Doors; }
            set { Doors = value; }
        }

        public bool TrunkState
        {
            get { return Trunk; }
            set { Trunk = value; }
        }

        public bool AlarmState
        {
            get { return SecurityAlarm; }
            set { SecurityAlarm = value; }
        }

        public bool GPSState
        {
            get { return GPS; }
            set { GPS = value; }
        }

        public bool AudioPlayerState
        {
            get { return AudioPlayer; }
            set { AudioPlayer = value; }
        }

        public bool _Is_Attacked
        {
            get { return _is_attacked; }
            set { _is_attacked = value; }
        }

        public string LocationState 
        {
            get { return Location; }
            set { Location = value; }
        }
    }
   
}
