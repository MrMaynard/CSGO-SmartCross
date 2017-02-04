using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCross
{
    class HsvSettings
    {
        public int hMin = 0;
        public int hMax = 255;
        public int sMin = 0;
        public int sMax = 255;
        public int vMin = 0;
        public int vMax = 255;

        public HsvSettings() { }

        public HsvSettings(int hMin, int hMax, int sMin, int sMax, int vMin, int vMax)
        {
            this.hMin = hMin;
            this.hMax = hMax;
            this.sMin = sMin;
            this.sMax = sMax;
            this.vMin = vMin;
            this.vMax = vMax;
        }

        public HsvSettings clone()
        {
            return new HsvSettings(hMin, hMax, sMin, sMax, vMin, vMax);
        }

    }
}
