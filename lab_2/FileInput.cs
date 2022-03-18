namespace lab_2 {
    class FileInput : Input {
        public bool Read(ref string? message) {
            Console.WriteLine("Enter the filepath please:");
            string? filePath = Console.ReadLine();
            if (File.Exists(filePath)) {
                string? data = File.ReadLines(filePath).First();
                if (IsGoodMessage(data)) {
                    message = data;
                } else {
                    Console.WriteLine("The file has symbols which have ASCII code more than 255!");
                    return false;
                }

                return true;
            }

            Console.WriteLine("The file can't be opened");
            return false;

        }

        public bool Read(ref ICipher iCipher, ref string? key) {
            Console.WriteLine("Enter the filepath please:");
            string? filePath = Console.ReadLine();
            Console.WriteLine(filePath);
            if (File.Exists(filePath)) {
                string? data = File.ReadLines(filePath).First();
                if (iCipher.IsGoodKey(data)) {
                    key = data;
                } else {
                    key = null;
                    Console.WriteLine("The key is bad. Maybe it is not matched to encoder.");
                    return false;
                }

                return true;
            }
            return true;
        }
    }
}