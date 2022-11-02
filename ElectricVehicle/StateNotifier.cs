using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricVehicle
{
    class StateNotifier
    {
        public void Notify(NetworkManager networkManager, PartsState state)
        {
            networkManager.SendState(networkManager.GetSocket(), state.GetStates());
        }
    }
}
