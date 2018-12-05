using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib.Task4.Abstract;

namespace ClassLib.Task4
{
    public class Mechanic : Worker
    {
        public TimeSpan TimeToFix { get; private set; } = TimeSpan.FromSeconds(3);

        public delegate void MechanicEventHandler(Mechanic sender);
        public event MechanicEventHandler IsFree;

        public static Semaphore Semaphore = new Semaphore(3, 3);
        public static int SemCount { get; private set; } = 3;

        public override void DoWork(Item target)
        {
            FixObject(target);
        }

        private void FixObject(Item obj)
        {
            Semaphore.WaitOne();
            obj.Fix(TimeToFix);
            SemCount = Semaphore.Release();
            IsFree?.Invoke(this);
        }
    }
}
