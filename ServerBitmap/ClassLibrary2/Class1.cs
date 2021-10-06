using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClassLibrary2
{
    public class Consoles
    {
        static public void Output(Command comand)
        {
            Console.WriteLine($"Вызвана функция :{comand.Name}");
            Console.WriteLine($"Параметр 1: {comand.Parametr1}");
            Console.WriteLine($"Параметр 2: {comand.Parametr2}");
            Console.WriteLine($"Параметр 3: {comand.Parametr3}");
            Console.WriteLine($"Параметр 4: {comand.Parametr4}");
            Console.WriteLine($"Цвет #{comand.Color}");
            Console.ReadLine();
        }
       
    }
    public class Command
    {
        public Command(string Name, Int16 Parametr1, Int16 Parametr2, Int16 Parametr3, Int16 Parametr4, string Color)
        {
            this.Name = Name;
            this.Parametr1 = Parametr1;
            this.Parametr2 = Parametr2;
            this.Parametr3 = Parametr3;
            this.Parametr4 = Parametr4;
            this.Color = Color;
        }
        public Command(string Name, Int16 Parametr1, Int16 Parametr2, string Color)
        {
            this.Name = Name;
            this.Parametr1 = Parametr1;
            this.Parametr2 = Parametr2;
            this.Color = Color;
        }
        public Command(string Name, string Color)
        {
            this.Name = Name;
            this.Color = Color;
        }

        public Command()
        {
        }

        public string Name { get; set; }
        public Int16 Parametr1 { get; set; }
        public Int16 Parametr2 { get; set; }
        public Int16 Parametr3 { get; set; }
        public Int16 Parametr4 { get; set; }
        public string Color { get; set; }
    }
    static public class Builder
    {
        static string name;
        static byte One;
        static public void ClientReqest()
        {
            Console.WriteLine("Название команды=");
            name = Console.ReadLine();
            Parse(name);

        }
        static byte[] ParametrReqest(int count)
        {
            byte[] date = new byte[(count * 2) + 4];
            byte[] par = new byte[2];
            date[0] = One;
            int MaxByte = 0, MinBayte = 1;

            Int16[] parametrs = new Int16[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите параметр {i}=");
                parametrs[i] = Convert.ToInt16(Console.ReadLine());
                par = BitConverter.GetBytes(parametrs[i]);
                date[MaxByte] = par[0];
                date[MinBayte] = par[1];
                parametrs[i] = BitConverter.ToInt16(par, 0);
                MinBayte = MinBayte + 2; MaxByte = MaxByte + 2;
            }

            for (int i = 0; i < 3; i++)
            {
                date[MinBayte + i] = 02;
            }
            return date;
        }

        static private void Parse(string name)
        {
            switch (name)
            {
                case "clear display":
                    One = 0x00;

                    break;
                case "draw pixel":
                    One = 1;
                    ParametrReqest(2);
                    break;
                case "draw line":
                    One = 0x02;
                    ParametrReqest(2);
                    break;
                case "draw rectangle":
                    One = 0x03;
                    ParametrReqest(2);
                    break;
                case "fill rectangle":
                    One = 0x04;
                    ParametrReqest(2);
                    break;
                case "draw ellipse":
                    One = 0x05;
                    ParametrReqest(2);
                    break;
                case "fill ellipse":
                    One = 0x06;
                    ParametrReqest(2);
                    break;
                default:
                    break;
            }
        }
        /*static public void clear_display(string color)
         {

         }
         static public void draw_pixel(Int16 par1, Int16 par2, string color)
         {

         }
         static public void draw_line(Int16 par1, Int16 par2, Int16 par3, Int16 par4, string color)
         {

         }
         static public void draw_rectangle(Int16 par1, Int16 par2, Int16 par3, Int16 par4, string color)
         {

         }
         static public void draw_ellipse(Int16 par1, Int16 par2, Int16 par3, Int16 par4, string color)
         {

         }
         static public void fill_ellipse(Int16 par1, Int16 par2, Int16 par3, Int16 par4, string color)
         {

         }*/
    }
    static public class Parser
    {
        static string Color;
        static string Name;
       
        
        static private Int16[] ToInt16(byte[] date, int count)
        {
            if (((count * 2)+4)== date.Length)
            {


                Int16[] parametrs = new Int16[count + 3];
                byte[] par = new byte[2];
                int MaxByte = 1, MinBayte = 2, I = 0;
                for (int i = 0; i < count; i++)
                {
                    par[0] = date[MaxByte];
                    par[1] = date[MinBayte];
                    parametrs[i] = BitConverter.ToInt16(par, 0);
                    MinBayte = MinBayte + 2; MaxByte = MaxByte + 2;
                    I = i;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (date[MaxByte + i] < 10)
                    {
                        Color += "0" + date[MaxByte + i];
                    }
                    else
                    {
                        Color += date[MaxByte + i];
                    }

                }
                return parametrs;
            }
            else { throw new Exception("Кол-во параметров неверное относительно требуемого"); }

        }
        static public Command Parse(byte[] date)
        {
       
                Command command;Int16 par1, par2, par3, par4;
                switch (date[0])
                {
                    case 0x00:
                        Name = "clear display"; ToInt16(date, 0);
                        command = new Command(Name, Color);
                        break;
                    case 0x01:
                        Name = "draw pixel";
                        Int16 [] par = ToInt16(date, 2);
                        par1 = par[0];
                        par2 = par[1];
                        command = new Command(Name,par1,par2,Color);
                        break;
                    case 0x02:
                        Name = "draw line";
                        Int16[] pars = ToInt16(date, 4);
                        par1 = pars[0];
                         par2 = pars[1];
                        command = new Command(Name, par1, par2, Color);
                        break;
                    case 0x03:
                        Name = "draw rectangle";
                        Int16[] parss = ToInt16(date, 4);
                        par1 = parss[0];
                        par2 = parss[1];
                        par3 = parss[2];
                        par4 = parss[3];
                        command = new Command(Name, par1, par2,par3,par4 ,Color);
                        break;
                    case 0x04:
                        Name = "fill rectangle";
                        Int16[] parsss = ToInt16(date, 4);
                        par1 = parsss[0];
                        par2 = parsss[1];
                        par3 = parsss[2];
                        par4 = parsss[3];
                        command = new Command(Name, par1, par2, par3, par4, Color);
                        break;
                    case 0x05:
                        Name = " draw ellipse";
                        Int16[] parse = ToInt16(date, 4);
                        par1 = parse[0];
                        par2 = parse[1];
                        par3 = parse[2];
                        par4 = parse[3];
                        command = new Command(Name, par1, par2, par3, par4, Color);
                        break;
                    case 0x06:
                        Name = "fill ellipse";
                        Int16[] pare = ToInt16(date, 4);
                        par1 = pare[0];
                        par2 = pare[1];
                        par3 = pare[2];
                        par4 = pare[3];
                        command = new Command(Name, par1, par2, par3, par4, Color);
                        break;
                    default:
                        command = new Command();
                        throw new Exception("Название команды не совпадает с существующими");
                        break;
                }
                Color = null;
                return command;
            

        }

    }
}


