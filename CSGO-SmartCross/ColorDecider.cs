using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_SmartCross
{
    class ColorDecider
    {

        //todo maybe add more stuff
        public const int IS_BRIGHT = 0;
        public const int SOMETHING_ELSE = 1;

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
