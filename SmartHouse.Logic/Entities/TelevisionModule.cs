using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Logic.Interfaces;

namespace SmartHouse.Logic.Entities
{
    public class TelevisionModule : object, IModule
    {
        private PowerStatus powerStatus;
        private string moduleName = "Television";
        private int Channel = 1;
        private int VolumeLevel = 20;

        public TelevisionModule()
        {
            moduleName = "Television";
        }

        public TelevisionModule(string name)
        {
            moduleName = name;
        }

        public string GetStatus()
        {
            switch (powerStatus)
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
            powerStatus = PowerStatus.PowerOff;
            return GetStatus();
        }

        public string PowerUp()
        {
            powerStatus = PowerStatus.PowerOn;
            return GetStatus();
        }

        public string SwitchingChannels(int channel)
        {
            Channel = channel;
            return GetStatus();
        }

        public string VolumeUp()
        {
            if (VolumeLevel == 100)
            {
                return "Volume is max";
            }
            else
            {
                VolumeLevel++;
                return GetStatus();
            }
        }

        public string VolumeDown()
        {
            if (VolumeLevel == 0)
            {
                return "Volume is off";
            }
            else
            {
                VolumeLevel--;
                return GetStatus();
            }
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
