using System.Text;

namespace lab_2 {
    public class Data {
        private string str;
        private string key;

        public string Key {
            get {
                return this.key;
            }

            set {
                this.key = value;
            }
        }

        public string Str {
            get {
                return this.str;
            }

            set {
                this.str = value;
            }
        }

        public Data(string str, string key) {
            this.str = str;
            this.key = key;
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
            return "The string is " + this.str + Environment.NewLine + "the key is " + this.key;
        }
    }
}
