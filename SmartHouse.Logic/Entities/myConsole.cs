using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Logic.Interfaces;

namespace SmartHouse.Logic.Entities
{
    public class myConsole : IConsole
    {
        List<object> SmartHouseModules = new List<object>()
        {
            new TelevisionModule(),
            new AlarmModule(),
            new JalousieModule(),
            new LigthModule(),
            new MicroclimatModule()
        };

        public void AddNewModule()
        {
            Console.WriteLine("Add new module");
            Console.WriteLine("Enter module name: ");
            string moduleName = Console.ReadLine();
            Console.WriteLine("Select Module type: ");
            Console.WriteLine("1. Alarm");
            Console.WriteLine("2. Jalousie");
            Console.WriteLine("3. Ligth");
            Console.WriteLine("4. Microclimat");
            Console.WriteLine("5. Television");
            string typeModule = Console.ReadLine();
            switch (typeModule)
            {
                case "1":
                    {
                        AlarmModule alr = new AlarmModule(moduleName);
                        object obj = alr;
                        SmartHouseModules.Add(obj);
                        break;
                    }
                case "2":
                    {
                        JalousieModule jal = new JalousieModule(moduleName);
                        object obj = jal;
                        SmartHouseModules.Add(obj);
                        break;
                    }
                case "3":
                    {
                        LigthModule ligth = new LigthModule(moduleName);
                        object obj = ligth;
                        SmartHouseModules.Add(obj);
                        break;
                    }
                case "4":
                    {
                        MicroclimatModule micr = new MicroclimatModule(moduleName);
                        object obj = micr;
                        SmartHouseModules.Add(obj);
                        break;
                    }
                case "5":
                    {
                        TelevisionModule tel = new TelevisionModule(moduleName);
                        object obj = tel;
                        SmartHouseModules.Add(obj);
                        break;
                    }
            }
        }

        public void RemoveModule()
        {
            Console.WriteLine("All modules: ");
            foreach (object obj in SmartHouseModules)
            {
                Console.WriteLine(obj.ToString());
            }
            Console.WriteLine("Select module:");
            string moduleName = Console.ReadLine();
            
            var module = SmartHouseModules.Find(x => x.ToString() == moduleName);
            bool res = SmartHouseModules.Remove(module);
            Console.WriteLine(res);
        }

        public void Menu()
        {
            int choise = 0;
            while (choise != 4)
            {
                Console.WriteLine("1. Add new module");
                Console.WriteLine("2. Remove Module");
                Console.WriteLine("3. Module List");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            AddNewModule();
                            break;
                        }
                    case 2:
                        {
                            RemoveModule();
                            break;
                        }
                    case 3:
                        {
                            WorkWithModules();
                            break;
                        }
                }
            }
        }

        public void WorkWithModules()
        {
            foreach (object tel in SmartHouseModules)
            {
                Console.WriteLine(tel.ToString());
            }

            Console.WriteLine("Select module");
            string moduleName = Console.ReadLine();
            var module = SmartHouseModules.Find(x => x.ToString() == moduleName);
            //AlarmModule alr = null;
            switch (moduleName)
            {
                case "Alarm":
                    {
                        AlarmModule alr = (AlarmModule)module;
                        Console.WriteLine("Alarm Module Settings");
                        Console.WriteLine("1. Power On");
                        Console.WriteLine("2. Power Off");
                        Console.WriteLine("3. Set Alarm");
                        Console.WriteLine("4. Set Alarm with time");
                        string choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "1":
                                {
                                    string res = alr.PowerUp();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "2":
                                {
                                    string res = alr.PowerOff();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "3":
                                {
                                    string res = alr.SetAlarm();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "4":
                                {
                                    Console.WriteLine("Enter time for guard: ");
                                    int time = int.Parse(Console.ReadLine());
                                    string res = alr.SetAlarm(time);
                                    Console.WriteLine(res);
                                    break;
                                }
                        }
                        //object obj = alr;
                        //int index = SmartHouseModules.FindIndex(x => x.ToString() == moduleName);
                        //SmartHouseModules.Insert(index, obj);
                        break;
                    }
                case "Jalousie":
                    {
                        JalousieModule jal = (JalousieModule)module;
                        Console.WriteLine("Jalousie Module Settings");
                        Console.WriteLine("1. Power On");
                        Console.WriteLine("2. Power Off");
                        Console.WriteLine("3. Set Jalousie position");
                        string choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "1":
                                {
                                    string res = jal.PowerUp();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "2":
                                {
                                    string res = jal.PowerOff();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "3":
                                {
                                    Console.WriteLine("Enter Jalousie position. 1. Open, 2. HalfOpen, 3. Close");
                                    int pos = int.Parse(Console.ReadLine());
                                    string res = jal.SetJalousiePosition(pos);
                                    Console.WriteLine(res);
                                    break;
                                }
                        }
                        break;
                    }
                case "Ligth":
                    {
                        LigthModule lig = (LigthModule)module;
                        Console.WriteLine("Ligth Module Settings");
                        Console.WriteLine("1. Power On");
                        Console.WriteLine("2. Power Off");
                        string choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "1":
                                {
                                    string res = lig.PowerUp();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "2":
                                {
                                    string res = lig.PowerOff();
                                    Console.WriteLine(res);
                                    break;
                                }
                        }
                        break;
                    }
                case "Microclimat":
                    {
                        MicroclimatModule micr = (MicroclimatModule)module;
                        Console.WriteLine("Microclimat Module Settings");
                        Console.WriteLine("1. Power On");
                        Console.WriteLine("2. Power Off");
                        Console.WriteLine("3. Set Temperature");
                        string choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "1":
                                {
                                    string res = micr.PowerUp();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "2":
                                {
                                    string res = micr.PowerOff();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "3":
                                {
                                    Console.WriteLine("Enter temperature");
                                    int pos = int.Parse(Console.ReadLine());
                                    string res = micr.SetTemperature(pos);
                                    Console.WriteLine(res);
                                    break;
                                }
                        }
                        break;
                    }
                case "Television":
                    {
                        TelevisionModule tel = (TelevisionModule)module;
                        Console.WriteLine("Alarm Module Settings");
                        Console.WriteLine("1. Power On");
                        Console.WriteLine("2. Power Off");
                        Console.WriteLine("3. Switching Channels");
                        Console.WriteLine("4. Volume Up");
                        Console.WriteLine("5. Volume Down");
                        string choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "1":
                                {
                                    string res = tel.PowerUp();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "2":
                                {
                                    string res = tel.PowerOff();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "3":
                                {
                                    Console.WriteLine("Enter channel");
                                    int chanel = int.Parse(Console.ReadLine());
                                    string res = tel.SwitchingChannels(chanel);
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "4":
                                {
                                    string res = tel.VolumeUp();
                                    Console.WriteLine(res);
                                    break;
                                }
                            case "5":
                                {
                                    string res = tel.VolumeDown();
                                    Console.WriteLine(res);
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        //foreach (object obj in SmartHouseModules)
        //{
        //    Type type = obj.GetType();
        //    if (type.ToString() == moduleName)
        //    {

        //    }
        //    var module = obj as type;
        //}
    }
}

