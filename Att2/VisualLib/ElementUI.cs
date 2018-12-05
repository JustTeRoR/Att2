using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace VisualLib
{
    public class ElementUI<T>
    {
        public T LogicObj { get; set; }
        public SynchronizationContext Context { get; set; }
        public Bitmap VisualElement { get; set; }

        
        public ElementUI(SynchronizationContext context)
        {
            Context = context;
        }


    }
}
