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
    public class MechanicUI : ElementUI<Mechanic>
    {
        Size s = new Size(30, 30);
        Image icon = Image.FromFile(@"C:\2 курс\ЯиСП\2 аттестация\Att2\04.21\Resources\mechanic.png");

        public MechanicUI(SynchronizationContext context) : base(context)
        {
            LogicObj = new Mechanic();
            VisualElement = new Bitmap(icon, s);
        }

        public void DoWork(Trolleybus target)
        {
            LogicObj.X = target.X + 30;
            LogicObj.Y = target.Y;
            LogicObj.DoWork(target);
        }

        
    }
}
