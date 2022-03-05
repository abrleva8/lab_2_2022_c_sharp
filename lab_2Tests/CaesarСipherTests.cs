using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Tests {
    [TestClass()]
    public class CaesarСipherTests {
        [TestMethod()]
        public void EncodeTest() {
            string str = "abcde";
            int key = 1;
            string rightAnswer = "bcdef";
            CaesarСipher caesarСipher = new CaesarСipher();
            string methodAnswer = caesarСipher.Encode(str, key);
            Assert.AreEqual(methodAnswer, rightAnswer);
        }
    }
}