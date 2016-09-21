using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_SmartCross
{
    class Vector
    {
        //pretty complex stuff.
        public float x = 0;
        public float y = 0;

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector()
        {

        }

        public void reset()
        {
            x = 0;
            y = 0;
        }
    }
}
