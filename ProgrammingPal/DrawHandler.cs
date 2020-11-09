using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal
{
    /// <summary>This class handles adding things to the canvass. </summary>
    class DrawHandler : ErrorString
    {
        Graphics graphics;
        Pen pen;
        SolidBrush Brush = new SolidBrush(Color.Black);
        int Xpos;
        int Ypos;
        bool fillShape = false;
        Font drawFont = new Font("Arial", 16);

        StringFormat drawFormat = new StringFormat();
        /// <summary>This method sets some basics, particulary about the graphics pannel.</summary>
        public DrawHandler(Graphics graphics)
        {
            this.graphics = graphics;
            Xpos = 0;
            Ypos = 0;
            pen = new Pen(Color.Black, 1);
            graphics.Clear(Color.White);
        }

        /// <summary>This method draws a line</summary>
        public void DrawLine(int Xdest, int Ydest) 
        {
            graphics.DrawLine(pen, Xpos, Ypos, Xdest, Ydest);
            Xpos = Xdest;
            Ypos = Ydest;
        }

        /// <summary>This method draws a square</summary>
        public void DrawSquare(int width)
        {
            if (fillShape)
            {
                graphics.FillRectangle(Brush, Xpos, Ypos, width, width);
            }
            else
            {
                graphics.DrawRectangle(pen, Xpos, Ypos, width, width);
            }
            Xpos += width;
            Ypos += width;
        }
        /// <summary>This method draws a rectangle</summary>
        public void DrawRectangle(int height, int width)
        {
            if (fillShape)
            {
                graphics.FillRectangle(Brush, Xpos, Ypos, width, height);
            }
            else
            {
                graphics.DrawRectangle(pen, Xpos, Ypos, width, height);
            }
            Xpos += width;
            Ypos += height;
        }

        /// <summary>This method is called when an error is generated. It needs to parse the error by calling the getError function, then prints it</summary>
        public void error(Tuple<string, int, int> toDraw) 
        {
            string printMe = getError(toDraw);
            graphics.DrawString(printMe, drawFont, Brush, 30, 30, drawFormat);
        }

        /// <summary>This method draws a triangle</summary>
        public void DrawTriangle(int size)
        {
            int returnPosX = Xpos;
            int returnPosY = Ypos;
            DrawLine(Xpos, Ypos + size);
            DrawLine(Xpos + size, Ypos);
            DrawLine(returnPosX, returnPosY);
        }

        /// <summary>This method draws a circle</summary>
        public void DrawCircle(int circum)
        {
            if (fillShape)
            {
                graphics.FillEllipse(Brush, Xpos, Ypos, circum, circum);
            }
            else
            {
                graphics.DrawEllipse(pen, Xpos, Ypos, circum, circum);
            }
        }

        /// <summary>This method moves the pens position</summary>
        public void MoveTo(int Xdest, int Ydest)
        {
            Xpos = Xdest;
            Ypos = Ydest;
        }

        /// <summary>This method clears the background</summary>
        public void bgClear()
        {
            graphics.Clear(Color.White);
        }

        /// <summary>This method changes the pen color</summary>
        public void ColorSet(int newColor)
        {
            switch (newColor) 
            {
                case 1:
                    pen.Color = Color.Red;
                    Brush.Color = Color.Red;
                    break;
                case 2:
                    pen.Color = Color.Black;
                    Brush.Color = Color.Black;
                    break;
                case 3:
                    pen.Color = Color.Blue;
                    Brush.Color = Color.Blue;
                    break;
            }
        }

        /// <summary>This method fills the shape</summary>
        public void Fill(int fill)
        {
            switch (fill) 
            {
                case 1:
                    fillShape = true;
                    break;
                case 2:
                    fillShape = false;
                    break; 
            }

        }

    }
}
