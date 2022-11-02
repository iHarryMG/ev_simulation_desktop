using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElectricVehicle
{
    class DoorController
    {
        private Doors doors;   
        private Trunk trunk;

        public DoorController(string doorType, int doorState, PictureBox lockDoor)
        {
            doors = new Doors();    

            if (doorType == "DOORS")
            {
                if (doorState != 0)
                {
                    doors.LOCK(lockDoor);                   
                }
                else
                {
                    doors.UNLOCK(lockDoor);                   
                }
            }           
        }

        public DoorController(string doorType, int doorState, Button trunkOpen, Button trunkClose, PictureBox trunkParam)
        {         
            trunk = new Trunk();

            if (doorType == "TRUNK")
            {
                if(trunkClose.Enabled == false)
                {
                    if (doorState != 0)
                        trunk.LOCK(trunkParam);
                    else
                        trunk.UNLOCK(trunkParam);
                }                
            }
        }

        public DoorController(int trunkLockedState, string trunkName, Button trunkOpen, Button trunkClose, PictureBox trunkParam)
        {
            trunk = new Trunk();

            if (trunkLockedState != 1)
            {
                if (trunkName == "button_TrunkOpen")
                {
                    trunk.OPEN(trunkParam);
                    trunkClose.Enabled = true;
                    trunkOpen.Enabled = false;
                }
                else if (trunkName == "button_TrunkClose")
                {
                    trunk.CLOSE(trunkParam);
                    trunkOpen.Enabled = true;
                    trunkClose.Enabled = false;
                }
            }
        }
    }
}
