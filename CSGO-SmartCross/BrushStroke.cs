using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCross
{
    class BrushStroke
    {
        public Rectangle rectangle;
        public Color color;

        public BrushStroke()
        {

        }

        public BrushStroke(Rectangle rectangle, Color color)
        {
            this.rectangle = rectangle;
            this.color = color;
        }

        public Rectangle rectangleWithOffset(int x, int y)
        {
            return new Rectangle(rectangle.X + x, rectangle.Y + y, rectangle.Width, rectangle.Height);
        }
    }
}
