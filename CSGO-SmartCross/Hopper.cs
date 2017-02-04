using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SmartCross
{
    //handles bhopping.
    class Hopper
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,UIntPtr dwExtraInfo);

        public int delay = 16;
        public int downTime = 3;
        Random random;

        public bool running = false;
        public bool enabled = false;

        public Hopper()
        {
            random = new Random();
        }

        public void start()
        {
            running = true;
            while (running)
            {
                System.Threading.Thread.Sleep(delay);
                if (!enabled) continue;
                hop();
            }
        }

        private void hop()
        {
            System.Threading.Thread.Sleep(random.Next(1, 2));
            //          VK,   scan, down,  null 
            keybd_event(0x20, 0x39, 0x0, new UIntPtr());
            //System.Threading.Thread.Sleep(random.Next(downTime / 2, downTime));
            //          VK,   scan, up,     null 
            keybd_event(0x20, 0x39, 0x0002, new UIntPtr());
        }

    }
}
