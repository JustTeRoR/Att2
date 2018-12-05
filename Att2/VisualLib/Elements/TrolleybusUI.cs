using ClassLib.Task4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisualLib.Elements
{
    public class TrolleybusUI : ElementUI<Trolleybus>
    {
        Size s = new Size(80, 80);
        int Delta = 150;
        Image icon = Image.FromFile(@"C:\2 курс\ЯиСП\2 аттестация\Att2\04.21\Resources\trolleybus.png");
        Image iconRodsDisconnect = Image.FromFile(@"C:\2 курс\ЯиСП\2 аттестация\Att2\04.21\Resources\trolleybusRodsDisconnect.png");
        Image iconBroken = Image.FromFile(@"C:\2 курс\ЯиСП\2 аттестация\Att2\04.21\Resources\trolleybusBroken.png");
       
       


        public DriverUI Driver { get; set; }
        public TrolleybusUI(int n, DriverUI driver, SynchronizationContext context) : base(context)
        {
            
            VisualElement = new Bitmap(icon,s);
            LogicObj = new Trolleybus();
            LogicObj.Broken += Trolleybus_Broken;
            LogicObj.Fixed += Trolleybus_Fixed;
            LogicObj.X =Delta * n;
            LogicObj.RodsDisconnect += Trolleybus_RodsDisconnect;
            Driver = driver;
        }

        public void Start()
        {
            VisualElement = new Bitmap(icon, s);
            Thread trolleyThread = new Thread(LogicObj.StartWork);
            trolleyThread.Start();
        }

        public void Stop()
        {
            LogicObj.StopWork();
        }
    
        private void Trolleybus_Fixed(Trolleybus sender)
        {
            VisualElement = new Bitmap(icon, s);
            Start();
        }
        
        private void Trolleybus_RodsDisconnect(Trolleybus sender)
        {
            VisualElement = new Bitmap(iconRodsDisconnect, s);
            Driver.LogicObj.DoWork(sender);           
        }
        private void Trolleybus_Broken(Trolleybus sender)
        {
            VisualElement = new Bitmap(iconBroken, s);
            Stop();
        }
    }
}
