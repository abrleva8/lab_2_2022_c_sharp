namespace lab_2 {
    interface ICipher {

        public static int MaxCode = 256;
        Data? Encode();
        Data? Decode();

        void SetKey(bool isRand = false);

        string Key { get; set; }
        string? GetMessage();
        bool IsGoodKey(string? key);
    }
}