using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SmartCross
{

    class PositionTable : List<Point>
    {
        
        //example use:
        //this[2] is the position of crosshair with 2 shots fired

        public PositionTable()
        {

        }

        public PositionTable Clone()
        {
            PositionTable myClone = new PositionTable();

            foreach (Point p in this)
            {
                myClone.Add(new Point(p.X, p.Y));
            }

            return myClone;
        }

    }
}
