using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Task4.Abstract
{
    public abstract class Item 
    {
        public bool IsBroken { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public abstract void RocketLaunch(TimeSpan timeToFix);
    }
}
