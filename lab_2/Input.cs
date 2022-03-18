namespace lab_2 {
    class Input {
        public static int GetNumber() {
            int num = 0;
            while (true) {

                if (int.TryParse(Console.ReadLine(), out num)) {
                    break;
                }

                Console.WriteLine("Invalid number. Try again.");
            }

            return num;
        }

        public static int GetNumber(int a, int b) {
            int num = GetNumber();
            while (num < a || num > b) {
                Console.WriteLine($"Please enter number between {a} and {b}");
                num = GetNumber();
            }

            return num;
        }

        public static string? GetString() {
           Console.WriteLine("Enter a string for encoding or decoding");
           string? str = Console.ReadLine();
           return str;
        }

        public static string? GetKey() {
            Console.WriteLine("Enter a string for encoding or decoding");
            string? str = Console.ReadLine();
            return str;
        }

        public static bool IsGoodMessage(string? message) {
            if (message == null) return true;
            foreach (char ch in message) {
                if (ch > 255) {
                    return false;
                }
            }

            return true;
        }

    }
}