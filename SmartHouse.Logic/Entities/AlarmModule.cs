using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Logic.Interfaces;
using System.Threading;

namespace SmartHouse.Logic.Entities
{

    public class AlarmModule : IModule
    {
        enum Status
        {
            PowerOn, PowerOff, PowerOnAndSetOnGuard, PowerOnAndSetOnTemporatyGuard, PowerOnAndGuardReset
        }

        private Status moduleStatus;
        private TimeSpan timeForGuard;
        private const int CheckDelay = 2000;
        //private string Status;
        private string moduleName = "Alarm";

        public AlarmModule()
        {
            moduleName = "Alarm";
        }

        public AlarmModule(string name)
        {
            moduleName = name;
        }

        public string GetStatus()
        {
            switch (moduleStatus)
            {
                case Status.PowerOff:
                    {
                        return "Status of " + moduleName + ": Module Power Off";
                    }
                case Status.PowerOn:
                    {
                        return "Status of " + moduleName + ": Module Power On";
                    }
                case Status.PowerOnAndSetOnGuard:
                    {
                        return "Status of " + moduleName + ": Module Power On and set on guard";
                    }
                case Status.PowerOnAndSetOnTemporatyGuard:
                    {
                        return "Status of " + moduleName + ": Module Power On and set on guard for " + timeForGuard + "minutes";
                    }
            }
            return "Unknow Status!";
        }

        public string PowerOff()
        {
            moduleStatus = Status.PowerOff;
            string status = GetStatus();
            return status;
        }

        public string PowerUp()
        {
            moduleStatus = Status.PowerOn;
            string status = GetStatus();
            return status;
        }

        public string SetAlarm()
        {
            moduleStatus = Status.PowerOnAndSetOnGuard;
            string status = GetStatus();
            return status;
        }

        public string SetAlarm(int time)
        {
            moduleStatus = Status.PowerOnAndSetOnTemporatyGuard;
            timeForGuard = new TimeSpan(0, time, 0);
            SetTimer(timeForGuard);

            string status = GetStatus();
            return status;
        }

        private string SetTimer(TimeSpan TimeForGuard)
        {
            bool result = false;
            Timer time = new Timer(CreateTimer => { Task.Factory.StartNew(() => CheckTimeTask(TimeForGuard, out result)); }, null, 0, CheckDelay);
            if (result)
            {
                string status = GetStatus();
                return status;
            }
            else
            {
                string status = GetStatus();
                return status;
            }
        }

        private void CheckTimeTask(TimeSpan TimeForGuard, out bool result)
        {
            DateTime now = DateTime.Now;
            now.AddMinutes(TimeForGuard.Minutes);
            if (now == DateTime.Now)
            {
                moduleStatus = Status.PowerOnAndGuardReset;
                result = true;
            }
            else
            {
                result = false;
            }
            //var res = TimeForGuard + DateTime.Now;
        }

        public override string ToString()
        {
            return moduleName;
        }
        //public bool SetModuleName()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
