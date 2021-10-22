using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
namespace ClassLibrary2
{
    public static class Udp
    { 
    static string remoteAddress= "127.0.0.1"; 
    static int remotePort= 8005;
    static int localPort= 8005;
    public static void SendMessage(byte[] data)
    {
        UdpClient sender = new UdpClient(); 
        try
        {
            sender.Send(data, data.Length, remoteAddress, remotePort); 
        }
        catch (Exception ex)
        {
            sender.Close();
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sender.Close();
        }
    }
    public static byte[] ReceiveMessage()
    {
        UdpClient receiver = new UdpClient(localPort); 
        IPEndPoint remoteIp = null; 
        try
        {
            while (true)
            {
                byte[] data = receiver.Receive(ref remoteIp);
                if (data!=null)
                {
                    return data;
                }
                    
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            receiver.Close();
                return null;
        }
        finally
        {
            receiver.Close();
        }
    }
    }
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
    public class Builder
    {
        string name;
        Int16[] parametrs;
        Byte[] Color;
        public Builder(Int16[] parametrs,string name,Byte[] Color)
        {
            this.name = name;
            this.parametrs = parametrs;
            this.Color = Color;
        }
        byte[] ParametrReqest(byte One, int count)
        {
            byte[] date = new byte[(count * 2) + 4];
            byte[] par = new byte[2];
            date[0] = One;
            int MaxByte = 1, MinBayte = 2;
            for (int i = 0; i < count; i++)
            {
                par = BitConverter.GetBytes(parametrs[i]);
                date[MaxByte] = par[0];
                date[MinBayte] = par[1];
                parametrs[i] = BitConverter.ToInt16(par, 0);
                MinBayte = MinBayte + 2; MaxByte = MaxByte + 2;
            }

            for (int i = 0; i < 3; i++)
            {
                date[MaxByte + i] = Color[i];
            }
            return date;
        }

        public byte[] Parse()
        {
            byte One;
            switch (name)
            {
                case "clear display":
                    One = 0x00;
                   return ParametrReqest(One,0);
                    break;
                case "draw pixel":
                    One = 1;
                    return ParametrReqest(One, 2);
                    break;
                case "draw line":
                    One = 0x02;
                    return ParametrReqest(One, 4);
                    break;
                case "draw rectangle":
                    One = 0x03;
                    return ParametrReqest(One, 4);
                    break;
                case "fill rectangle":
                    One = 0x04;
                    return ParametrReqest(One, 4);
                    break;
                case "draw ellipse":
                    One = 0x05;
                    return ParametrReqest(One, 4);
                    break;
                case "fill ellipse":
                    One = 0x06;
                    return ParametrReqest(One, 4);
                    break;
                default:
                    throw new Exception("Название команды не совпадает с существующими"); 
                    break;
            }
        }
    }
    public static class Parser
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
                        Color += date[MaxByte + i].ToString("X");
                    }
                    else
                    {
                        Color += date[MaxByte + i].ToString("X");
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
                        par3 = pars[2];
                        par4 = pars[3];
                    command = new Command(Name, par1, par2, par3, par4, Color);
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
                        Name = "draw ellipse";
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


