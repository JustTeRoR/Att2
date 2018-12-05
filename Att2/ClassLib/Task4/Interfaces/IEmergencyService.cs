using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Task4.Abstract;

namespace ClassLib.Task4.Interfaces
{
    public interface IEmergencyService
    {
        void DoWork(Item target);
    }
}
