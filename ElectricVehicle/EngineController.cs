using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ElectricVehicle
{
    class EngineController
    {   
        private Engine engine;
        private BatteryController batteryController;
        private ActionFlag actionFlag;

        private Thread motorThread = null;

        private PictureBox enginePicBox;
        private Button engineStop;
        private Button engineStandBy;
        private Button engineStart;

        private int MotorEnergy = 0;

        public EngineController(PartsState state, ElectricCar electricCar, BatteryController batteryController)
        {
            this.batteryController = batteryController;
            SetComponents(state, electricCar.button_EngineStop, electricCar.button_EngineStandBy, electricCar.button_EngineStart, electricCar.pictureBox_Engine);
        }
                
        public void SetComponents(PartsState state, Button engineStop, Button engineStandBy, Button engineStart, PictureBox enginePicBox)
        {
            actionFlag = new ActionFlag();
            engine = new Engine(state, enginePicBox);
            this.engineStop = engineStop;
            this.engineStandBy = engineStandBy;
            this.engineStart = engineStart;
        }   

        public void StandByEngine()
        {
            if(motorThread != null)
                motorThread.Abort();
            
            engine.STANDBY( actionFlag);
            EnableEngineKey(engineStart, engineStandBy, engineStop, true, false, true);
        }

        public void StartEngine()
        {
            motorThread = new Thread(new ThreadStart(StartMotor));
            motorThread.Start();
        }

        private void StartMotor()
        {
            EnableEngineKey(engineStart, engineStandBy, engineStop, false, true, false);
            engine.SetStart();
            do
            {
                if (MotorEnergy > 0)
                    MotorEnergy = engine.START(MotorEnergy);

                MotorEnergy = batteryController.GetEnergy();
            }
            while (MotorEnergy != 0);
            StopEngine();
        }

        public void StopEngine()
        {            
            engine.STOP(actionFlag);
            EnableEngineKey(engineStart, engineStandBy, engineStop, false, true, false);
        }   

        public ActionFlag GetFlag()
        {
            return actionFlag;
        }

        private void EnableEngineKey(Button startEngine, Button standbyEngine, Button stopEngine, bool start, bool standby, bool stop)
        {
            startEngine.Enabled = start;
            standbyEngine.Enabled = standby;
            stopEngine.Enabled = stop;
        }


    }
}
