using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
