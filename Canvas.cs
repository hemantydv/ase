using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment
{
    public class Canvas
    {
        //variable to determine the position of x and y cordinates
       public int xpos;
        public int ypos;

        Graphics g;

        //creating a pen to draw shapes
        Pen pen = new Pen(Color.Black, 2);

        //creating a solid brush to fill shapes
        SolidBrush brush;

        //to determine whether the fill should be on or not
        bool fill =false;


        public Canvas(Graphics g)
        {
            this.g = g;

            //intializing the positions of x and y to point 0 ,0
            this.xpos = 0;
            this.ypos = 0;
        }

        //Creating method to fill red color into shapes

        public void fillred()
        {
            this.fill = true;
            brush = new SolidBrush(Color.Red);
        }

        //Creating method to fill blue color in shapes

        public void fillblue()
        {
            this.fill = true;
            brush = new SolidBrush(Color.Blue);
        }

        //Creating method to fill green color in shapes
        public void fillgreen()
        {
            this.fill = true;
            brush = new SolidBrush(Color.Green);
        }

        //creating methods for coloured pens

        public void penred()
        {
            pen = new Pen(Color.Red, 2);
        }

        public void penblue()
        {
            pen = new Pen(Color.Blue, 2);
        }

        public void pengreen()
        {
            pen = new Pen(Color.Green, 2);
        }

        //Defining new moveto method to move pen co ordinates
        public void moveto(int x, int y)
        {
            this.xpos = x;
            this.ypos = y;
        }

        //Creating method to drawline
        public void drawto(int x, int y)
        {
            g.DrawLine(pen, xpos, ypos, x, y);

            this.xpos = x;
            this.ypos = y;
        }

        //Create rectangle method

        public void drawrectangle(int x, int y)
        {
            g.DrawRectangle(pen, xpos, ypos, x, y);

            if (fill)
            {
                g.FillRectangle(brush, xpos, ypos, x, y);
            }
        }

        // Create circle method
        public void drawcircle(int x, int y)
        {
            g.DrawEllipse(pen, xpos, ypos, x, y);

            if (fill)
            {
                g.FillEllipse(brush, xpos, ypos, x, y);
            }

        }
        
    }
}
