using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ElectricVehicle
{
    class NetworkController
    {
        private NetworkManager networkManager;
        private CommandHandler commandHandler;
        private StateNotifier stateNotifier;
        private PartsState state;
        private Thread commandHandlerThread = null;
        private Thread stateNotifierThread = null;
        private System.Windows.Forms.Button btn3G;
        private ActionFlag flag;

        public NetworkController(PartsState state, ElectricCar electricCar, MainController mainController)
        {
            this.state = state;
            networkManager = new NetworkManager();
            flag = new ActionFlag();
            commandHandler = new CommandHandler(electricCar, mainController);
            stateNotifier = new StateNotifier();
        }

        public void SetComponents(System.Windows.Forms.Button button)
        {
            btn3G = button;
        }

        public void EnableDisable()
        {
            if (flag.GetFlag() != true)
            {
                ConnectNetwork();
            }
            else
            {
                DisconnectNetwork();
            }
        }

        private void ConnectNetwork()
        {
            NoticeEnabled();
            //networkManager.Connect(flag);
            flag.SetFlag(true); // test hiihiin tuld hiiv
            stateNotifierThread = new Thread(new ThreadStart(NotifyState));
            stateNotifierThread.Start();
            commandHandlerThread = new Thread(new ThreadStart(ListenCommand));
            commandHandlerThread.Start();
        }

        private void DisconnectNetwork()
        {
            NoticeDisabled();
            //networkManager.Disconnect(flag);
            flag.SetFlag(false); // test
            stateNotifierThread.Abort();
            commandHandlerThread.Abort();
        }

        private void ListenCommand()
        {
            //commandHandler.ExecuteCommand("ENGINE.STOP"); //test
            
            while (true)
            {
                if (networkManager.GetSocket() != null)
                {
                    string Command = networkManager.GetCommand(networkManager.GetSocket());
                    if (Command != null)
                    {
                        if (Command == "CONTROLCOMMAND")
                        {
                            commandHandler.ExecuteCommand(Command);
                        }                       
                    }
                }
                Thread.Sleep(1000);
            } 
        }

        private void NotifyState()
        {
            while(true)
            {
                if (networkManager.GetSocket() != null)
                {
                    stateNotifier.Notify(networkManager, state);
                }
                Thread.Sleep(1000);
            }
        }


        #region SubMethods
        private void NoticeEnabled()
        {
            ImageFile imageFile = new ImageFile("wireless_btn_on.png");
            btn3G.BackgroundImage = imageFile.GetImage();
        }

        private void NoticeDisabled()
        {
            ImageFile imageFile = new ImageFile("wireless_btn.png");
            btn3G.BackgroundImage = imageFile.GetImage();
        }
        #endregion
    }
}
