using System.Text;

namespace lab_2 {
    public class CaesarСipher : ICipher {

        private int key;

        public string Encode(string? str) {
            key %= 256;
            StringBuilder result = new StringBuilder();
            foreach (char ch in str) {
                int t = (int) ch +key;
                if (t < 256) {
                    result.Append((char) t);
                } else {
                    result.Append((char) (t - 256));
                }
            }
            return result.ToString();
        }

        public string Decode(string? str) {
            key %= 256;
            StringBuilder result = new StringBuilder();
            foreach (char ch in str) {
                int t = (int) ch - key;
                if (t >= 0) {
                    result.Append((char) t);
                } else {
                    result.Append((char) (t + 256));
                }
            }
            return result.ToString();
        }

        public void SetKey(bool IsRand = false) {
            if (IsRand) {
                Random random = new Random();
                this.key = random.Next(255);
            } else {
                this.key = Input.GetNumber(1, 255);
            }
        }
    }
}