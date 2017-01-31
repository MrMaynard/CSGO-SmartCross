using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.OCR;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace CSGO_SmartCross
{
    class HudModel
    {

        public HashSet<int> colorSet = new HashSet<int>();
        public ColorDecider decider = null;

        public HudModel(Bitmap image, ColorDecider decider)
        {
            this.decider = decider;
            buildSetFromImage(image);
        }

        public UMat buildText(Bitmap bmp)
        {
            Image<Gray, Byte>[] channels = new Image<Bgr, Byte>(bmp).Split();
            return (
                channels[0].InRange(new Gray(0), new Gray(decider.b_min))
                .Or(
                channels[1].InRange(new Gray(0), new Gray(decider.g_min)))
                .Or(
                channels[2].InRange(new Gray(0), new Gray(decider.r_min)))).ToUMat();
        }

        public void buildSetFromImage(Bitmap image)
        {
            colorSet.Clear();
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color temp = image.GetPixel(x, y);
                    if(decider.decide(temp)){
                        colorSet.Add(temp.ToArgb());
                    }
                }
            }
        }

        public bool isHud(Color c)
        {
            return decider.decide(c);
            //return colorSet.Contains(c.ToArgb());
        }
    }
}
