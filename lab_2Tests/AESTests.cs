using lab_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace lab_2.Tests {
    [TestClass()]
    public class AESTests {
        [TestMethod()]
        public void EncodeTest() {
            string? str = "1234567812345678";
            byte[] rightAnswer = { 109, 172, 28, 86, 231, 71, 250, 224, 58, 207, 140, 104, 145, 228, 40, 224 };
            ICipher aes = new AES(str);
            aes.Key = "1234567812345678";
            aes.Encode();
            byte[] methodAnswer = BytesWorker.StringToBytes(aes.Message);
            CollectionAssert.AreEqual(methodAnswer, rightAnswer);
        }

        [TestMethod()]
        public void DecodeTest() {
            string? str = "1234567812345678";
            byte[] rightAnswer = { 9, 221, 126, 222, 70, 233, 133, 232, 23, 213, 43, 154, 46, 167, 82, 153 };
            ICipher aes = new AES(str);
            aes.Key = "1234567812345678";
            aes.Decode();
            byte[] methodAnswer = BytesWorker.StringToBytes(aes.Message);
            CollectionAssert.AreEqual(methodAnswer, rightAnswer);
        }
    }
}