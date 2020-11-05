using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingPal
{
    public partial class Form1 : Form
    {
        Bitmap OutputBitmap = new Bitmap(532,496);
        DrawHandler theCanvass;
        public Form1()
        {
            InitializeComponent();
            theCanvass = new DrawHandler(Graphics.FromImage(OutputBitmap));
        }


        private void paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){
                string input = commandLine.Text.Trim().ToLower();
                if (input.Equals("line") == true)
                {
                    theCanvass.DrawLine(50, 50);
                }
                else if (input.Equals("square") == true) 
                {
                    theCanvass.DrawSquare(50);
                }
                commandLine.Text = "";
                Refresh();
            }
        }
    }
}
