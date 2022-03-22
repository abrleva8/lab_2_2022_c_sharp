using System.Text;

namespace lab_2 {
    public class Data {

        public static int maxCode = 256;
        public static int minCode = 0;
        private static int maxSizeRandMessage = 20;
        public string? Key { get; set; }

        public string? Str { get; set; }

        public Data(string? str, string? key) {
            Str = str;
            Key = key;
        }

        public static string GetRandomString() {
            Random rand = new Random();
            int size = rand.Next(1, maxSizeRandMessage);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < size; i++) {
                result.Append((char) rand.Next(minCode + 1, maxCode));

            }

            return result.ToString();
        }
    }
}