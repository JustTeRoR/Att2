using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib.Task4.Abstract;
using Timer = System.Timers.Timer;

namespace ClassLib.Task4
{
    public class Trolleybus : Item
    {
        
        public int TimeToDistraction { get; set; } = 10;
        public delegate void TrolleybusEventHandler(Trolleybus sender);
        public event TrolleybusEventHandler Broken;
        public event TrolleybusEventHandler RodsDisconnect;
        public event TrolleybusEventHandler Fixed;
        public event TrolleybusEventHandler Dead;
        

        public bool IsWorking { get; set; }
        public bool IsRodsDisconnect { get; set; }
        private readonly double _brokeChance = 0.02;
        private readonly double _rodDisconnectChance = 0.02;
        private readonly Random _rnd = new Random();
        private static object lockObj = new object();
        private Timer _liveTimer;
        public void StartWork()
        {
            IsWorking = true;
            while (IsWorking)
            {
                Y += 2;
                if (_rnd.NextDouble() <= _brokeChance && !IsBroken && !IsRodsDisconnect)
                {
                    IsBroken = true;
                    Broken?.Invoke(this);
                    _liveTimer = new Timer(TimeSpan.FromSeconds(TimeToDistraction).TotalMilliseconds);
                    _liveTimer.Elapsed += (o, e) =>
                    {
                        Dead?.Invoke(this);
                        StopWork();
                        _liveTimer?.Stop();
                    };
                    _liveTimer.Start();
                    return;
                }

                if (_rnd.NextDouble() <= _rodDisconnectChance && !IsRodsDisconnect && !IsBroken)
                {
                    IsBroken = true;
                    RodsDisconnect?.Invoke(this);
                    return;
                }
                Thread.Sleep(200);
            }
            
        }

        public void StopWork()
        {
            IsWorking = false;
        }

        public override void Fix(TimeSpan time)
        {
            lock (lockObj)
            {
                Thread.Sleep(time);
                IsBroken = false;
            }
            _liveTimer.Stop();
            Fixed?.Invoke(this);
        }
        public void ConnectRods(TimeSpan time)
        {
            lock (lockObj)
            {
                Thread.Sleep(time);
                IsRodsDisconnect = false;
            }
            Fixed?.Invoke(this);
        }

    }
}