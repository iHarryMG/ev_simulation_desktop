using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing;
using System.Threading;

namespace ElectricVehicle
{
    class AudioPlayer
    {
        private ImageFile imageFile;
        private PartsState state;

        public AudioPlayer(PartsState state)
        {
            this.state = state;
        }

        public void SetTurnOn(Button onoff, Button start, Button stop, Button select, Label mediaPlayer, Label nowPlaying)
        {
            state.AudioPlayerState = true;
            SetBackgroundImage(onoff, "Player_On.png");
            SetEnable(start, stop, select, true, mediaPlayer, nowPlaying, Color.MediumBlue);  
        }

        public int TURNON(int energy)
        {
            while (energy != 0)
            {
                energy--;
                Thread.Sleep(1000);
            }
            return energy;
        }

        public void TURNOFF(Button onoff, Button start, Button stop, Button select, Label mediaPlayer, Label nowPlaying)
        {
            state.AudioPlayerState = false;
            SetBackgroundImage(onoff, "Player_Off.png");
            SetEnable(start, stop, select, false, mediaPlayer, nowPlaying, Color.DimGray);            
        }

        public void Play(SoundPlayer player)
        {
            player.Play();
        }

        public void Stop(SoundPlayer player)
        {
            player.Stop();
        }

        public string Select(SoundPlayer player)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            if(openFile.FileName != "")
                player.SoundLocation = openFile.FileName;
            return GetSongName(openFile.FileName);
        }

        public string GetSongName(string name)
        {
            string[] SongName = name.Split('\\');
            return SongName[SongName.Length - 1];
        }

        public void SetBackgroundImage(Button button, string imageName)
        { 
            imageFile = new ImageFile(imageName);
            button.BackgroundImage = imageFile.GetImage();
        }

        public void SetEnable(Button start, Button stop, Button select, bool state, Label mediaPlayer, Label nowPlaying, Color color)
        {
            start.Enabled = state;
            stop.Enabled = state;
            select.Enabled = state;
            mediaPlayer.ForeColor = color;
            nowPlaying.ForeColor = color;
        }

    }
}
