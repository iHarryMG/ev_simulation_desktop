using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ElectricVehicle
{
    class SecurityAlarm
    {
        private PartsState state;
        private Thread securityAlarmThread = null;
        private ActionFlag is_attacked;
        private ActionSound actionSound;

        public SecurityAlarm(PartsState state, ActionFlag is_attacked)
        {
            this.state = state;
            this.is_attacked = is_attacked;
            actionSound = new ActionSound();
        }
        public void ON(ActionFlag flag)
        {
            state.AlarmState = true;
            flag.SetFlag(true);
            securityAlarmThread = new Thread(new ThreadStart(_is_attacked_LISTENER));
            securityAlarmThread.Start();
        }

        public void OFF(ActionFlag flag)
        {
            state.AlarmState = false;
            if (state._Is_Attacked == true)
            {
                state._Is_Attacked = false;
                SOUNDOFF();
            }
            flag.SetFlag(false);
            securityAlarmThread.Abort();
        }
        
        public void _is_attacked_LISTENER()
        {
            while(true)
            {                    
                if ((is_attacked != null) && (is_attacked.GetFlag() != false))
                {
                    state._Is_Attacked = true;
                    SOUNDON();
                    is_attacked.SetFlag(false);
                }
                Thread.Sleep(500);
            }
        }

        private void SOUNDON()
        {
            PlaySound("alarm.wav");
        }

        private void SOUNDOFF()
        {
            StopSound();
        }

        public void PlaySound(string name)
        {            
            actionSound.SetSound(name);
            actionSound.Play();
        }

        public void StopSound()
        {
            actionSound.Stop();
        }
    }
}
