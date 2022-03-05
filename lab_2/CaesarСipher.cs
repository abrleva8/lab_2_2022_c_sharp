using System.Text;

namespace lab_2 {
    public class CaesarСipher : ICipher {

        public string Encode(Data data) {
            data.Key %= 256;
            StringBuilder result = new StringBuilder();
            foreach (char ch in data.Str) {
                int t = (int) ch + data.Key;
                if (t < 256) {
                    result.Append((char) t);
                } else {
                    result.Append((char) (t - 256));
                }
            }
            return result.ToString();
        }

        public string Decode(Data data) {
            throw new NotImplementedException();
        }
    }
}

// margin = int(input())
// for c in input():
// t = ord(c) - margin
// print(chr(t) if t > 96 else chr(t + 26), end = '')