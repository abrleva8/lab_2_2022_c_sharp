using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_2;

namespace lab_2.Tests {
    [TestClass()]
    public class CaesarСipherTests {
        [TestMethod()]
        public void EncodeTest() {
            string? str = "abcde";
            string? rightAnswer = "bcdef";
            ICipher caesarСipher = new CaesarСipher(str);
            caesarСipher.Key = "1";
            caesarСipher.Encode();
            Assert.AreEqual(caesarСipher.Message, rightAnswer);
        }

        [TestMethod()]
        public void DecodeTest() {
            string? str = "bcdef";
            string? rightAnswer = "abcde";
            ICipher caesarСipher = new CaesarСipher(str);
            caesarСipher.Key = "1";
            caesarСipher.Decode();
            Assert.AreEqual(caesarСipher.Message, rightAnswer);
        }
    }
}