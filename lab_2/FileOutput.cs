namespace lab_2 {
    class FileOutput {

        void TryOverwriteFile(ref string? fileName) {
            bool isOverwrite = false;

            while (File.Exists(fileName) && !isOverwrite) {
                Console.WriteLine("The file with same name exists. " +
                                  "Are you sure to want overwrite the file? Enter please y/n.");
                isOverwrite = ConsoleInput.IsChoiceYes();
                if (!isOverwrite) {
                    Console.WriteLine("Please enter the filename:");
                    fileName = Console.ReadLine();
                }
            }

        }

        public void SaveData(string? data) {
            Console.WriteLine("Do you want to save data to a file? Input please y/n.");
            bool isYes = ConsoleInput.IsChoiceYes();

            if (!isYes) return;
            bool isSuccess = SaveDataToFile(data);

            while (!isSuccess) {
                Console.WriteLine("The data didn't save! Try again!");
                isSuccess = SaveDataToFile(data);
            }

            Console.WriteLine("The data saved successfully!");
        }

        private bool SaveDataToFile(string? data) {
            Console.WriteLine("Please, enter the filename:");
            string? fileName = Console.ReadLine();
            TryOverwriteFile(ref fileName);
            FileStream? fileStream = null;
            try {
                if (fileName != null) fileStream = new FileStream(fileName, FileMode.Create);
            } catch (Exception) {
                Console.WriteLine("Sorry, there is a problem with the file.");
                return false;
            }

            if (fileStream == null) return true;
            using StreamWriter writer = new StreamWriter(fileStream);
            WriteDateToFile(writer, data);

            return true;
        }

        private void WriteDateToFile(TextWriter writer, string? data) {
            writer.WriteLine(data);
        }
    }
}