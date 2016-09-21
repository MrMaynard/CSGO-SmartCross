using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace CSGO_SmartCross
{
    //this class hooks inputs and forwards data to other classes
    class Hooker
    {

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        
        public Keys triggerKey;
        public Keys rcsKey;
        public Keys primaryKey;
        public Keys secondaryKey;

        //if bhoptoggle is false, bhopkey directly controls hopping
        //otherwise bhopKey toggles space to bhopping
        public Keys bHopKey;
        public Keys jumpKey = Keys.Space;//todo fix hardcode?


        //rapidKey can disable/enable rapidfire which is hard-coded to mouse button 1
        //in toggle mode hitting depressed can also stop rapidfire if it's already on
        //in hold mode you directly control shooting with rapidkey
        public Keys rapidKey;
        public Keys mouseKey = Keys.LButton;//todo fix hardcode?



        public Shooter shooter;
        public RcsManager rcsMan;
        public Processor processor;
        public Hopper hopper;

        public bool bHopToggle = false;
        public bool rcsToggle = true;
        public bool triggerToggle = false;
        public bool rapidToggle = false;
        private bool rapidMode = false;
        private bool bHopMode = false;
        

        public int delay = 10;

        public Hooker(Shooter shooter, RcsManager rcsMan, Processor processor, Hopper hopper, Keys triggerKey, Keys rcsKey, Keys primaryKey, Keys secondaryKey, Keys rapidKey)
        {
            this.triggerKey = triggerKey;
            this.rcsKey = rcsKey;
            this.shooter = shooter;
            this.rcsMan = rcsMan;
            this.processor = processor;
            this.hopper = hopper;
            this.primaryKey = primaryKey;
            this.secondaryKey = secondaryKey;
            this.rapidKey = rapidKey;
        }

        public bool running = false;

        private bool isKeyDown(Keys key)
        {
            return Convert.ToInt32(GetAsyncKeyState(key)) == -32767;
        }

        public void start()
        {
            running = true;
            bool triggerWasPressed = false;
            bool rcsWasPressed = false;
            bool rapidWasPressed = false;
            bool mouseWasPressed = false;
            bool bHopWasPressed = false;
            bool jumpWasPressed = false;
            while (running)
            {
                if (triggerToggle)//if toggle mode, follow this procedure:
                {
                    bool pressed = isKeyDown(triggerKey);
                    if (pressed & !triggerWasPressed)
                    {
                        triggerWasPressed = true;//note that the key was pressed
                    }
                    else if (pressed & triggerWasPressed)
                    {
                        //do nothing until the key is released
                    }
                    else if (!pressed & triggerWasPressed)
                    {
                        shooter.enabled = !shooter.enabled;//toggle on release
                        triggerWasPressed = false;
                    }
                    else
                    {
                        triggerWasPressed = false;//just note it wasn't pressed in this case
                    }
                }
                else
                {
                    shooter.enabled = isKeyDown(triggerKey);//things are simpler in hold mode.
                }

                if (rcsToggle)//if toggle mode, follow this procedure:
                {
                    bool pressed = isKeyDown(rcsKey);
                    if (pressed & !rcsWasPressed)
                    {
                        rcsWasPressed = true;//note that the key was pressed
                    }
                    else if (pressed & rcsWasPressed)
                    {
                        //do nothing until the key is released
                    }
                    else if (!pressed & rcsWasPressed)
                    {
                        rcsMan.enabled = !rcsMan.enabled;//toggle on release
                        rcsWasPressed = false;
                    }
                    else
                    {
                        rcsWasPressed = false;//just note it wasn't pressed in this case
                    }
                }
                else
                {
                    rcsMan.enabled = isKeyDown(rcsKey);
                }

                if (rapidToggle)//if toggle mode, follow this procedure:
                {
                    bool pressed = isKeyDown(rapidKey);
                    if (pressed & !rapidWasPressed)
                    {
                        rapidWasPressed = true;//note that the key was pressed
                    }
                    else if (pressed & rapidWasPressed)
                    {
                        //do nothing until the key is released
                    }
                    else if (!pressed & rapidWasPressed)
                    {
                        if (rapidMode)
                            shooter.rapid = false;
                        rapidMode = !rapidMode;//toggle on release
                        rapidWasPressed = false;
                    }
                    else
                    {
                        rapidWasPressed = false;//just note it wasn't pressed in this case
                    }
                }
                else
                {
                    shooter.rapid = isKeyDown(rapidKey);//things are simpler in hold mode.
                }

                //toggle based of of mouse button
                if (rapidMode)
                {
                    
                    bool pressed = isKeyDown(mouseKey);
                    if (pressed & !mouseWasPressed)
                    {
                        mouseWasPressed = true;//note that the key was pressed
                    }
                    else if (pressed & mouseWasPressed)
                    {
                        //do nothing until the key is released
                    }
                    else if (!pressed & mouseWasPressed)
                    {
                        shooter.rapid = !shooter.rapid;//toggle on release
                        mouseWasPressed = false;
                    }
                    else
                    {
                        mouseWasPressed = false;//just note it wasn't pressed in this case
                    }
                }

                //set up bhop toggle control or directly drive with bhopbutton in hold mode
                if (bHopToggle)
                {
                    bool pressed = isKeyDown(bHopKey);
                    if (pressed & !bHopWasPressed)
                    {
                        bHopWasPressed = true;//note that the key was pressed
                    }
                    else if (pressed & bHopWasPressed)
                    {
                        //do nothing until the key is released
                    }
                    else if (!pressed & bHopWasPressed)
                    {
                        if (bHopMode)
                            hopper.enabled = false;
                        bHopMode = !bHopMode;//toggle on release
                        bHopWasPressed = false;
                    }
                }
                else
                {
                    hopper.enabled = isKeyDown(bHopKey);
                }

                //toggle based of of mouse button
                if (bHopMode)
                {

                    bool pressed = isKeyDown(jumpKey);
                    if (pressed & !jumpWasPressed)
                    {
                        jumpWasPressed = true;//note that the key was pressed
                    }
                    else if (pressed & jumpWasPressed)
                    {
                        //do nothing until the key is released
                    }
                    else if (!pressed & jumpWasPressed)
                    {
                        hopper.enabled = !hopper.enabled;//toggle on release
                        jumpWasPressed = false;
                    }
                    else
                    {
                        jumpWasPressed = false;//just note it wasn't pressed in this case
                    }
                }
                
                if (isKeyDown(primaryKey))
                    processor.primary = true;
                else if (isKeyDown(secondaryKey))
                    processor.primary = false;

                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}
