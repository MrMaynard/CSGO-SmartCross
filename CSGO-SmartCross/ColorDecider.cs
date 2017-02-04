using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCross
{
    class ColorDecider
    {

        //todo maybe add more stuff
        public const int IS_BRIGHT = 0;
        public const int SOMETHING_ELSE = 1;

        public int b_max = 256;
        public int b_min = 170;
        public int g_max = 256;
        public int g_min = 170;
        public int r_max = 256;
        public int r_min = 170;

        public int mode = -1;

        public ColorDecider(int mode)
        {
            this.mode = mode;
        }

        public bool decide(Color c)
        {
            switch (mode)
            {
                case IS_BRIGHT:
                    return isBright(c);
                default:
                    return isBright(c);
            }
        }

        private bool isBright(Color a)
        {
            return (a.R > 170) && (a.G > 170) && (a.B > 170);
        }

    }
}
