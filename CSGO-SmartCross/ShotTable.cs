using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCross
{
    class ShotTable
    {

        public PositionTable positionTable;
        public VectorTable vectorTable;

        public string name;
        public int maxAmmo;
        public ulong settlingTime;

        public ShotTable()
        {

        }

        public ShotTable(string name)
        {
            this.name = name;
        }

        public ShotTable(PositionTable positionTable, VectorTable vectorTable)
        {
            this.positionTable = positionTable;
            this.vectorTable = vectorTable;
        }
    }
}
