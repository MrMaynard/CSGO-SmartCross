using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SmartCross
{
    class Shooter
    {

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);
        [DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        //copy+paste from http://stackoverflow.com/questions/1483928/how-to-read-the-color-of-a-screen-pixel
        public Color GetColorAt(int x, int y)
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }

        //control variables for the triggerbot loop
        public bool enabled = false;
        public bool running = false;
        public bool startup = false;

        //control variable for rapidfire
        public bool rapid = false;

        public int delay = 30;
        public int rapidFireTime = 30;

        private Color[] normalPixels = new Color[4];
        private Random random;

        public int reactionTime = 20;
        Point screenCenter;

        public Shooter(int reactionTime, Point screenCenter)
        {
            random = new Random();
            this.reactionTime = reactionTime;
            this.screenCenter = screenCenter;
        }

        public void start()
        {
            running = true;
            while (running)
            {

                System.Threading.Thread.Sleep(delay);

                if (rapid)
                {
                    System.Threading.Thread.Sleep(random.Next(rapidFireTime / 2, rapidFireTime));
                    shoot();
                    continue;
                }


                if (!enabled)
                {
                    startup = true;
                }
                else
                {
                    //Console.WriteLine("shootin");
                    if (startup)//get the colors to use as reference
                    {
                        startup = false;
                        normalPixels[0] = GetColorAt(screenCenter.X - 1, screenCenter.Y - 1);
                        normalPixels[1] = GetColorAt(screenCenter.X + 1, screenCenter.Y - 1);
                        normalPixels[2] = GetColorAt(screenCenter.X + 1, screenCenter.Y + 1);
                        normalPixels[3] = GetColorAt(screenCenter.X - 1, screenCenter.Y + 1);
                    }
                    else
                    {
                        if (changeDetected(normalPixels)) {
                            System.Threading.Thread.Sleep(random.Next(reactionTime / 2, reactionTime));
                            shoot();
                        }
                        
                    }
                }
            }
        }

        public int sensitivity = 20;
        private bool difference(Color a, Color b)
        {
            return
                Math.Abs(a.R - b.R) > sensitivity ||
                Math.Abs(a.G - b.G) > sensitivity ||
                Math.Abs(a.B - b.B) > sensitivity;

        }

        private bool changeDetected(Color[] normalPixels)
        {
            Color[] newPixels = {
                                    GetColorAt(screenCenter.X - 1, screenCenter.Y - 1),
                                    GetColorAt(screenCenter.X + 1, screenCenter.Y - 1),
                                    GetColorAt(screenCenter.X + 1, screenCenter.Y + 1),
                                    GetColorAt(screenCenter.X - 1, screenCenter.Y + 1)
                                };

            byte count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (difference(normalPixels[i], newPixels[i]))
                {
                    count++;
                }
            }

            return count == 4;
        }


        //copy+paste from http://stackoverflow.com/questions/2416748/how-to-simulate-mouse-click-in-c
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void shoot()
        {
            //Call the imported function with the cursor's current position
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }


    }
}
