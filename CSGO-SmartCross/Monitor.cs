using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CSGO_SmartCross
{
    class Monitor
    {

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);


        List<Filter> filters;
        Rectangle area;
        public Processor processor;
        public HudModel model;
        public Color hudColor;
        public int delay = 25;
        volatile bool running;

        int maxAmmo = 30;

        public int height = 1080;
        public int width = 1920;

        //todo: does this change with 'gui scale' or something?
        //default for 1920 x 1080
        public double widthToAmmoScale = 0.88507;
        public double heightToAmmoScale = 0.961111;
        public double widthToBoxWidthScale = 0.03125;
        public double heightToBoxHeightScale = 0.025926;

        public double widthToHpBar = (145.0 / 1920.0);
        public double heightToHpBar = (1060.0 / 1080.0);

        public void update(int maxAmmo)
        {
            this.maxAmmo = maxAmmo;
        }

        public Monitor()
        {
            area = new Rectangle(
                (int)(width * widthToAmmoScale),
                (int)(height * heightToAmmoScale),
                (int)(width * widthToBoxWidthScale),
                (int)(height * heightToBoxHeightScale));
        }

        public Monitor(Rectangle area, Processor processor, List<Filter> filters)
        {
            this.area = area;
            this.processor = processor;
            this.filters = filters;
        }

        public void setDefaultArea()
        {
            area = new Rectangle(
                (int)(width * widthToAmmoScale),
                (int)(height * heightToAmmoScale),
                (int)(width * widthToBoxWidthScale),
                (int)(height * heightToBoxHeightScale));
        }

        public void tune()
        {
            model.buildSetFromImage(captureScreen());
        }

        public void start()
        {
            model = new HudModel(captureScreen(), new ColorDecider(ColorDecider.IS_BRIGHT));
            running = true;
            int ammo = -1;
            while (running)
            {
                System.Threading.Thread.Sleep(delay);
                ammo = readAmmo();
                long ms = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                processor.process(ammo, ms);
            }
        }

        public int readAmmo()
        {

            maxAmmo = processor.getMaxAmmo();

            Bitmap bmpImage = captureScreen();
            Filter bmp = new Filter(bmpImage, model);
            //this.simplify(bmpImage).Save("read in progress.bmp");

            //find the rightmost spot of the two digits captured
            //digitAnchor[0] being the lower value digit
            int[] digitAnchor = {-1, -1};
            int currentDigit = 0;
            bool found = false;
            bool onDigit = false;
            int scanX = bmpImage.Width - 1;
            while (scanX > 0 && currentDigit < 2)
            {
                for (int y = 0; y < bmpImage.Height; y++)
                {
                    if (bmp.valueAt(scanX, y))
                    {
                        found = true;
                    }
                }
                if (!found)
                {//didnt find any white and currently was scanning a digit
                    if (onDigit)
                    {
                        onDigit = false;
                    }

                }
                else
                {//found white and not scanning a digit
                    if (!onDigit)
                    {
                        onDigit = true;
                        digitAnchor[currentDigit++] = scanX;
                    }
                }
                scanX--;
                found = false;
            }

            //more significant digit:
            int result = 0;
            for (int i = 1; i >= 0; i--)
            {
                int match = 0;
                int max = Int32.MinValue;
                int digit = -1;
                if (digitAnchor[i] != -1)
                {
                    for (int number = i; number < 10; number++)//start number at i to exclude 0 from the search space
                    {

                        //reduce search space:
                        if (i == 1)
                            if (number > (maxAmmo / 10))
                                break;


                        match = 0;
                        for (int x = filters[number].width - 1; x >= 0; x--)
                        {
                            for (int y = 0; y < filters[number].height; y++)
                            {
                                if (filters[number].valueAt(x, y))
                                {//inc match if image matches filter, else dec match
                                    if (bmp.valueAt(digitAnchor[i] - (filters[number].width - x), y))
                                        match += 3;
                                    else
                                        match -= 1;
                                }
                                else
                                {
                                    if (bmp.valueAt(digitAnchor[i] - (filters[number].width - x), y))
                                        match -= 3;
                                    else
                                        match += 3;
                                }
                            }
                        }
                        if (match > max)
                        {
                            max = match;
                            digit = number;
                        }
                    }
                    result += (digit * (int)Math.Pow(10, i));
                }
                
            }
            
            return result;//todo read remaining ammo?
        }

        public Bitmap captureScreen()
        {
            return CaptureScreen.GetDesktopImage();
        }

        //should be run once to find the right color to filter by:
        public void findHudColor(Bitmap bmp)
        {
            Dictionary<Color, int> resultTable = new Dictionary<Color, int>();
            for (int x = 0; x < bmp.Width; x++){
                for (int y = 0; y < bmp.Height; y++){
                    Color temp = bmp.GetPixel(x, y);
                    if(resultTable.ContainsKey(temp))
                        resultTable[temp]++;
                    else
                        resultTable[temp] = 0;
                }
            }

            int max = Int32.MinValue;
            Color hudColor = Color.White;
            foreach (KeyValuePair<Color, int> entry in resultTable)
            {
                if (entry.Value > max)
                {
                    hudColor = entry.Key;
                    max = entry.Value;
                }
            }

            this.hudColor = hudColor;
        }

        private double differenceBetween(Color a, Color b)
        {
            return Math.Sqrt(
                Math.Pow((double)(a.R - b.R), 2) +
                Math.Pow((double)(a.G - b.G), 2) +
                Math.Pow((double)(a.B - b.B), 2)
                );
        }

        private double colorRatio(Color c)
        {
            return c.R / c.G + c.R / c.B;
        }

        //used to identify HUD in the default color scheme.
        //todo: update to work with the determined hudcolor
        private bool isBright(Color a)
        {
            return (a.R > 170) && (a.G > 170) && (a.B > 170);
        }

        public Bitmap simplify(Bitmap bmp)
        {

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    //Console.WriteLine(differenceBetween(bmp.GetPixel(x, y), hudColor));
                    if (model.isHud(bmp.GetPixel(x,y)))
                    {
                        bmp.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, Color.Black);
                    }
                }
            }
            return bmp;
        }

        public Color GetColorAt(int x, int y)
        {
            IntPtr desk = GetDesktopWindow();
            IntPtr dc = GetWindowDC(desk);
            int a = (int)GetPixel(dc, x, y);
            ReleaseDC(desk, dc);
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }

    }
}
