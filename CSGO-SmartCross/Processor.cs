using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_SmartCross
{
    class Processor
    {
        public GunTable table;
        public Painter painter;
        public Crosshair crosshair;//crosshair should usually start in the middle of the screen
        public Vector vector;
        public RcsManager rcsMan;

        string gun;
        public bool primary = true;
        public string primaryGun;
        public string secondaryGun;
        int stableAmmo = -1;
        public int previousAmmo = -1;
        long unstableTime = -1;
        long currentTime = -1;
        public int delay = 10;

        public Processor()
        {

        }

        public Processor(GunTable table, Painter painter, string gun)
        {
            this.table = table;
            this.painter = painter;
            this.gun = gun;
            crosshair = new Crosshair();
            vector = new Vector();
        }

        public Processor(GunTable table, Painter painter, RcsManager rcsMan, string primaryGun, string secondaryGun, Crosshair crosshair)
        {
            this.table = table;
            this.painter = painter;
            this.primaryGun = primaryGun;
            this.secondaryGun = secondaryGun;
            this.crosshair = crosshair;
            this.rcsMan = rcsMan;
            vector = new Vector();
        }

        public void setGun(string gun)
        {
            //Console.Write("now using gun" + gun);
            this.gun = gun;
        }

        public int getMaxAmmo()
        {
            try
            {
                return table[gun].maxAmmo;
            }
            catch
            {
                return 99;
            }
        }

        private void setGun()
        {
            this.gun = (primary) ? primaryGun : secondaryGun;
            
        }

        private void updateTime()
        {
            currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public bool badRead(int ammo)
        {
            return (ammo > previousAmmo) && ammo != table[gun].maxAmmo;
        }

        //based on input ammo and time (ms long) decides what crosshair to send to the painter
        public void process(int ammo, long ms)
        {
            setGun();
            updateTime();
            if (ammo > previousAmmo)//reload condition (or gun swap :/ )
            {
                if (badRead(ammo)) return;
                stableAmmo = ammo;
                crosshair.reset();//stabilize crosshair and set current stableAmmo to current ammo
                vector.reset();
            }
            else if(ammo == previousAmmo && !crosshair.isStable())//if ammo hasn't changed and crosshair isn't stable
            {
                //check for true settling:
                if ((ulong)(currentTime - unstableTime) >= table[gun].settlingTime)//check for settling state
                {
                    crosshair.reset();
                    vector.reset();
                    stableAmmo = ammo;
                }
                else
                {
                    //move incrementally towards 0  based on current time elapsed.
                    Point recoilPos = (table[gun]).positionTable[table[gun].maxAmmo - (stableAmmo - ammo)];
                    Point displacement = new Point(crosshair.initialPosition.X - recoilPos.X, crosshair.initialPosition.Y - recoilPos.Y);
                    double scalingFactor = (double)(currentTime - unstableTime) / (double)table[gun].settlingTime;
                    crosshair.position.X += (int)(displacement.X * scalingFactor * .11);//todo fix magic number. related to various delays though.
                    crosshair.position.Y += (int)(displacement.Y * scalingFactor * .11);
                }
            }
            else if (ammo < previousAmmo)//they have lost ammo, this is where the magic happens
            {
                //Console.WriteLine("Shots fired.");
                if (table.ContainsKey(gun))
                {
                    if (table[gun].positionTable.Count > table[gun].maxAmmo - (stableAmmo - ammo) && table[gun].maxAmmo - (stableAmmo - ammo) >= 0)
                    {
                        crosshair.position = (table[gun]).positionTable[table[gun].maxAmmo - (stableAmmo - ammo)];
                        vector = (table[gun]).vectorTable[table[gun].maxAmmo - (stableAmmo - ammo)];
                        unstableTime = currentTime;  
                    }
                }   
            }
            previousAmmo = ammo;
            painter.update(crosshair);
            rcsMan.update(vector);
            System.Threading.Thread.Sleep(delay);

        }

    }
}
