using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CSGO_SmartCross
{
    public partial class GUI : Form
    {

        Monitor m = new Monitor();
        List<TestImage> testSet;

        private Dictionary<string, Keys> keyTable = new Dictionary<string, Keys>();

        bool enabled = true;

        Painter painter = null;
        Crosshair cross = null;
        GunTable table = null;
        Shooter shooter = null;
        RcsManager rcsMan = null;
        Hooker hooker = null;
        Processor processor = null;
        Hopper hopper = null;

        Point screenSize = new Point(1920, 1080);

        public GUI()
        {
            InitializeComponent();
            m = null;
            testSet = new List<TestImage>();
            initialize();

            table = Reader.readFile("patterns.txt", screenSize);
            painter = new Painter();
            cross = new Crosshair(screenSize.X / 2, screenSize.Y / 2);
            //cross.setImage(crosshairBox.Image);
            rcsMan = new RcsManager(new Vector(), screenSize);
            processor = new Processor(table, painter, rcsMan, "AK-47", "GLOCK-18", cross);
            hopper = new Hopper();
            m.processor = processor;
            setupTable();
            
            //todo account for screen size using GUI:
            screenSize = new Point(1920, 1080);
            shooter = new Shooter(100, new Point(screenSize.X / 2, screenSize.Y / 2));
            hooker = new Hooker(shooter, rcsMan, processor, hopper, Keys.A, Keys.A, Keys.A, Keys.A, Keys.A);
            
            //load in default keys:
            triggerKeyBox.SelectedIndex = triggerKeyBox.Items.IndexOf("T");
            rcsKeyBox.SelectedIndex = triggerKeyBox.Items.IndexOf(";");
            primaryKeyBox.SelectedIndex = triggerKeyBox.Items.IndexOf("1");
            secondaryKeyBox.SelectedIndex = triggerKeyBox.Items.IndexOf("2");
            rapidKeyBox.SelectedIndex = triggerKeyBox.Items.IndexOf("U");
            bHopKeyBox.SelectedIndex = triggerKeyBox.Items.IndexOf("N");

            //load in default toggle states
            rcsToggleButton.Checked = true;
            triggerHoldButton.Checked = true;
            rapidToggleButton.Checked = true;
            bHopHoldButton.Checked = true;

            //load in crosshair image:
            crosshairBox.Image = Image.FromFile("crosshair.bmp");

            startTasks();
        }
        int numberCaptured = 0;
        private void startButton_Click(object sender, EventArgs e)
        {
            
            //for (int i = 0; i < 5; i++)
            //{
                m.simplify(m.captureScreen()).Save("image " + numberCaptured++ + ".bmp");
                //System.Threading.Thread.Sleep(1000);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void setupTable()
        {
            //standard letters:
            keyTable["A"] = Keys.A;
            keyTable["B"] = Keys.B;
            keyTable["C"] = Keys.C;
            keyTable["D"] = Keys.D;
            keyTable["E"] = Keys.F;
            keyTable["G"] = Keys.H;
            keyTable["I"] = Keys.J;
            keyTable["K"] = Keys.K;
            keyTable["L"] = Keys.L;
            keyTable["M"] = Keys.M;
            keyTable["N"] = Keys.N;
            keyTable["O"] = Keys.O;
            keyTable["P"] = Keys.P;
            keyTable["Q"] = Keys.Q;
            keyTable["R"] = Keys.R;
            keyTable["S"] = Keys.S;
            keyTable["T"] = Keys.T;
            keyTable["U"] = Keys.U;
            keyTable["V"] = Keys.V;
            keyTable["W"] = Keys.W;
            keyTable["X"] = Keys.X;
            keyTable["Y"] = Keys.Y;
            keyTable["Z"] = Keys.Z;

            //numbers:
            keyTable["1"] = Keys.D1;
            keyTable["2"] = Keys.D2;
            keyTable["3"] = Keys.D3;
            keyTable["4"] = Keys.D4;
            keyTable["5"] = Keys.D5;
            keyTable["6"] = Keys.D6;
            keyTable["7"] = Keys.D7;
            keyTable["8"] = Keys.D8;
            keyTable["9"] = Keys.D9;
            keyTable["0"] = Keys.D0;

            //symbols:
            keyTable[";"] = Keys.OemSemicolon;
            keyTable["\\"] = Keys.OemBackslash;
            keyTable[" "] = Keys.Space;
            keyTable["\""] = Keys.OemQuotes;
            keyTable["."] = Keys.OemPeriod;
            keyTable["|"] = Keys.OemPipe;
            keyTable["-"] = Keys.OemMinus;
            keyTable[","] = Keys.Oemcomma;
            keyTable["?"] = Keys.OemQuestion;
            keyTable["+"] = Keys.Oemplus;
            keyTable["["] = Keys.OemOpenBrackets;
            keyTable["]"] = Keys.OemCloseBrackets;

            //mouse buttons:
            keyTable["MB1"] = Keys.LButton;
            keyTable["MB2"] = Keys.RButton;
            keyTable["MB3"] = Keys.MButton;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(m.readAmmo());
        }


        private void initialize()
        {
            List<Filter> filters = new List<Filter>();

            try
            {
                filters.Add(new Filter(new Bitmap("reference 0.bmp"), 0));
                filters.Add(new Filter(new Bitmap("reference 1.bmp"), 1));
                filters.Add(new Filter(new Bitmap("reference 2.bmp"), 2));
                filters.Add(new Filter(new Bitmap("reference 3.bmp"), 3));
                filters.Add(new Filter(new Bitmap("reference 4.bmp"), 4));
                filters.Add(new Filter(new Bitmap("reference 5.bmp"), 5));
                filters.Add(new Filter(new Bitmap("reference 6.bmp"), 6));
                filters.Add(new Filter(new Bitmap("reference 7.bmp"), 7));
                filters.Add(new Filter(new Bitmap("reference 8.bmp"), 8));
                filters.Add(new Filter(new Bitmap("reference 9.bmp"), 9));
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Couldn't load resource files");
            }
            
            m = new Monitor(new Rectangle(), new Processor(), filters);
            m.setDefaultArea();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //testSet.Add(new TestImage(m.captureScreen(), Convert.ToInt32(solutionBox.Text)));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double max = Double.MinValue;
            int bestA = -1;
            int bestB = -1;
            int bestC = -1;
            int bestD = -1;
            int counter = 0;
            
            for (int a = -3; a <= 3; a++)
            {
                for (int b = -3; b <= 3; b++)
                {
                    for (int c = -3; c <= 3; c++)
                    {
                        for (int d = -3; d <= 3; d++)
                        {
                            //label2.Text = Convert.ToString(counter++);
                            double accuracy = 0;
                            double total = 0;
                            foreach(TestImage test in testSet){
                                //if (test.eval(m.readAmmo(test.bitmap, a, b, c, d)))
                                    accuracy += 1;
                                total += 1;
                            }
                            accuracy /= total;
                            if (accuracy >= max)
                            {
                                max = accuracy;
                                bestA = a;
                                bestB = b;
                                bestC = c;
                                bestD = d;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Accuracy of " + max +" for the following:");
            Console.WriteLine(bestA + "\t" + bestB + "\t" + bestC + "\t" + bestD);
        }

        private void startTasks()
        {
            Task.Factory.StartNew(() => painter.start(cross));
            Task.Factory.StartNew(() => m.start());
            Task.Factory.StartNew(() => shooter.start());
            Task.Factory.StartNew(() => hooker.start());
            Task.Factory.StartNew(() => rcsMan.start());
            Task.Factory.StartNew(() => hopper.start());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //startTasks();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cross.position.Y -= 100;
            painter.update(cross);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //table = Reader.readFile("patterns.txt");
            //Console.WriteLine(table["AK-47"].Count);
        }

        

        private void primaryBox_TextChanged(object sender, EventArgs e)
        {
            if (table.ContainsKey(primaryBox.Text.ToUpper()))
            {
                processor.primaryGun = primaryBox.Text.ToUpper();
                primaryBox.BackColor = Color.PaleGreen;
                primaryLabel.Text = processor.primaryGun + " Loaded";
            }
            else
            {
                primaryBox.BackColor = Color.LightCoral;
            }
        }

        private void secondaryBox_TextChanged(object sender, EventArgs e)
        {
            if (table.ContainsKey(secondaryBox.Text.ToUpper()))
            {
                processor.secondaryGun = secondaryBox.Text.ToUpper();
                secondaryBox.BackColor = Color.PaleGreen;
                secondaryLabel.Text = processor.secondaryGun + " Loaded";
            }
            else
            {
                secondaryBox.BackColor = Color.LightCoral;
            }
        }

        private void crosshairButton_Click(object sender, EventArgs e)
        {
            enabled = !enabled;
            painter.enabled = enabled;
            if (enabled)
            {
                alwaysBox.Enabled = true;
                crosshairButton.Text = "Disable Crosshair";
            }
            else
            {
                alwaysBox.Enabled = false;
                crosshairButton.Text = "Enable Crosshair";
            }
        }

        

        private void alwaysBox_CheckedChanged(object sender, EventArgs e)
        {
            painter.alwaysShow = alwaysBox.Checked;
        }

        

        private void triggerKeyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hooker.triggerKey = keyTable[(string)triggerKeyBox.SelectedItem];
        }

        private void rcsKeyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hooker.rcsKey = keyTable[(string)rcsKeyBox.SelectedItem];
        }

        private void primaryKeyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hooker.primaryKey = keyTable[(string)primaryKeyBox.SelectedItem];
        }

        private void secondaryKeyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hooker.secondaryKey = keyTable[(string)secondaryKeyBox.SelectedItem];
        }

        private void primaryLabel_Click(object sender, EventArgs e)
        {

        }

        private void secondaryLabel_Click(object sender, EventArgs e)
        {

        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }


        private void rcsToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            hooker.rcsToggle = rcsToggleButton.Checked;
        }

        private void triggerToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            hooker.triggerToggle = triggerToggleButton.Checked;
        }

        private void hudButton_Click(object sender, EventArgs e)
        {
            m.tune();
        }

        private void rapidToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            hooker.rapidToggle = rapidToggleButton.Checked;
        }

        private void rapidKeyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hooker.rapidKey = keyTable[(string)rapidKeyBox.SelectedItem];
        }

        private void bHopToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            hooker.bHopToggle = bHopToggleButton.Checked;
        }

        private void bHopKeyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hooker.bHopKey = keyTable[(string)bHopKeyBox.SelectedItem];
        }

        private void crosshairBox_Click(object sender, EventArgs e)
        {

        }

        private string crosshairFile = "crosshair.bmp";
        private void crosshairImageButton_Click(object sender, EventArgs e)
        {
            string fileName = "crosshair.bmp";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = dialog.FileName;
                updateCrossHair(fileName);
            }
        }

        public void updateCrossHair(string fileName)
        {
            crosshairFile = fileName;
            Image image = Image.FromFile(fileName);
            if (image.Width == 50 || image.Height == 50)
            {
                crosshairBox.Image = image;
                cross.setImage(image);
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MrMaynard/CSGO-SmartCross/issues");
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AdvancedWindow())
            {
                var response = form.ShowDialog();
                if(response == DialogResult.OK)
                {
                    String[] result = form.results;
                    m.height = Int32.Parse(result[0]);
                    m.width = Int32.Parse(result[1]);

                    m.delay = Int32.Parse(result[2]);
                    m.processor.delay = Int32.Parse(result[3]);
                    m.processor.painter.delay = Int32.Parse(result[4]);
                    m.processor.rcsMan.delay = Int32.Parse(result[5]);

                    hooker.delay = Int32.Parse(result[6]);

                    hooker.hopper.delay = Int32.Parse(result[7]);
                    hooker.hopper.downTime = Int32.Parse(result[8]);

                    hooker.shooter.delay = Int32.Parse(result[9]);
                    hooker.shooter.reactionTime = Int32.Parse(result[10]);
                    hooker.shooter.rapidFireTime = Int32.Parse(result[11]);

                }
            }
        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Saver.save(sfd.FileName, m, hooker, crosshairFile);
            }
        }

        private void loadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    //basic
                    String[] result = Saver.load(ofd.FileName);

                    updateCrossHair(result[0]);
                    primaryKeyBox.SelectedIndex = primaryKeyBox.Items.IndexOf(result[1]);
                    secondaryKeyBox.SelectedIndex = secondaryKeyBox.Items.IndexOf(result[2]);

                    bHopKeyBox.SelectedIndex = bHopKeyBox.Items.IndexOf(result[3]);
                    bHopToggleButton.Checked = Boolean.Parse(result[4]);

                    rapidKeyBox.SelectedIndex = rapidKeyBox.Items.IndexOf(result[5]);
                    rapidToggleButton.Checked = Boolean.Parse(result[6]);

                    triggerKeyBox.SelectedIndex = triggerKeyBox.Items.IndexOf(result[7]);
                    triggerToggleButton.Checked = Boolean.Parse(result[8]);

                    rcsKeyBox.SelectedIndex = rcsKeyBox.Items.IndexOf(result[9]);
                    rcsToggleButton.Checked = Boolean.Parse(result[10]);

                    //advanced
                    m.height = Int32.Parse(result[11]);
                    m.width = Int32.Parse(result[12]);

                    m.delay = Int32.Parse(result[13]);
                    m.processor.delay = Int32.Parse(result[14]);
                    m.processor.painter.delay = Int32.Parse(result[15]);
                    m.processor.rcsMan.delay = Int32.Parse(result[16]);

                    hooker.delay = Int32.Parse(result[17]);

                    hooker.hopper.delay = Int32.Parse(result[18]);
                    hooker.hopper.downTime = Int32.Parse(result[19]);

                    hooker.shooter.delay = Int32.Parse(result[20]);
                    hooker.shooter.reactionTime = Int32.Parse(result[21]);
                    hooker.shooter.rapidFireTime = Int32.Parse(result[22]);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
