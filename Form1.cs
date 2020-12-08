using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment
{
    public partial class Form1 : Form
    {

        //Creating object of Canvas class
        Canvas c;

        //Drawing a bitmap
        Bitmap Outputbitmap = new Bitmap(500, 500);

        public Form1()
        {
            InitializeComponent();

            //permission to draw over bitmap
            c = new Canvas(Graphics.FromImage(Outputbitmap)); 
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //To show image under picture box
            pictureBox1.Image = Outputbitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graph = Graphics.FromImage(Outputbitmap);

            var font = new Font("TimesNewRoman", 10, FontStyle.Italic, GraphicsUnit.Pixel);

            //reading input from command line

            var singleLine = commandline.Text;

            //reading input from richtext box
            var richtext = multipleline.Text;


            //checking if conditions
            if (commandline.Text == "run" || string.IsNullOrEmpty(singleLine))
            {
                string[] regular = richtext.Split('\n');

                string[] variables;

                //for loop to read every line
                for (int i = 0; i < regular.Length; i++)
                {
                    //a variable to store single line every time
                    string Singleline = regular[i].Trim('(', ')').ToLower();

                    //split array to store split line
                    string[] split = Singleline.Split('(');

                    string syntax = split[0];

                    try
                    {

                        //to fill shapes of diffrent colours
                        if (syntax.Equals("fillred"))
                        {
                            c.fillred();
                        }

                        else if (syntax.Equals("fillblue"))
                        {
                            c.fillblue();
                        }

                        else if (syntax.Equals("fillgreen"))
                        {
                            c.fillgreen();
                        }

                        //to have pen of diffrent colours
                        else if (syntax.Equals("penred"))
                        {
                            c.penred();
                        }

                        else if (syntax.Equals("penblue"))
                        {
                            c.penblue();
                        }

                        else if (syntax.Equals("pengreen"))
                        {
                            c.pengreen();
                        }



                        //variables split

                        variables = split[1].Split(',');

                        //for loop
                        for (int k = 0; k < variables.Length - 1; k++)
                        {
                            //point to store variables
                            String x = variables[0];
                            string y = variables[1];

                            //parsing values
                            int xpoint = int.Parse(x);
                            int ypoint = int.Parse(y);

                            //if condition
                            if (syntax.Equals("moveto") && variables.Length == 2)
                            {
                                c.moveto(xpoint, ypoint);
                            }
                            else if (syntax.Equals("drawto") && variables.Length == 2)
                            {
                                c.drawto(xpoint, ypoint);
                            }
                            else if (syntax.Equals("drawcircle") && variables.Length == 2)
                            {
                                c.drawcircle(xpoint, ypoint);
                            }
                            else if (syntax.Equals("drawrectangle") && variables.Length == 2)
                            {
                                c.drawrectangle(xpoint, ypoint);
                            }
                            else
                            {
                                //print error
                                graph.DrawString("Syntactical Eroor", Font, Brushes.Black, new Point(0, 0));
                            }


                        }




                    }

                    catch (Exception)
                    {
                        graph.DrawString("", Font, Brushes.Black, new Point(0, 0));
                    }

                }
            }

            else if (commandline.Text != "run" && string.IsNullOrEmpty(richtext))
            {

                //to store values
                String[] values;

                //reading a line from command line and trimming it
                string Singleline = singleLine.Trim('(', ')').ToLower();

                //split the values
                string[] split = Singleline.Split('(');

                //to store syntax
                string syntax = split[0];

                try
                {

                    //to fill shapes of diffrent colours
                    if (syntax.Equals("fillred"))
                    {
                        c.fillred();
                    }

                    else if (syntax.Equals("fillblue"))
                    {
                        c.fillblue();
                    }

                    else if (syntax.Equals("fillgreen"))
                    {
                        c.fillgreen();
                    }

                    //to have pen of diffrent colours
                    else if (syntax.Equals("penred"))
                    {
                        c.penred();
                    }

                    else if (syntax.Equals("penblue"))
                    {
                        c.penblue();
                    }

                    else if (syntax.Equals("pengreen"))
                    {
                        c.pengreen();
                    }


                    //Splitting up the values provided
                    values = split[1].Split(',');

                    for (int k = 0; k < values.Length - 1; k++)
                    {
                        //point to store variables
                        String x = values[0];
                        string y = values[1];

                        //parsing values
                        int xpoint = int.Parse(x);
                        int ypoint = int.Parse(y);

                        //if condition
                        if (syntax.Equals("moveto") && values.Length == 2)
                        {
                            c.moveto(xpoint, ypoint);
                        }
                        else if (syntax.Equals("drawto") && values.Length == 2)
                        {
                            c.drawto(xpoint, ypoint);
                        }
                        else if (syntax.Equals("drawcircle") && values.Length == 2)
                        {
                            c.drawcircle(xpoint, ypoint);
                        }
                        else if (syntax.Equals("drawrectangle") && values.Length == 2)
                        {
                            c.drawrectangle(xpoint, ypoint);
                        }
                        else
                        {
                            //print error
                            graph.DrawString("Syntactical Eroor", Font, Brushes.Black, new Point(0, 0));
                        }


                    }

                }
                catch (Exception)
                {
                    graph.DrawString("Wrong parmeters ", Font, Brushes.Black, new Point(0, 0));

                }

            }


        }

        private void reset_Click(object sender, EventArgs e)
        {
            c.xpos = 0;
            c.ypos = 0;
        }

        //to load file
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "Text File (.txt)|*.txt";
            loadFileDialog.Title = "Open File...";

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader streamReader = new System.IO.StreamReader(loadFileDialog.FileName);
                multipleline.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        //to save file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (.txt)| *.txt";
            saveFileDialog.Title = "Save File...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fWriter = new StreamWriter(saveFileDialog.FileName);
                fWriter.Write(multipleline.Text);
                fWriter.Close();
            }
            multipleline.Text += "Command Save";
        }
    }
    }

