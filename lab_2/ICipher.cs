namespace lab_2 {
    public interface ICipher {

        public static int maxCode = 256;
        public static int minCode = 0;
        Data? Encode();
        Data? Decode();

        void SetKey(bool isRand = false);

        string? Key { get; set; }
        string? Message { set; get; }

        bool IsGoodKey(string? key);
    }
}