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
            byte[] x2 = {0x00,0x02, 0x02, 0x02 };
            //act
            command = Parser.Parse(x2);
            //assert   
            Assert.AreEqual(Color, command.Color);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestMaxExp()
        {
            //arange
            Command command;
            byte[] x2 = { 0x00, 0x01, 0x03, 0x02, 0x02, 0x02 };//Слишком много параметров для команды
            //act
            command = Parser.Parse(x2);
            //assert   
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TestMinExp()
        {
            //arange
            Command command;
            byte[] x2 = { 0x00 };//Команда без параметров
            //act
            command = Parser.Parse(x2);
            //assert   
        }
        [TestMethod]
        public void TestCommandName()
        {
            //arange
            Command command;
            byte[] x2 = {0x00,0x02, 0x02, 0x02 };
            string Name = "clear display";  
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
            byte[] x2 = { 0x10, 0x02, 0x02, 0x02 };//Несуществующяя команда
            //act
            command = Parser.Parse(x2);
            //assert   

        }
        [TestMethod]
        public void TestDrawPixelParamOne()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x01, x1[0], x1[1], 0x02, 0x02, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr1);

        }
        [TestMethod]
        public void TestDrawPixelParamTwo()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x01, 0x02, 0x02, x1[0], x1[1], 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr2);
        }
        [TestMethod]
        public void TestDrawLineParametrOne()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, x1[0], x1[1], 0x03, 0x03, 0x04, 0x04, 0x05, 0x05, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr1);

        }
        [TestMethod]
        public void TestDrawLineParametrTwo()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, x1[0], x1[1], 0x05, 0x05, 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr2);
        }
        [TestMethod]
        public void TestDrawLineParametrThree()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, x1[0], x1[1], 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr3);
        }
        [TestMethod]
        public void TestDrawLineParametrFour()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, 0x06, 0x06, x1[0], x1[1], 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr4);
        }
        [TestMethod]
        public void TestDrawRectangleParametrOne()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, x1[0], x1[1], 0x03, 0x03, 0x04, 0x04, 0x05, 0x05, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr1);

        }
        [TestMethod]
        public void TestDrawRectangleParametrTwo()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, x1[0], x1[1], 0x05, 0x05, 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr2);
        }
        [TestMethod]
        public void TestDrawRectangleParametrThree()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, x1[0], x1[1], 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr3);
        }
        [TestMethod]
        public void TestDrawRectangleParametrFour()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, 0x06, 0x06, x1[0], x1[1], 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr4);
        }
        [TestMethod]
        public void TestFillRectangleParametrOne()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, x1[0], x1[1], 0x03, 0x03, 0x04, 0x04, 0x05, 0x05, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr1);

        }
        [TestMethod]
        public void TestFillRectangleParametrTwo()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, x1[0], x1[1], 0x05, 0x05, 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr2);
        }
        [TestMethod]
        public void TestFillRectangleParametrThree()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, x1[0], x1[1], 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr3);
        }
        [TestMethod]
        public void TestFillRectangleParametrFour()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, 0x06, 0x06, x1[0], x1[1], 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr4);
        }
        [TestMethod]
        public void TestDrawEllipseParametrOne()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, x1[0], x1[1], 0x03, 0x03, 0x04, 0x04, 0x05, 0x05, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr1);

        }
        [TestMethod]
        public void TestDrawEllipseParametrTwo()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, x1[0], x1[1], 0x05, 0x05, 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr2);
        }
        [TestMethod]
        public void TestDrawEllipseParametrThree()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, x1[0], x1[1], 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr3);
        }
        [TestMethod]
        public void TestDrawEllipseParametrFour()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, 0x06, 0x06, x1[0], x1[1], 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr4);
        }
        [TestMethod]
        public void TestFillEllipseParametrOne()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, x1[0], x1[1], 0x03, 0x03, 0x04, 0x04, 0x05, 0x05, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr1);

        }
        [TestMethod]
        public void TestFillEllipseParametrTwo()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, x1[0], x1[1], 0x05, 0x05, 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr2);
        }
        [TestMethod]
        public void TestFillEllipseParametrThree()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, x1[0], x1[1], 0x06, 0x06, 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr3);
        }
        [TestMethod]
        public void TestFillEllipseParametrFour()
        {
            //arange
            Int16 a = 200;
            byte[] x1 = BitConverter.GetBytes(a);
            Command command;
            byte[] x2 = { 0x02, 0x04, 0x04, 0x05, 0x05, 0x06, 0x06, x1[0], x1[1], 0x02, 0x01, 0x03 };
            //act
            command = Parser.Parse(x2);
            //assert 
            Assert.AreEqual(a, command.Parametr4);
        }
        [TestMethod]
        public void TestBuilderParamOne()
        {
            //arange
            Int16[] a = { 20, 300, 4, 5 };
            byte[] Color = { 02, 03, 04 };
            string name = "draw pixel";
            //act
            Builder builder = new Builder(a, name, Color);
            byte[] x1 = builder.Parse();
            Command command = Parser.Parse(x1);
            //assert 
            Assert.AreEqual(a[0], command.Parametr1);
        }
        [TestMethod]
        public void TestBuilderParamTwo()
        {
            //arange
            Int16[] a = { 20, 300, 4, 5 };
            byte[] Color = { 02, 03, 04 };
            string name = "draw pixel";
            //act
            Builder builder = new Builder(a, name, Color);
            byte[] x1 = builder.Parse();
            Command command = Parser.Parse(x1);
            //assert 
            Assert.AreEqual(a[1], command.Parametr2);
        }
        [TestMethod]
        public void TestBuilderParamThree()
        {
            //arange
            Int16[] a = { 20, 300, 4, 5 };
            byte[] Color = { 03, 03, 04 };
            string name = "draw line";
            //act
            Builder builder = new Builder(a, name, Color);
            byte[] x1 = builder.Parse();
            Command command = Parser.Parse(x1);
            //assert 
            Assert.AreEqual(a[2], command.Parametr3);
        }
        [TestMethod]
        public void TestBuilderParamFour()
        {
            //arange
            Int16[] a = { 20, 300, 4, 5 };
            byte[] Color = { 03, 03, 04 };
            string name = "draw line";
            //act
            Builder builder = new Builder(a, name, Color);
            byte[] x1 = builder.Parse();
            Command command = Parser.Parse(x1);
            //assert 
            Assert.AreEqual(a[3], command.Parametr4);
        }
        [TestMethod]
        public void TestBuilderParamName()
        {
            //arange
            Int16[] a = { 20, 300, 4, 5 };
            byte[] Color = { 02, 03, 04 };
            string name = "draw pixel";
            //act
            Builder builder = new Builder(a, name, Color);
            byte[] x1 = builder.Parse();
            Command command = Parser.Parse(x1);
            //assert 
            Assert.AreEqual(name, command.Name);
        }
        [TestMethod]
        public void TestBuilderParamColor()
        {
            //arange
            Int16[] a = { 20, 300, 4, 5 };
            byte[] Color = { 02, 03, 04 };
            String ColorS = "020304";
            string name = "draw pixel";
            //act
            Builder builder = new Builder(a, name, Color);
            byte[] x1 = builder.Parse();
            Command command = Parser.Parse(x1);
            //assert 
            Assert.AreEqual(ColorS, command.Color);
        }
    }
}
