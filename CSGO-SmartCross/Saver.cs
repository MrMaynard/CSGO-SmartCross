using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_SmartCross
{
    class Saver
    {

        //save settings to a file
        public static void save(String location, Monitor monitor, Hooker hooker, String crosshairFile)
        {
            StringBuilder settings = new StringBuilder();

            //crosshair file
            settings.Append("Crosshair file," + crosshairFile + "\n");

            //keybinds
            settings.Append("Primary key," + hooker.primaryKey + "\n");
            settings.Append("Secondary key," + hooker.secondaryKey + "\n");

            settings.Append("Bhop key," + hooker.bHopKey + "\n");
            settings.Append("Bhop toggle," + hooker.bHopToggle + "\n");

            settings.Append("Rapidfire key," + hooker.rapidKey + "\n");
            settings.Append("Rapidfire toggle," + hooker.rapidToggle + "\n");

            settings.Append("Trigger key," + hooker.triggerKey + "\n");
            settings.Append("Trigger toggle," + hooker.triggerToggle + "\n");

            settings.Append("RCS key," + hooker.rcsKey + "\n");
            settings.Append("RCS toggle," + hooker.rcsToggle + "\n");

            //advanced settings:
            settings.Append("Height," + monitor.height + "\n");
            settings.Append("Width," + monitor.width + "\n");

            settings.Append("Ammo read delay," + monitor.delay + "\n");
            settings.Append("Processor delay," + monitor.processor.delay + "\n");
            settings.Append("Painter delay," + monitor.processor.painter.delay + "\n");
            settings.Append("RCS delay," + monitor.processor.rcsMan.delay + "\n");

            settings.Append("Hooker delay," + hooker.delay + "\n");

            settings.Append("Bhop delay," + hooker.hopper.delay + "\n");
            settings.Append("Bhop downtime," + hooker.hopper.downTime + "\n");
            
            settings.Append("Trigger delay," + hooker.shooter.delay + "\n");
            settings.Append("Trigger reaction time," + hooker.shooter.reactionTime + "\n");
            settings.Append("Trigger rapidfire time," + hooker.shooter.rapidFireTime + "\n");

            settings.Append("Trex delay," + hooker.trex.delay + "\n");
            settings.Append("Trex reaction time," + hooker.trex.reactionTime + "\n");
            settings.Append("Trex rapidfire time," + hooker.trex.rapidFireTime + "\n");
            settings.Append("Trex tracking time," + hooker.trex.trackerDelay + "\n");
            settings.Append("Trex burst shots," + hooker.trex.numShots + "\n");

            File.WriteAllText(location, settings.ToString());
        }

        //load settings from a file
        public static String[] load(String location)
        {
            String[] raw = File.ReadAllLines(location);
            String[] values = new String[raw.Length];

            for(int i = 0; i < raw.Length; i++)
            {
                values[i] = raw[i].Split(',')[1];
            }

            return values;
        }

    }
}
