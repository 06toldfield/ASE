using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Last
{
    class Canvass
    {
        Graphics g;
        Pen Pen;
        int xpos, ypos,point1a,point2a,point3a;

        public Canvass(Graphics g)
        {
            this.g = g;
            xpos = ypos = 0;


        }

        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(Pen, xpos, ypos, toX, toY);
            xpos = toX;
            ypos = toY;

        }
        public void Moveto(int toX, int toY)
        {
            Pen = new Pen(Color.White);
            g.DrawLine(Pen, xpos, ypos, toX, toY);
            xpos = toX;
            ypos = toY;

        }
        public void DrawSquare(int width)
        {
            g.DrawRectangle(Pen, xpos, ypos, xpos + width, ypos + width);

        }
        public void DrawCircle(int radius)
        {
            g.DrawEllipse(Pen, xpos + radius, ypos + radius, xpos + radius, ypos + radius);
        }
        public void DrawTriangle(PointF point1, PointF point2, PointF point3)
        {
           
            g.DrawLine(Pen, point1, point2);
            g.DrawLine(Pen, point2, point3);
            g.DrawLine(Pen, point3, point1);
        }


        public void Clear()
        {
            g.Clear(Color.White);
        }
        public void Colourred()
        {
            Pen = new Pen(Color.Red);
        }
        public void Colourblack()
        {
            Pen = new Pen(Color.Black);
        }
        public void Colourpink()
        {
            Pen = new Pen(Color.Pink);
        }
        public void Colourgreen()
        {
            Pen = new Pen(Color.Green);
        }
        public void Colourwhite()
        {
            Pen = new Pen(Color.White);
        }
        public void Reset()
        {
            xpos = 0;
            ypos = 0;

        }
    }
}
