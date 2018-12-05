using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using VisualLib;
using VisualLib.Elements;
using System.Threading.Tasks.Dataflow;
using ClassLib.Task4;
using System.Drawing;

namespace _04._21
{
    public partial class MainWindow : Form
    {
        
        List<TrolleybusUI> trolleybusList = new List<TrolleybusUI>();
        List<MechanicUI> mechList = new List<MechanicUI>();
        Graphics g;
        Bitmap bitmap;
        BufferBlock<MechanicUI> mechanics = new BufferBlock<MechanicUI>();

        private VisualElementsFactory _uiFactory = new VisualElementsFactory(SynchronizationContext.Current);
        public Bitmap GetBitmap()
        {
            bitmap?.Dispose();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            foreach (var item in trolleybusList)
            {
                DrawTrolley(item);
            }
            foreach (var item in mechList)
            {
                DrawMech(item);
            }
            return bitmap;
        }
        public MainWindow()
        {
            InitializeComponent();
            Thread fixFactoryThread = new Thread(FixFactory);
            fixFactoryThread.Start();
        }
        
        private void Tr_Broken(Trolleybus sender)
        {
            ThreadPool.QueueUserWorkItem(FixFactory, sender);
        }
        private void Tr_Dead(Trolleybus sender)
        {
            var ui = trolleybusList.Find(x => x.LogicObj.Equals(sender));
            if (ui != null)
            {
                trolleybusList.Remove(ui);

            }

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            g = pictureBox.CreateGraphics();
            updateTimer.Start();
        }

        

        private async void FixFactory(object o)
        {
            while (true)
            {
                if (trolleybusList.Count == 0)
                    return;

                if (mechanics.Count > 0)
                {
                    var st = o as Trolleybus;
                    var trolley = trolleybusList.Find(x => x.LogicObj.Equals(st));

                    var m = await mechanics.ReceiveAsync();

                    if (m != null && trolley != null)
                    {
                       
                        Thread.Sleep(1500);
                        if (trolleybusList.Contains(trolley))
                        {
                            m.DoWork(trolley.LogicObj);
                        }
                        
                        
                    }
                    mechanics.Post(m);
                    return;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private void trolleyadd_btn_Click(object sender, EventArgs e)
        {
            var trolleyBus = _uiFactory.CreateTrolleybusUI(trolleybusList.Count);
            trolleyBus.LogicObj.Broken += Tr_Broken;
            trolleyBus.LogicObj.Dead += Tr_Dead;
            trolleyBus.Start();
            trolleybusList.Add(trolleyBus);
        }

        private void mecAdd_btn_Click(object sender, EventArgs e)
        {
            MechanicUI mec = new MechanicUI(SynchronizationContext.Current);
            mechList.Add(mec);
            mechanics.Post(mec);
            g.DrawImage(mec.VisualElement, 50, 50);
        }

        public void DrawMech(MechanicUI mech)
        {
            g.DrawImage(mech.VisualElement, mech.LogicObj.X, mech.LogicObj.Y);
        }
        public void DrawTrolley(TrolleybusUI trolley)
        {
            g.DrawImage(trolley.VisualElement, trolley.LogicObj.X, trolley.LogicObj.Y);
            
            g.DrawImage(trolley.Driver.VisualElement, trolley.LogicObj.X + 35, trolley.LogicObj.Y + 10);
        }
       

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            bitmap?.Dispose();
            bitmap = GetBitmap();
            pictureBox.Image = bitmap;
        }
    }
}
