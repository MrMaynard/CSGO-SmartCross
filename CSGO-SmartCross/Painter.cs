using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace SmartCross
{
    class Painter
    {

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        Crosshair crosshair;
        bool crosshairMutex = false;
        bool running;
        Graphics g;
        public int delay = 25;
        public bool alwaysShow = false;
        public bool enabled = true;

        public Painter()
        {
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            g = Graphics.FromHdc(desktopPtr);
        }

        public Painter(Crosshair crosshair)
        {
            this.crosshair = crosshair;
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            g = Graphics.FromHdc(desktopPtr);
        }

        public void update(Crosshair crosshair)
        {
            while (crosshairMutex)
                System.Threading.Thread.Sleep(1);
            crosshairMutex = true;
            this.crosshair = crosshair;
            crosshairMutex = false;
        }

        public void start(Crosshair crosshair)
        {
            this.update(crosshair);
            running = true;
            while (running)
            {
                if (!alwaysShow && crosshair.isStable()) continue;
                if (!enabled) continue;
                while (crosshairMutex)
                    System.Threading.Thread.Sleep(1);
                crosshairMutex = true;
                foreach (BrushStroke stroke in this.crosshair.getRepresentation())
                {
                    try
                    {
                        SolidBrush b = new SolidBrush(stroke.color);
                        g.FillRectangle(b, stroke.rectangle);
                    }
                    catch (Exception e)
                    {
                        ;
                    }
                }
                crosshairMutex = false;

                System.Threading.Thread.Sleep(delay);

            }
        }

    }
}
