using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_SmartCross
{
    class Crosshair
    {

        public Point initialPosition;
        public Point position = new Point();
        public Image image;
        private bool customImage;

        //returns the default crosshair:
        public List<BrushStroke> getDefault()
        {
            List<BrushStroke> list = new List<BrushStroke>();

            BrushStroke left = new BrushStroke(new Rectangle(position.X + -10, position.Y + -1, 7, 3), Color.Blue);
            BrushStroke right = new BrushStroke(new Rectangle(position.X + 3, position.Y + -1, 7, 3), Color.Blue);

            list.Add(left);
            list.Add(right);

            return list;
        }

        

        public Crosshair()
        {
            customImage = false;
            position = new Point(0, 0);
            initialPosition = new Point(0, 0);
        }

        public Crosshair(int x, int y)
        {
            customImage = false;
            position = new Point(x, y);
            initialPosition = new Point(x, y);
        }

        public void setImage(Image image)
        {
            this.image = image;
            customImage = true;
        }

        public void removeImage()
        {
            customImage = false;
        }

        public Point displacement()
        {
            return new Point(position.X - initialPosition.X, position.Y - initialPosition.Y);
        }

        private bool isWhite(Color c)
        {
            return (c.R == 255) && (c.G == 255) && (c.B == 255);
        }

        private void getStrokeBounds(Bitmap bmp, int x, int y, out int width, out int height, out Color paint)
        {
            paint = bmp.GetPixel(x, y);
            int color = paint.ToArgb();
            width = 1;
            height = 1;
            
            //first get the maximum stroke height:
            for (int i = 1; i < bmp.Height - y; i++)
            {
                if (bmp.GetPixel(x, y + i).ToArgb() == color)
                    height++;
                else
                    break;
            }

            //then expand the stroke as far as you can:
            for (int i = 1; i < bmp.Width - x; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (bmp.GetPixel(x + i, y + j).ToArgb() != color)
                        return;
                }
                width++;
            }
        }

        //returns a representation of the crosshair's image as rectangles.
        //point (-25,-25) is the upper left, point (25, 25) is the bottom right.
        public List<BrushStroke> getRepresentation()
        {
            List<BrushStroke> list;
            
            if (customImage)
            {
                Bitmap bmp = new Bitmap(image);
                list = new List<BrushStroke>();
                BrushStroke temp = new BrushStroke();
                int width, height;
                Color paint;
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Width; y++)
                    {
                        if (isWhite(bmp.GetPixel(x, y))) continue;

                        getStrokeBounds(bmp, x, y, out width, out height, out paint);
                        list.Add(new BrushStroke(new Rectangle(x, y, width, height), paint));
                        for (int i = x; i < width; i++)
                        {
                            for (int j = y; j < height; j++)
                            {
                                bmp.SetPixel(x, y, Color.White);
                            }
                        }

                    }
                }
            }
            else
            {
                list = this.getDefault();
            }

            return list;
        }

        public void offsetBy(int x, int y)
        {
            position.X += x;
            position.Y += y;
        }

        public void offsetBy(Point p)
        {
            position.X += p.X;
            position.Y += p.Y;
        }

        public void reset()
        {
            position.X = initialPosition.X;
            position.Y = initialPosition.Y;
        }

        public bool isStable()
        {
            return position.X == initialPosition.X &&
                   position.Y == initialPosition.Y;
        }
    }
}
