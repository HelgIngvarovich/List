using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Logic.Interfaces
{
    public interface IModule
    {
        string PowerUp();
        string PowerOff();
        string GetStatus();
        //bool SetModuleName();
    }
}