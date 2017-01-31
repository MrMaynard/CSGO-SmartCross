using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSGO_SmartCross
{
    //Reads a config file. The format of the input file is:

    //END
    //AK-47
    //timestamp,x1,y1,1
    //timestamp,x2,y2,2
    //...
    //timestamp,x30,y30,30
    //timestampSettled,x0,y0,0
    //END
    //M4A1-S
    //timestamp,x1,y1
    //timestamp,x2,y2
    //...
    //timestamp,x20,y20
    //timestampSettled,x0,y0,0
    //END


    class Reader
    {
        public static GunTable readFile(string file, Point screenSize)
        {
            IEnumerable<String> lines = null;
            GunTable table = new GunTable();
            try
            {
                lines = File.ReadLines(file);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Couldn't find recoil file:\t" + file);
            }
            bool firstTimeEver = true;
            bool endFlag = false;
            bool firstNumberFlag = false;
            PositionTable pTable = null;
            VectorTable vTable = null;
            string name = null;
            int lastShot = Int32.MaxValue;
            ulong tempTime = 0;
            foreach (var line in lines)
            {
                if (line == "END")//if end found, prepare to read in a gun name
                {
                    if (!firstTimeEver)//if not the first time, place list in gun table
                    {
                        pTable.Reverse();
                        table[name].positionTable = pTable.Clone();

                        vTable.Reverse();
                        table[name].vectorTable = vTable.Clone();

                    }
                    else//if this is the first time, ignore this step
                    {
                        firstTimeEver = false;
                    }

                    endFlag = true;//prep to read a gun
                }
                else if (endFlag)//if end was just read, make a new list and title it after a gun
                {
                    name = line;
                    table[name] = new ShotTable(name);
                    pTable = new PositionTable();
                    vTable = new VectorTable();

                    endFlag = false;
                    lastShot = Int32.MaxValue;
                    firstNumberFlag = true;
                }
                else//otherwise just read data in to the current table
                {
                    
                    string[] words = line.Split(',');
                    int shotNumber = Convert.ToInt32(words[3]);
                    if (firstNumberFlag)
                    {
                        table[name].maxAmmo = shotNumber;
                        
                        firstNumberFlag = false;
                    }
                    if (shotNumber < lastShot)//maxAmmo - 0, put in the table
                    {

                        Vector newVector = new Vector(
                            (float)Convert.ToDouble(words[1]),
                            (float)Convert.ToDouble(words[2]));

                        Point newPoint = new Point(
                            (int)(screenSize.X/2 - (21.3333333 * newVector.x)),
                            (int)(screenSize.Y/2 + (12         * newVector.y)));

                        pTable.Add(newPoint);
                        vTable.Add(newVector);
                        tempTime = (ulong)Convert.ToInt64(words[0]);
                        lastShot = shotNumber;
                    }
                    else//otherwise just use this for the settling time
                    {
                        //Console.WriteLine("Ignoring entry to gun:\t" + pTable.name + " for shotsFired " + Convert.ToInt32(words[3]));
                        table[name].settlingTime = (ulong)Convert.ToInt64(words[0]) - tempTime;
                    }
                    
                }

            }

            return table;
        }

    }
}
