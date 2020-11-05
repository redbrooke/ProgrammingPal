using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal
{
    class DrawHandler
    {
        Graphics graphics;
        Pen pen;
        int Xpos;
        int Ypos;

        public DrawHandler(Graphics graphics)
        {
            this.graphics = graphics;
            Xpos = 0;
            Ypos = 0;
            pen = new Pen(Color.Black, 1);
        }

        public void DrawLine(int Xdest, int Ydest) 
        {
            graphics.DrawLine(pen, Xpos, Ypos, Xdest, Ydest);
            Xpos = Xdest;
            Ypos = Ydest;
        }

        public void DrawSquare(int width)
        {
            graphics.DrawRectangle(pen, Xpos, Ypos, Xpos + width, Ypos + width);
        }
    }
}
