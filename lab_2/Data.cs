using System.Text;

namespace lab_2 {
    public class Data {
        public string? Key { get; set; }

        public string Str { get; set; }

        public Data(string str, string? key) {
            this.Str = str;
            this.Key = key;
        }

        public static string GetRandomString() { 
            Random rand = new Random();
            int size = rand.Next(1, 20);
            StringBuilder result = new StringBuilder(); 
            for (int i = 0; i < size; i++) {
                result.Append((char) rand.Next(1, 256));

            }
            
            return result.ToString();
        }

        public static string GetRandomKey() {
            Random rand = new Random();
            int key = rand.Next(1, 256);
            return key.ToString();
        }

        public override string ToString() {
            return "The message is " + this.Str + Environment.NewLine + "the key is " + this.Key;
        }
    }
}