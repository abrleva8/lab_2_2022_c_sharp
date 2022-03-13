namespace lab_2 {
    interface ICipher {

        string Encode(string? str);
        string Decode(string? str);

        void SetKey(bool IsRand = false);
    }
}