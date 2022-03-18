using System.Text;

namespace lab_2 {
    public class CaesarСipher : ICipher {

        private string? key;
        private string? _message;

        public string Key { get; set; }

        public CaesarСipher(string? message) {
            this._message = message;
        }

        public Data? Encode() {
            if (key != null) {
                int key = Int32.Parse(this.key);
                key %= ICipher.MaxCode;
                StringBuilder result = new StringBuilder();
                foreach (char ch in this._message!) {
                    int t = (int) ch + key;
                    if (t < ICipher.MaxCode) {
                        result.Append((char) t);
                    } else {
                        result.Append((char) (t - ICipher.MaxCode));
                    }
                }
                this._message = result.ToString();
            }

            return new Data(this._message!, this.key!);
        }

        public Data? Decode() {
            if (key != null) {
                int key = Int32.Parse(this.key);
                key %= ICipher.MaxCode;
                StringBuilder result = new StringBuilder();
                foreach (char ch in this._message!) {
                    int t = (int) ch - key;
                    if (t >= 0) {
                        result.Append((char) t);
                    } else {
                        result.Append((char) (t + ICipher.MaxCode));
                    }
                }
                this._message = result.ToString();
            }

            return new Data(this._message!, this.key!);
        }

        public void SetKey(bool isRand = false) {
            int key;
            if (isRand) {
                Random random = new Random();
                key = random.Next(ICipher.MaxCode - 1);
            } else {
                key = Input.GetNumber(1, ICipher.MaxCode - 1);
            }

            this.key = key.ToString();
        }

        public string? GetMessage() {
            return _message;
        }

        public bool IsGoodKey(string? key) {
            int iKey;
            try {
                iKey = Convert.ToInt32(key);
            } catch (Exception) {
                return false;
            }

            if (iKey > 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}