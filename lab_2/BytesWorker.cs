using System.Text;

namespace lab_2 {
    public class BytesWorker {
        public static byte[] StringToBytes(string? str) {
            byte[] bytes = new byte[str!.Length];
            for (int i = 0; i < str.Length; i++) {
                bytes[i] = (byte) str[i];
            }

            return bytes;
        }

        public static string BytesToString(byte[] bytes) {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes) {
                sb.Append((char) b);
            }

            return sb.ToString();
        }

        public static void DisplayBytes(string? message, string data = "data", string format="X") {
            Console.WriteLine($"The {data} is:");
            foreach (byte b in BytesWorker.StringToBytes(message)) {
                Console.Write(b.ToString($"{format}") + " ");
            }
        }
    }
}