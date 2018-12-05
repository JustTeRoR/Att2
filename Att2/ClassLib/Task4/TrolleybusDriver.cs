using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib.Task4.Abstract;

namespace ClassLib.Task4
{
    public class TrolleybusDriver : Driver
    {
        
        public TimeSpan TimeToConnectRods { get; private set; } = TimeSpan.FromSeconds(1.5);
        public override void DoWork(Item target)
        {
            X = target.X + 70;
            Y = target.Y + 10;
            if (target is Trolleybus)
            {
                Thread.Sleep(TimeToConnectRods);
                (target as Trolleybus).ConnectRods(TimeToConnectRods);
            }
            
        }
    }
}
