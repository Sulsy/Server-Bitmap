using System;
using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestClearDisplayParam()
        {
            //arange
            Command command;
            Command commands = new Command("clear display", "020202");
            // Color = "020202", Name= "clear display"   Очистка десплея 
            byte[] x2 = new byte[4];
            x2[1] = 0x02;
            x2[2] = 0x02;
            x2[3] = 0x02;
            x2[0] = 0x00;
            //act
            command = Parser.Parse(x2);
            //assert   
            Assert.AreEqual(commands.Color, command.Color);
            Assert.AreEqual(command.Parametr1,0);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestClearDisplayParamMaxExp()
        {
            //arange
            Command command;
            Command commands = new Command("clear display", "020202");
            // Color = "020202", Name= "clear display"   Очистка десплея 
            byte[] x2 = new byte[6];
            x2[1] = 0x01;
            x2[2] = 0x03;
            x2[3] = 0x02;
            x2[4] = 0x02;
            x2[5] = 0x02;
            x2[0] = 0x00;
            //act
            command = Parser.Parse(x2);
            //assert   
            Assert.AreEqual(commands.Color, command.Color);
            Assert.AreEqual(command.Parametr1, 0);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestClearDisplayParamMinExp()
        {
            //arange
            Command command;
            Command commands = new Command("clear display", "020202");
            // Color = "020202", Name= "clear display"   Очистка десплея 
            byte[] x2 = new byte[1];
            x2[0] = 0x00;
            //act
            command = Parser.Parse(x2);
            //assert   
            Assert.AreEqual(commands.Color, command.Color);
            Assert.AreEqual(command.Parametr1, 0);
        }
        [TestMethod]
        public void TestCommandName()
        {
            //arange
            Command command;
            Command commands = new Command("clear display", "020202");
            byte[] x2 = new byte[4];
            // Color = "020202", Name= "clear display"   Очистка десплея 
            x2[1] = 0x02;
            x2[2] = 0x02;
            x2[3] = 0x02;
            x2[0] = 0x00;
            //act
            command = Parser.Parse(x2);
            //assert   
            Assert.AreEqual(commands.Name, command.Name);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestCommandNameExp()
        {
            //arange
            Command command;
            Command commands = new Command("clear display", "020202");
            byte[] x2 = new byte[4];
            // Color = "020202", Name= "clear display"   Очистка десплея 
            x2[1] = 0x02;
            x2[2] = 0x02;
            x2[3] = 0x02;
            x2[0] = 0x10;
            //act
            command = Parser.Parse(x2);
            //assert   
            Assert.AreEqual(commands.Name, command.Name);
        }
    }
}
