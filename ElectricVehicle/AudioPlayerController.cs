using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.Threading;

namespace ElectricVehicle
{
    class AudioPlayerController
    {
        private BatteryController batteryController;
        private SoundPlayer soundPlayer;
        private AudioPlayer audioPlayer;
        private Thread audioPlayerThread = null;
        private ActionFlag actionFlag;
        private Button onoff;
        private Button start;
        private Button stop;
        private Button select;
        private Label mediaPlayer;
        private Label nowPlaying;
        private string SongName;
        private int Energy;
        private bool EnergyFlag = false;
        private int AudioPlayerEnergy = 0;
        
        public AudioPlayerController(PartsState state, ElectricCar electricCar, BatteryController batteryController, SoundPlayer player)
        {
            audioPlayer = new AudioPlayer(state);
            this.soundPlayer = player;
            this.batteryController = batteryController;
            SetComponents(electricCar.button_TurnOnOffPlayer, electricCar.button_PlayMusic, electricCar.button_StopMusic, electricCar.button_SelectMusic, electricCar.label_MediaPlayer, electricCar.label_NowPlaying);
        }

        public void SetComponents(Button onoff, Button start, Button stop, Button select, Label mediaPlayer, Label nowPlaying)
        {
            this.actionFlag = new ActionFlag();
            this.onoff = onoff;
            this.start = start;
            this.stop = stop;
            this.select = select;
            this.mediaPlayer = mediaPlayer;
            this.nowPlaying = nowPlaying;
        }

        public void TurnOnOff(ActionFlag flag)
        {
            this.actionFlag = flag;
            if (actionFlag.GetFlag() == true)
            {
                if (CheckEnable(start, stop, select) != true)
                {
                    audioPlayerThread = new Thread(new ThreadStart(TurnOnAudioPlayer));
                    audioPlayerThread.Start(); 
                }
                else
                {
                    if (audioPlayerThread != null)
                        audioPlayerThread.Abort();
                    TurnOffAudioPlayer();
                }
            }
        }

        private void TurnOnAudioPlayer()
        {
            audioPlayer.SetTurnOn(onoff, start, stop, select, mediaPlayer, nowPlaying);
            do
            {
                if (actionFlag.GetFlag() != true)
                    break;

                if (AudioPlayerEnergy > 0)
                    AudioPlayerEnergy = audioPlayer.TURNON(AudioPlayerEnergy);

                AudioPlayerEnergy = batteryController.GetEnergy();
            }
            while (AudioPlayerEnergy != 0);
            TurnOffAudioPlayer();
        }  

        private void TurnOffAudioPlayer()
        {
            audioPlayer.TURNOFF(onoff, start, stop, select, mediaPlayer, nowPlaying);
        }            
        
        public void SelectMusic()
        {            
            SongName = audioPlayer.Select(soundPlayer);
        }

        public void Play()
        {
            audioPlayer.Play(soundPlayer);
        }

        public void Stop()
        {
            audioPlayer.Stop(soundPlayer);
        }

        public string GetSongName()
        {
            return SongName;
        }
        
        public bool CheckEnable(Button start, Button stop, Button select)
        {
            if ((start.Enabled != true) && (stop.Enabled != true) && (select.Enabled != true))
                return false;
            else
                return true;
        }
    }
}
