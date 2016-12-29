using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartHouse.Logic.Interfaces;
using System.Threading.Tasks;

namespace SmartHouse.Logic.Entities
{

    public class JalousieModule : IModule
    {
        private PowerStatus powerStatus;
        private PositionStatus positionStatus;
        private string moduleName = "Jalousie";

        public JalousieModule()
        {
            moduleName = "Jalousie";
        }

        public JalousieModule(string name)
        {
            moduleName = name;
        }

        public string GetStatus()
        {
            switch (powerStatus)
            {
                case PowerStatus.PowerOff:
                    {
                        return "Status of " + moduleName + ": Module Power Off";
                    }
                case PowerStatus.PowerOn:
                    {
                        return "Status of " + moduleName + ": Module Power On and" + positionStatus;
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

        public string SetJalousiePosition(int position)
        {
            switch (position)
            {
                case 1:
                    {
                        positionStatus = PositionStatus.Open;
                        break;
                    }
                case 2:
                    {
                        positionStatus = PositionStatus.HalfOpen;
                        break;
                    }
                case 3:
                    {
                        positionStatus = PositionStatus.Close;
                        break;
                    }
                default:
                    break;
            }
            return GetStatus();
        }

        enum PowerStatus
        {
            PowerOn, PowerOff
        }

        enum PositionStatus
        {
           Open, Close, HalfOpen 
        }

        public override string ToString()
        {
            return moduleName;
        }

    }
}
