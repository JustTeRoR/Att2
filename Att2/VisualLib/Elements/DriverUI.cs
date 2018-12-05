using ClassLib.Task4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using ClassLib.Task4;

namespace VisualLib.Elements
{
    public class DriverUI : ElementUI<TrolleybusDriver>
    {
        Size s = new Size(30, 30);
        Image icon = Image.FromFile(@"C:\2 курс\ЯиСП\2 аттестация\Att2\04.21\Resources\driver.png");
        
        public DriverUI(SynchronizationContext context) : base(context)
        {
            LogicObj = new TrolleybusDriver();
            VisualElement = new Bitmap(icon,s);
        }

        public void ConnectRods(Trolleybus sender)
        {
            new Task(() =>
            {
                LogicObj.DoWork(sender);
            }).Start();
           
        }
    }
}
