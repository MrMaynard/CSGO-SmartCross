using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_SmartCross
{
    class TestImage
    {
        public Bitmap bitmap;
        private int solution;
        public TestImage(Bitmap bitmap, int solution)
        {
            this.solution = solution;
            this.bitmap = bitmap;
        }

        public bool eval(int attempt)
        {
            return attempt == solution;
        }
    }
}
