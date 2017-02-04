using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCross
{
    class VectorTable : List<Vector>
    {
        //already stored in the position table but a little redundancy never hurt anybody
        public string name;

        public VectorTable()
        {

        }

        public VectorTable(string name)
        {
            this.name = name;
        }

        public VectorTable Clone()
        {
            VectorTable myClone = new VectorTable(name);

            foreach (Vector v in this)
            {
                myClone.Add(new Vector(v.x, v.y));
            }

            return myClone;
        }
    }
}
