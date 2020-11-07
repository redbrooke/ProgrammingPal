﻿using System;
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
        commandRun commandShell = new commandRun();
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
                var toDraw = commandShell.returnInstruction(input);

                switch (toDraw.Item1) {
                    case "drawto":
                        theCanvass.DrawLine(toDraw.Item2, toDraw.Item3);
                        break;
                    case "square":
                        theCanvass.DrawSquare(toDraw.Item2);
                        break;
                    case "moveto":
                        theCanvass.MoveTo(toDraw.Item2, toDraw.Item3);
                        break;
                    case "reset":
                        theCanvass.MoveTo(0, 0);
                        break;
                }

                commandLine.Text = "";
                Refresh();
            }
        }

    }
}
