using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_SmartCross
{
    



    //Class for filtering an image to aid number detection.
    //On 1920x1080 systems this filter is 20x28.
    //We can represent it as a bitmap but this is pretty slow
    //so it's better to use a boolean array
    class Filter
    {

        List<List<bool>> array = new List<List<bool>>();
        public int number;
        public int width;
        public int height;
        //list of lists
        //each sub-list is a row in the filter image
        public Filter(Bitmap filterMap, int number)
        {

            this.width = filterMap.Width;
            this.height = filterMap.Height;


            this.number = number;
            for(int i = 0; i < filterMap.Height; i++)
                array.Add(new List<bool>());

            for(int i = 0; i < filterMap.Height; i++){
                for(int j = 0; j < filterMap.Width; j++){
                    array[i].Add(equal(filterMap.GetPixel(j, i), Color.White));
                }
            }
        }

        //used to identify HUD in the default color scheme.
        //todo: update to work with the determined hudcolor
        private bool isBright(Color a)
        {
            return (a.R > 170) && (a.G > 170) && (a.B > 170);
        }

        //this is where functional programming would be nice
        public Filter(Bitmap filterMap)
        {

            this.width = filterMap.Width;
            this.height = filterMap.Height;

            for (int i = 0; i < filterMap.Height; i++)
                array.Add(new List<bool>());

            for (int i = 0; i < filterMap.Height; i++)
            {
                for (int j = 0; j < filterMap.Width; j++)
                {
                    array[i].Add(isBright(filterMap.GetPixel(j, i)));
                }
            }
        }

        public Filter(Bitmap filterMap, HudModel model)
        {

            this.width = filterMap.Width;
            this.height = filterMap.Height;

            for (int i = 0; i < filterMap.Height; i++)
                array.Add(new List<bool>());

            for (int i = 0; i < filterMap.Height; i++)
            {
                for (int j = 0; j < filterMap.Width; j++)
                {
                    array[i].Add(model.isHud(filterMap.GetPixel(j, i)));
                }
            }
        }

        public bool valueAt(int x, int y)
        {
            return  x <= width  && x >= 0 &&
                    y <= height && y >= 0 &&
                    array[y][x];
        }

        public bool equal(Color a, Color b)
        {
            return a.A == b.A && a.R == b.R && a.G == b.G && a.B == b.B;
        }
    }
}
