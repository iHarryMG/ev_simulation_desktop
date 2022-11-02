using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElectricVehicle
{
    class SecurityAlarmController
    {
        private SecurityAlarm securityAlarm;
        private PictureBox AlarmPicBox;
        private ActionFlag alarmFlag;
        
        public SecurityAlarmController(PartsState state, ActionFlag is_attacked, PictureBox alarm)
        {
            securityAlarm = new SecurityAlarm(state, is_attacked);
            AlarmPicBox = alarm;
            alarmFlag = new ActionFlag();
        }

        public void TurnOnOffAlarm(int alarmState)
        {
            if (alarmState != 0)
                TurnOn();
            else
                TurnOff();
        }

        private void TurnOn()
        {
            AlarmPicBox.Visible = true;
            securityAlarm.ON(alarmFlag);
        }

        private void TurnOff()
        {
            AlarmPicBox.Visible = false;
            securityAlarm.OFF(alarmFlag);
        }

        public ActionFlag GetAlarmFlag()
        {
            return alarmFlag;
        }

    }
}
