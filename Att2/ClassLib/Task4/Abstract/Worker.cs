using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Task4.Interfaces;

namespace ClassLib.Task4.Abstract
{
    public abstract class Worker : IEmergencyService
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void DoWork(Item target);
    }
}
