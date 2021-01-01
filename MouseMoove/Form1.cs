using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;

namespace MouseMoove
{
    public class NexColor
    {
        private int _n=0;
        private List<Color> colors = new List<Color>{
Color.AliceBlue,Color.AntiqueWhite,Color.Aqua,Color.Aquamarine,Color.Azure,Color.Beige,Color.Bisque,Color.Black,Color.BlanchedAlmond,Color.Blue,Color.BlueViolet,Color.Brown,Color.BurlyWood,Color.CadetBlue,Color.Chartreuse,Color.Chocolate,Color.Coral,Color.CornflowerBlue,Color.Cornsilk,Color.Crimson,Color.Cyan,Color.DarkBlue,Color.DarkCyan,Color.DarkGoldenrod,Color.DarkGray,Color.DarkGreen,Color.DarkKhaki,Color.DarkMagenta,Color.DarkOliveGreen,Color.DarkOrange,Color.DarkOrchid,Color.DarkRed,Color.DarkSalmon,Color.DarkSeaGreen,Color.DarkSlateBlue,Color.DarkSlateGray,Color.DarkTurquoise,Color.DarkViolet,Color.DeepPink,Color.DeepSkyBlue,Color.DimGray,Color.DodgerBlue,Color.Firebrick,Color.FloralWhite,Color.ForestGreen,Color.Fuchsia,Color.Gainsboro,Color.GhostWhite,Color.Gold,Color.Goldenrod,Color.Gray,Color.Green,Color.GreenYellow,Color.Honeydew,Color.HotPink,Color.IndianRed,Color.Indigo,Color.Ivory,Color.Khaki,Color.Lavender,Color.LavenderBlush,Color.LawnGreen,Color.LemonChiffon,Color.LightBlue,Color.LightCoral,Color.LightCyan,Color.LightGoldenrodYellow,Color.LightGray,Color.LightGreen,Color.LightPink,Color.LightSalmon,Color.LightSeaGreen,Color.LightSkyBlue,Color.LightSlateGray,Color.LightSteelBlue,Color.LightYellow,Color.Lime,Color.LimeGreen,Color.Linen,Color.Magenta,Color.Maroon,Color.MediumAquamarine,Color.MediumBlue,Color.MediumOrchid,Color.MediumPurple,Color.MediumSeaGreen,Color.MediumSlateBlue,Color.MediumSpringGreen,Color.MediumTurquoise,Color.MediumVioletRed,Color.MidnightBlue,Color.MintCream,Color.MistyRose,Color.Moccasin,Color.NavajoWhite,Color.Navy,Color.OldLace,Color.Olive,Color.OliveDrab,Color.Orange,Color.OrangeRed,Color.Orchid,Color.PaleGoldenrod,Color.PaleGreen,Color.PaleTurquoise,Color.PaleVioletRed,Color.PapayaWhip,Color.PeachPuff,Color.Peru,Color.Pink,Color.Plum,Color.PowderBlue,Color.Purple,Color.Red,Color.RosyBrown,Color.RoyalBlue,Color.SaddleBrown,Color.Salmon,Color.SandyBrown,Color.SeaGreen,Color.SeaShell,Color.Sienna,Color.Silver,Color.SkyBlue,Color.SlateBlue,Color.SlateGray,Color.Snow,Color.SpringGreen,Color.SteelBlue,Color.Tan,Color.Teal,Color.Thistle,Color.Tomato,Color.Transparent,Color.Turquoise,Color.Violet,Color.Wheat,Color.White,Color.WhiteSmoke,Color.Yellow,Color.YellowGreen
        };
        public Color get(){
            if(_n>=colors.Count)
                _n=0;
            Color c = Color.Black;
            try
            {
                c = colors.ElementAt(_n);
            }
            catch {
                c = Color.Red;
            }
            _n+=1;
            return c;
        }

    }

    public partial class Form1 : Form
    {

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */

