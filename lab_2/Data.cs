namespace lab_2 {
    public class Data {
        private string str;
        private int key;

        public Data(string str, int key) {
            this.str = str;
            this.key = key;
        }

        public int Key {
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
    }
}
