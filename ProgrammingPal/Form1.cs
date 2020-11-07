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
        commandRun commandShell = new commandRun();
        textboxRun textboxRunner = new textboxRun();
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

        private void runBox()
        {
            var rawCode = Codebox.Lines;
            Array.ForEach(rawCode, run => drawTheCommand(textboxRunner.returnInstruction(run)));
        }

        private void drawTheCommand(Tuple<string, int, int> toDraw) // draws whatever command is sent
        {
            switch (toDraw.Item1)
            {
                case "drawto":
                    theCanvass.DrawLine(toDraw.Item2, toDraw.Item3);
                    break;
                case "square":
                    theCanvass.DrawSquare(toDraw.Item2);
                    break;
                case "circle":
                    theCanvass.DrawCircle(toDraw.Item2);
                    break;
                case "moveto":
                    theCanvass.MoveTo(toDraw.Item2, toDraw.Item3);
                    break;
                case "clear":
                    theCanvass.Clear();
                    break;
                case "reset":
                    theCanvass.MoveTo(0, 0);
                    break;
                case "run":
                    runBox();
                    break;
            }
            Refresh();
        }

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){
                string input = commandLine.Text.Trim().ToLower();
                var toDraw = commandShell.returnInstruction(input);
                drawTheCommand(toDraw);
                commandLine.Text = "";
            }
        }

    }
}
