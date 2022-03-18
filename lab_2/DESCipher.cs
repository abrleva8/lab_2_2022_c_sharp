using System.Globalization;
using System.Numerics;
using System.Text;

namespace lab_2 {
    public class DESCipher : ICipher {

        private string? _message;

        public string? Key { get; set; }

        public DESCipher(string? message) {
            this._message = message;
        }

        private const int sizeOfBlock = 128;
        private const int sizeOfSmallChar = 8;
        private const int sizeOfChar = 16;

        private const int shiftKey = 2; 

        private const int quantityOfRounds = 16;

        private string?[]? blocks;

        private string StringToRightLength(string input) {
            while (((input.Length * sizeOfChar) % sizeOfBlock) != 0) {
                input += "#";
            }

            return input;
        }

        private string BringingToDesiredLength(string input) {
            while (input.Length < sizeOfSmallChar) {
                input = "0" + input;
            }
            return input;

        }

        private string? StringToBinaryFormat(string? input) {
            string? output = "";

            foreach (char ch in input!) {
                string? char_binary = Convert.ToString(ch, 2);

                while (char_binary.Length < sizeOfChar) {
                    char_binary = "0" + char_binary;
                }

                output += char_binary;
            }

            return output;
        }

        private void CutStringIntoBlocks(string input) {
            blocks = new string?[(input.Length * sizeOfChar) / sizeOfBlock];

            int lengthOfBlock = input.Length / blocks.Length;

            for (int i = 0; i < blocks.Length; i++) {
                blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
                blocks[i] = StringToBinaryFormat(blocks[i]);
            }
        }

        private void CutBinaryStringIntoBlocks(string input) {
            blocks = new string?[input.Length / sizeOfBlock];

            int lengthOfBlock = input.Length / blocks.Length;

            for (int i = 0; i < blocks.Length; i++) {
                blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
            }
        }

        public string HexStringToString(string? data) {
            string[] splitData = new string[data!.Length];

            int byteIndex = 0;

            foreach (char ch in data) {
                if (ch == '-') {
                    byteIndex++;
                    continue;
                }

                splitData[byteIndex] += ch;
            }

            byteIndex++;
            string output = "";
            for (int i = 0; i < byteIndex; i++) {
                output += BringingToDesiredLength(Convert.ToString((int) Byte.Parse(splitData[i], 
                    System.Globalization.NumberStyles.HexNumber), 2));
            }

            return output;
        }

        private string StringToHexString(string? input) {
            List<Byte> bytes = new();
            while (input!.Length > 0) {
                string char_binary = input.Substring(0, 8);
                input = input.Remove(0, 8);
                Byte byteSymbol = Convert.ToByte(char_binary, 2);
                bytes.Add(byteSymbol);
            }
            string output = BitConverter.ToString(bytes.ToArray());
            return output;
        }

        private static string? CorrectKeyWord(string? input, int lengthKey) {
            if (input != null && input.Length > lengthKey) {
                input = input[..lengthKey];
            } else {
                while (input != null && input.Length < lengthKey) {
                    input = "0" + input;
                }
            }

            return input;
        }

        private string? Encode_One_Round(string? input, string? key) {
            string? left = input!.Substring(0, input.Length / 2);
            string? right = input.Substring(input.Length / 2, input.Length / 2);

            return (right + Xor(left, CodingFunction(right, key)));
        }

        private string? Decode_One_Round(string? input, string? key) {
            string? left = input!.Substring(0, input.Length / 2);
            string? right = input.Substring(input.Length / 2, input.Length / 2);

            return (Xor(CodingFunction(left, key), right) + left);
        }
        private string? Xor(string? s1, string? s2) {
            string? result = "";

            for (int i = 0; i < s1!.Length; i++) {
                bool a = Convert.ToBoolean(Convert.ToInt32(s1[i].ToString()));
                bool b = Convert.ToBoolean(Convert.ToInt32(s2![i].ToString()));

                if (a ^ b) {
                    result += "1";
                } else {
                    result += "0";
                }
            }
            return result;
        }

        private string? CodingFunction(string? s1, string? s2) {
            return Xor(s1, s2);
        }

        private static string? KeyToNextRound(string? key) {
            for (int i = 0; i < shiftKey; i++) {
                if (key == null) continue;
                key = key[^1] + key;
                key = key.Remove(key.Length - 1);
            }

            return key;
        }

        private static string? KeyToPrevRound(string? key) {
            for (int i = 0; i < shiftKey; i++) {
                key = key + key![0];
                key = key.Remove(0, 1);
            }

            return key;
        }

        private string? StringFromBinaryToNormalFormat(string? input) {
            string? output = "";

            while (input!.Length > 0) {
                string charBinary = input.Substring(0, sizeOfChar);
                input = input.Remove(0, sizeOfChar);

                int a = 0;
                int degree = charBinary.Length - 1;

                foreach (char c in charBinary)
                    a += Convert.ToInt32(c.ToString()) * (int) Math.Pow(2, degree--);

                output += ((char) a).ToString();
            }

            return output;
        }

        public Data? Encode() {
            _message = StringToRightLength(_message!);
            CutStringIntoBlocks(_message);
            Key = CorrectKeyWord(Key, _message.Length / (2 * blocks!.Length));
            Key = StringToBinaryFormat(Key);
            for (int j = 0; j < quantityOfRounds; j++) {
                for (int i = 0; i < blocks.Length; i++)
                    blocks[i] = Encode_One_Round(blocks[i], Key);

                Key = KeyToNextRound(Key);
            }
            Key = KeyToPrevRound(Key);
            string? result = "";

            foreach (string? str in blocks) {
                result += str;
            }

            Key = StringToHexString(Key);
            this._message = StringToHexString(result);
            return new Data(this._message, this.Key);
        }

        public Data? Decode() {
            Key = HexStringToString(Key);
            _message = HexStringToString(_message);

            CutBinaryStringIntoBlocks(_message);
            
            if (Key.Length / (sizeOfBlock / 2) == 1 && _message.Length % sizeOfBlock == 0) {

            } else {
                Console.WriteLine("I am here!");
            }

            CutBinaryStringIntoBlocks(_message);

            for (int j = 0; j < quantityOfRounds; j++) {
                for (int i = 0; i < blocks!.Length; i++)
                    blocks[i] = Decode_One_Round(blocks[i], Key);

                Key = KeyToPrevRound(Key);
            }

            Key = KeyToNextRound(Key);

            string? result = "";

            foreach (string? str in blocks!) {
                result += str;
            }

            this._message = StringFromBinaryToNormalFormat(result);
            return new Data(this._message!, this.Key);
        }

        public void SetKey(bool isRand = false) {
            if (isRand) {
                Random random = new Random();
                this.Key = random.Next(255).ToString();
            } else {
                this.Key = Console.ReadLine();
            }
        }

        public void SetKey(string? key) {
           this.Key = key;
        }

        public string? GetMessage() {
            return _message;
        }

        public bool IsGoodKey(string? key) {
            return true;
        }
    }
}