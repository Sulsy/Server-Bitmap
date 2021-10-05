using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary2;
using System.IO;
namespace UnitTestProject1
{
    [TestClass]

    public class UnitTest1
    {
        [TestMethod]
        public void TestWrite()
        {
            Command command;
            string Color = "ffffff", Name= "clear display";//Очистка десплея 
            //arange
            Parser.Parse();
            //act

            //assert   
            Assert.AreEqual(text,name);
        }
        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void TestWriteExp()
        {
            //arange
            
            //act
           
            //assert   
            Assert.AreEqual(text, name);
        }



    }
}