        [DllImport("user32.dll",
            CharSet = CharSet.Auto,CallingConvention=CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons,
            int dwExtraInfo);

        System.Timers.Timer sequenceTimer;// = new System.Timers.Timer( 10000);
        Point prev = new Point(0, 0);

        NexColor nexColor = new NexColor();
        public Form1()
        {
            InitializeComponent();
            panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            panel1.Click += new System.EventHandler(this.panel1_Click);
            
            // Hook up the Elapsed event for the timer. 
            /*sequenceTimer.Elapsed += sequence_action;
            sequenceTimer.AutoReset = true;
            sequenceTimer.Enabled = false;*/
        }

        private void panel1_MouseEnter(object sender, System.EventArgs e)
        {
            // Update the mouse event label to indicate the MouseLeave event occurred.
            //label1.Text = sender.GetType().ToString() + ": MouseLeave";

            int delay = (int)DelayValBox1.Value;
            //if (Int32.TryParse(DelayValBox1.Value, out delay) && delay > 0)
            if (delay > 0)
            {
                prev = new Point(Cursor.Position.X, Cursor.Position.Y);

                delay *= 1000; //sec to millisec
                sequenceTimer = new System.Timers.Timer(delay);
                sequenceTimer.Elapsed += sequence_action;
                sequenceTimer.AutoReset = true;

                checkBoxONOFF.Checked = true;
                DelayValBox1.ReadOnly = true;
                sequenceTimer.Enabled = true;
            }
        }
        private void panel1_MouseLeave(object sender, System.EventArgs e)
        {
            // Update the mouse event label to indicate the MouseLeave event occurred.
            //label1.Text = sender.GetType().ToString() + ": MouseLeave";
            sequenceTimer.Enabled = false;
            checkBoxONOFF.Checked = false;
            DelayValBox1.ReadOnly = false;
            //checkBox_ACTIVE.Checked = false;
        }
        private void panel1_Click(object sender, System.EventArgs e)
        {



            panel1.BackColor = nexColor.get();
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            if (sequenceTimer== null || sequenceTimer.Enabled == false)
            {
                int delay = (int)DelayValBox1.Value;
                //if (Int32.TryParse(DelayValBox1.Value, out delay) && delay > 0)
                if (delay > 0)
                {
                    prev = new Point(Cursor.Position.X, Cursor.Position.Y);

                    delay *= 1000; //sec to millisec
                    sequenceTimer = new System.Timers.Timer(delay);
                    sequenceTimer.Elapsed += sequence_action;
                    sequenceTimer.AutoReset = true;

                    checkBoxONOFF.Checked = true;
                    DelayValBox1.ReadOnly = true;
                    sequenceTimer.Enabled = true;
                }
            }
            else
            {
                sequenceTimer.Enabled = false;
                checkBoxONOFF.Checked = false;
                DelayValBox1.ReadOnly = false;
                //checkBox_ACTIVE.Checked = false;
            }
        }

        private void sequence_action(Object source, ElapsedEventArgs e)
        {
            Point cur = new Point(Cursor.Position.X, Cursor.Position.Y);
            if (cur == prev)
            {
                //checkBox_ACTIVE.Checked = true;
                //this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new Point(Cursor.Position.X - 5, Cursor.Position.Y - 5);
                System.Threading.Thread.Sleep(100);
                Cursor.Position = new Point(Cursor.Position.X + 5, Cursor.Position.Y + 5);
                System.Threading.Thread.Sleep(100);
                //mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                //mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            }
            else
            {
                //checkBox_ACTIVE.Checked = false;
            }
            prev = new Point(Cursor.Position.X, Cursor.Position.Y);
        }
        private void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 
            this.Cursor = Cursors.Hand;
            
            this.Cursor = new Cursor(Cursor.Current.Handle);
            System.Threading.Thread.Sleep(1000);
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            System.Threading.Thread.Sleep(100);
            Cursor.Position = new Point(Cursor.Position.X + 50, Cursor.Position.Y + 50);

            this.Cursor = Cursors.Default;
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        
    }
}
