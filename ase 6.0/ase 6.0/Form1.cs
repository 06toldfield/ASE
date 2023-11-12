using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project_Last
{
    
    public partial class Form1 : Form
    {/// <summary>
     /// this sets out the canvass ready for use 
     /// </summary>
     /// 

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        Bitmap OutputBitmap = new Bitmap(640, 480);
        Canvass MyCanvass;
        public Form1()
        {
            InitializeComponent();
            MyCanvass = new Canvass(Graphics.FromImage(OutputBitmap));

        }
        


        /// <summary>
        /// this sets the variables for use 
        /// </summary>
        String xdest;
        String ydest;
        String method;
        String parameters;
        String[] a;
        int numofparams;
        String[] b;
        int numofcommand;
        int parsx;
        int parsy;
        
        private void ProcessCommand(string method, string parameters)
        {
            Console.WriteLine("being called");
            

            switch (method)
            {
               
                case "black":
                    MyCanvass.Colourblack();
                    break;
                case "red":
                    MyCanvass.Colourred();
                    break;
                case "green":
                    MyCanvass.Colourgreen();
                    break;
                case "pink":
                    MyCanvass.Colourpink();
                    break;
                case "clear":
                    MyCanvass.Clear();
                    break;
                case "reset":
                    MyCanvass.Reset();
                    break;
                case "drawto":
                    string[] coords = parameters.Split(',');
                    if (coords.Length != 2)
                    {
                        throw new Exception("Incorrect number of parameters for 'drawto'");
                    }
                    int x = Int32.Parse(coords[0]);
                    int y = Int32.Parse(coords[1]);
                    MyCanvass.DrawLine(x, y);
                    break;
                case "square":
                    int width = Int32.Parse(parameters);
                    MyCanvass.DrawSquare(width);
                    break;
                case "circle":
                    int radius = Int32.Parse(parameters);
                    MyCanvass.DrawCircle(radius);
                    break;
                case "moveto":
                    
                    string[] moveCoords = parameters.Split(',');
                    if (moveCoords.Length != 2)
                    {
                        throw new Exception("Incorrect number of parameters for 'moveto'");
                    }
                    int moveX = Int32.Parse(moveCoords[0]);
                    int moveY = Int32.Parse(moveCoords[1]);
                    MyCanvass.Moveto(moveX, moveY);
                    break;
                case "triangle":
                    string[] coords1 = parameters.Split(',');
                    if (coords1.Length != 3)
                    {
                        throw new Exception("Incorrect number of parameters for 'drawto'");
                    }

                    int point1 = Int32.Parse(coords1[0]);
                    int point2 = Int32.Parse(coords1[1]);
                    int point3 = Int32.Parse(coords1[2]);



                    break;
                

                default:
                    Console.WriteLine("Incorrect command");
                    break;
            }
        }


        public void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

        public void parse()
        {
            /// this is used to parse the parameters gathered 
            parsx = Int32.Parse(xdest);
            parsy = Int32.Parse(ydest);
        }

        void button1_Click(object sender, EventArgs e)
        {
                {
          
                string commandText = ProgramWindow.Text.Trim().ToLower();
                    Console.WriteLine(commandText);

                    string[] lines = commandText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    
                    
                    foreach (string line in lines)
                    {

                        int numofcommand = 0;
                        string method = string.Empty;
                        string parameters = string.Empty;
                        string[] a;
                        int numofparams = 0;


                        string[] command = line.Split(' ');


                        if (command.Length == 1)
                        {
                            method = command[0];
                            numofcommand++;
                        ProcessCommand(method,parameters);                        }
                        else if (command.Length == 2)
                        {
                            method = command[0];
                            parameters = command[1];
                            a = parameters.Split(',');
                            numofparams = a.Length;
                            numofcommand++;
                        ProcessCommand(method, parameters);

                        }
                    Console.WriteLine(method);
                    }
                    
                Console.WriteLine("working");

                ///finds out what kind of operation will be needed

                ProgramWindow.Text = "";
                Refresh();
            }


            }

       
    }
    }

      