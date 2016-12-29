using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Logic.Interfaces;

namespace SmartHouse.Logic.Entities
{
    public class MicroclimatModule : IModule
    {
        private PowerStatus powerStatus;
        private string moduleName;
        private int temperature = 18;
        private int userTemperature = 0;

        public MicroclimatModule()
        {
            moduleName = "Microclimat";
        }

        public MicroclimatModule(string name)
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

        public string SetTemperature(int userTemp)
        {
            userTemperature = userTemp;
            if (userTemperature < temperature)
                CoolDown();
            else
                HeatUp();
            return GetStatus();
        }

        private void CoolDown()
        {
            while (temperature > userTemperature)
                temperature--;
        }

        private void HeatUp()
        {
            while (temperature < userTemperature)
                temperature++;
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
