using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisualLib.Elements;

namespace VisualLib
{
    public class VisualElementsFactory
    {
        public SynchronizationContext Context { get; set; }
        public VisualElementsFactory(SynchronizationContext context)
        {
            Context = context;
        }

        public TrolleybusUI CreateTrolleybusUI(int n)
        {
            return new TrolleybusUI(n, new DriverUI(Context), Context);
        }     
        
        public MechanicUI CreateMechanicUI(int n)
        {
            return new MechanicUI(Context);
        }

    }


}

