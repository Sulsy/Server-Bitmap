using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary2;

namespace BMP
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics graphics;
        private Pen pen;
        public Form1()
        {
            InitializeComponent();
            
        }
        public void BMP(Command command)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#" + command.Color);
            switch (command.Name)
            {
                case "clear display":
                    clear_display(col);
                    break;
                case "draw pixel":
                    draw_pixel(command.Parametr1, command.Parametr2, col);
                    break;
                case "draw line":
                    draw_line(command.Parametr1, command.Parametr2, command.Parametr3, command.Parametr4, col);
                    break;
                case "draw rectangle":
                    draw_rectangle(command.Parametr1, command.Parametr2, command.Parametr3, command.Parametr4, col);
                    break;
                case "fill rectangle":
                    fill_rectangle(command.Parametr1, command.Parametr2, command.Parametr3, command.Parametr4, col);

                    break;
                case "draw ellipse":
                    draw_ellipse(command.Parametr1, command.Parametr2, command.Parametr3, command.Parametr4, col);
                    break;
                case "fill ellipse":
                    fill_ellipse(command.Parametr1, command.Parametr2, command.Parametr3, command.Parametr4, col);
                    break;
                default:
                    throw new Exception("Название команды не совпадает с существующими");
            }
        }
        public void clear_display(Color color)
        {
            graphics.Clear(color);
            pictureBox1.Image = bmp;
        }
        public void draw_pixel(Int16 par1, Int16 par2, Color color)
        {
            Brush brush = new SolidBrush(color);
            graphics.FillRectangle(brush,par1,par2,1,1);
            pictureBox1.Image = bmp;
        }
        public void draw_line(Int16 par1, Int16 par2, Int16 par3, Int16 par4, Color color)
        {
            pen = new Pen(color);
            pen.Width = 8f;
            Point point1 = new Point(par1, par2);
            Point point2 = new Point(par3  , par4);
            graphics.DrawLine(pen, point1, point2);
            pictureBox1.Image = bmp;
        }
        public void draw_rectangle(Int16 par1, Int16 par2, Int16 par3, Int16 par4, Color color)
        {
            pen = new Pen(color);
            pen.Width = 8f;
            Point point1 = new Point(par1, par2);
            Point point2 = new Point(par3, par4);
            Size size = new Size(point2);
            Rectangle rectangle = new Rectangle(point1,size);
            graphics.DrawRectangle(pen, rectangle);
            pictureBox1.Image = bmp;
        }
        public void fill_rectangle(Int16 par1, Int16 par2, Int16 par3, Int16 par4, Color color)
        {
            Brush brush = new SolidBrush(color);
            Point point1 = new Point(par1, par2);
            Point point2 = new Point(par3, par4);
            Size size = new Size(point2);
            Rectangle rectangle = new Rectangle(point1, size);
            graphics.FillRectangle(brush, rectangle);
            pictureBox1.Image = bmp;
        }
        public void draw_ellipse(Int16 par1, Int16 par2, Int16 par3, Int16 par4, Color color)
        {
            pen = new Pen(color);
            pen.Width = 8f;
            Point point1 = new Point(par1, par2);
            Point point2 = new Point(par3, par4);
            Size size = new Size(point2);
            Rectangle rectangle = new Rectangle(point1, size);
            graphics.DrawEllipse(pen, rectangle);
            pictureBox1.Image = bmp;
        }
        public void fill_ellipse(Int16 par1, Int16 par2, Int16 par3, Int16 par4, Color color)
        {
            Brush brush = new SolidBrush(color);
            Point point1 = new Point(par1, par2);
            Point point2 = new Point(par3, par4);
            Size size = new Size(point2);
            Rectangle rectangle = new Rectangle(point1, size);
            graphics.FillRectangle(brush, rectangle);
            pictureBox1.Image = bmp;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(500, 500);
            graphics = System.Drawing.Graphics.FromImage(bmp);
            graphics.Clear(Color.Aqua);
            pictureBox1.Image = bmp;
            Thread myThread = new Thread(new ThreadStart(Connect));
            myThread.Start();
        }
        private void Connect()
        {
            byte[] data;
            while (true)
            {
                try
                {

                    data = Udp.ReceiveMessage();
                    if (data != null)
                    {
                        graphics = System.Drawing.Graphics.FromImage(bmp);
                        Command command = Parser.Parse(data);
                        //Consoles.Output(command);
                        BMP(command);
                        data = null;
                    }

                }

                catch (Exception)
                {
                    data = null;
                    continue;
                }
            }
        }
    }
}
