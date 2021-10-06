using System;
using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestClearDisplayParamColor()
        {
            //arange
            Command command;
            string Color = "020202";
            byte[] x2 = new byte[4];
            x2[1] = 0x02;
            x2[2] = 0x02;
            x2[3] = 0x02;
            x2[0] = 0x00;
            //act
            command = Parser.Parse(x2);
            //assert   
            Assert.AreEqual(Color, command.Color);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestClearDisplayParamMaxExp()
        {
            //arange
            Command command;
            byte[] x2 = new byte[6];
            x2[1] = 0x01;
            x2[2] = 0x03;
            x2[3] = 0x02;
            x2[4] = 0x02;
            x2[5] = 0x02;
            x2[0] = 0x00;//Слишком много параметров для команды
            //act
            command = Parser.Parse(x2);
            //assert   
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestClearDisplayParamMinExp()
        {
            //arange
            Command command;
            byte[] x2 = new byte[1];
            x2[0] = 0x00;//Команда без параметров
            //act
            command = Parser.Parse(x2);
            //assert   
        }
        [TestMethod]
        public void TestCommandName()
        {
            //arange
            Command command;
            byte[] x2 = new byte[4];
            string Name = "clear display";  
            x2[1] = 0x02;
            x2[2] = 0x02;
            x2[3] = 0x02;
            x2[0] = 0x00;
            //act
            command = Parser.Parse(x2);
            //assert   
            Assert.AreEqual(Name, command.Name);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestCommandNameExp()
        {
            //arange
            Command command;
            byte[] x2 = new byte[4];
            x2[1] = 0x02;
            x2[2] = 0x02;
            x2[3] = 0x02;
            x2[0] = 0x10;//Несуществующяя команда
            //act
            command = Parser.Parse(x2);
            //assert   
           
        }
    }
}
