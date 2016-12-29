using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Logic.Interfaces;

namespace SmartHouse.Logic.Entities
{
    public class LigthModule : IModule
    {
        private PowerStatus powerSatatus;
        private string moduleName = "Ligth";

        public LigthModule()
        {
            moduleName = "Ligth";
        }

        public LigthModule(string name)
        {
            moduleName = name;
        }

        public string GetStatus()
        {
            switch (powerSatatus)
            {
                case PowerStatus.PowerOn:
                    {
                        return "Status of " + moduleName + ": Module Power On";
                    }
                case PowerStatus.PowerOff:
                    {
                        return "Status of " + moduleName + ": Module Power Off";
                    }
            }
            return "Unknow Status!";
        }

        public string PowerOff()
        {
            powerSatatus = PowerStatus.PowerOff;
            return GetStatus();
        }

        public string PowerUp()
        {
            powerSatatus = PowerStatus.PowerOn;
            return GetStatus();
        }
        enum PowerStatus
        {
            PowerOn, PowerOff
        }

        public override string ToString()
        {
            return moduleName;
        }
    }
}
