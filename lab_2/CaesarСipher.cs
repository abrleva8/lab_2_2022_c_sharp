using System.Text;

namespace lab_2 {
    public class CaesarСipher : ICipher {

        private string? key;
        private string? message;

        public string? Key {
            get {
                return this.key;
            }
            set {
                this.key = value;
            }
        }

        public string? Message {
            get {
                return this.message;
            }
            set {
                this.message = value;
            }
        }


        public CaesarСipher(string? message) {
            this.message = message;
        }

        public Data? Encode() {
            if (key != null) {
                int key = Int32.Parse(this.key);
                key %= ICipher.MaxCode;
                StringBuilder result = new StringBuilder();
                foreach (char ch in this.message!) {
                    int t = (int) ch + key;
                    if (t < ICipher.MaxCode) {
                        result.Append((char) t);
                    } else {
                        result.Append((char) (t - ICipher.MaxCode));
                    }
                }
                this.message = result.ToString();
            }

            return new Data(this.message!, this.key!);
        }

        public Data? Decode() {
            if (key != null) {
                int key = Int32.Parse(this.key);
                key %= ICipher.MaxCode;
                StringBuilder result = new StringBuilder();
                foreach (char ch in this.message!) {
                    int t = (int) ch - key;
                    if (t >= 0) {
                        result.Append((char) t);
                    } else {
                        result.Append((char) (t + ICipher.MaxCode));
                    }
                }
                this.message = result.ToString();
            }

            return new Data(this.message!, this.key!);
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


        public bool IsGoodKey(string? key) {
            int iKey;
            try {
                iKey = Convert.ToInt32(key);
            } catch (Exception) {
                return false;
            }

            return iKey > 0;
        }

        public bool IsGoodDecodingMessage(string? message) {
            return true;
        }
    }
}