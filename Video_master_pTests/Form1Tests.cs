using Microsoft.VisualStudio.TestTools.UnitTesting;
using Video_master_p;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_master_p.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            Working.User obj=new Working.User();
            obj.insertUser("Sam","sam@gmail.com","5467","NZ");
            Assert.IsTrue(true);

        }

        [TestMethod()]
        public void VideoTest()
        {
            Working.Video obj = new Working.Video();
            obj.deleteVideo(1);
            Assert.IsTrue(true);

        }



    }
}