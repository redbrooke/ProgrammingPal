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
    /// <summary>This class handles events. It includes some fucntions for the logical flow of the program.</summary>
    public partial class Form1 : Form
    {
        Bitmap OutputBitmap = new Bitmap(532,496);
        DrawHandler theCanvass;
        commandRun commandShell = new commandRun();
        textboxRun textboxRunner = new textboxRun();
        private SaveFileDialog dioBox;
        private OpenFileDialog dioBoxOpen;
        private List<Tuple<String, int, int>> runTheseCommands = new List<Tuple<String, int, int>>();

        /// <summary> this method creates the form</summary>
        public Form1()
        {
            InitializeComponent();
            theCanvass = new DrawHandler(Graphics.FromImage(OutputBitmap));
        }

        /// <summary>This method greates the canvass and graphic</summary>
        private void paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

        /// <summary>This method takes each line in the code box and runs them</summary>
        private void runBox()
        {
            var rawCode = Codebox.Lines;
            bool done = false;
            runTheseCommands = textboxRunner.returnInstructions(rawCode);

            Array.ForEach(runTheseCommands, run => drawTheCommand(run));
        }

        /// <summary>This method takes an encoded Tuple message and sends it to the appropriate draw command</summary>
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
                    theCanvass.bgClear();
                    break;
                case "reset":
                    theCanvass.MoveTo(0, 0);
                    break;
                case "run":
                    runBox();
                    break;
                case "triangle":
                    theCanvass.DrawTriangle(toDraw.Item2);
                    break;
                case "error":
                    theCanvass.error(toDraw);
                    break;
                case "fill":
                    theCanvass.Fill(toDraw.Item2);
                    break;
                case "color":
                    theCanvass.ColorSet(toDraw.Item2);
                    break;
                case "rectangle":
                    theCanvass.DrawRectangle(toDraw.Item2, toDraw.Item3);
                    break;
                case null:
                    break;
            }
            Refresh();
        }

        /// <summary>When enter is pressed this code runs that line</summary>
        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){
                string input = commandLine.Text.Trim().ToLower();
                var toDraw = commandShell.returnInstruction(input);
                drawTheCommand(toDraw);
                commandLine.Text = "";
            }
        }
        /// <summary>This method saves the code</summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dioBox = new SaveFileDialog();
            dioBox.Filter = "Text|*.txt";
            dioBox.RestoreDirectory = true;

            if (dioBox.ShowDialog() == DialogResult.OK)
            {
                this.Codebox.SaveFile(dioBox.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        /// <summary>This method loads the code</summary>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dioBoxOpen = new OpenFileDialog();
            dioBoxOpen.Filter = "Text|*.txt";
            dioBoxOpen.RestoreDirectory = true;

            if (dioBoxOpen.ShowDialog() == DialogResult.OK)
            {
                this.Codebox.LoadFile(dioBoxOpen.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
