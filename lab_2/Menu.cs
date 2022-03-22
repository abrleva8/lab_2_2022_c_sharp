namespace lab_2 {
    class Menu {
        public enum MenuChoices {
            Exit,
            Console,
            Files,
            Random
        }

        public enum CipherChoice {
            Back,
            AES,
            Caesar,
        }

        public enum CipherOperationChoice {
            Back,
            Encode,
            Decode,
            SaveResult,
        }

        public void Greeting() {
            Console.WriteLine("This is the first variation of the second laboratory task" +
                              Environment.NewLine +
                              "The author is Levon Abramyan, Group 404, Course 2nd");

            Console.WriteLine("The problem is:");
            Console.WriteLine("Implement Caesar cipher and AES");
            Console.WriteLine();
        }

        public void PrintMenu(string information="data", string zeroOption="exit") {
            Console.WriteLine("");
            Console.WriteLine($"Enter 1 to read {information} from console.");
            Console.WriteLine($"Enter 2 to read {information} from file.");
            Console.WriteLine($"Enter 3 to set random {information}.");
            Console.WriteLine($"Enter 0 to {zeroOption}.");
        }

        public void PrintMenuForOperation() {
            Console.WriteLine("");
            Console.WriteLine("Enter 1 to encode data");
            Console.WriteLine("Enter 2 to decode data");
            Console.WriteLine("Enter 3 to save result");
            Console.WriteLine("Enter 0 to back.");
        }

        public void PrintMenuForChoice() {
            Console.WriteLine("");
            Console.WriteLine("Enter 1 to choose AES cipher");
            Console.WriteLine("Enter 2 to choose Caesar cipher");
            Console.WriteLine("Enter 0 to back.");
        }
        public void CipherOperationInterface(ICipher cipher) {
            bool isRestart = true;
            bool? isToByte = null;
            do {
                PrintMenuForOperation();
                CipherOperationChoice cipherOperationChoice = (CipherOperationChoice) Input.GetNumber();
                FileOutput fo = new FileOutput();
                Data? data = null;
                switch (cipherOperationChoice) {
                    case CipherOperationChoice.Back: {
                        string? key = cipher.Key;
                        fo.SaveData(key, "key");
                        isRestart = false;
                    }
                        break;
                    case CipherOperationChoice.Encode: {
                        data = cipher.Encode();
                        isToByte = true;
                        BytesWorker.DisplayBytes(data!.Str, "message");
                        break;
                    }
                    case CipherOperationChoice.Decode: {
                        data = cipher.Decode();
                        isToByte = false;
                        BytesWorker.DisplayBytes(data!.Str, "message");
                        break;
                    }
                    case CipherOperationChoice.SaveResult: {
                        if (isToByte != null) {
                            string? key = cipher.Key;

                            fo.SaveData(key, "key", isToByte);

                            string? message = cipher.Message;

                            fo.SaveData(message, "message", isToByte);

                        } else {
                            Console.WriteLine("First, you should encoding or decoding the data!");
                        }
                    }
                        break;
                    default:
                        Console.WriteLine("Please, enter a number between " +
                                                 $"{(int) CipherOperationChoice.Back} and {(int) CipherOperationChoice.SaveResult}");
                        break;
                }
            } while (isRestart);
        }

        public void KeyChoiceInterface(ICipher cipher) {
            bool isRestart = true;
            do {
                PrintMenu("key", "back");
                MenuChoices choice = (MenuChoices) Input.GetNumber();
                switch (choice) {
                    case MenuChoices.Exit:
                        Console.WriteLine("Your choice is back!");
                        isRestart = false;
                        break;

                    case MenuChoices.Console: {
                        Console.WriteLine("Your choice is CONSOLE");
                        cipher.SetKey();
                        Console.WriteLine($"Key is {cipher.Key}");
                        CipherOperationInterface(cipher);
                    }
                        break;

                    case MenuChoices.Files:
                        Console.WriteLine("Your choice is FILES");
                        FileInput fileInput = new FileInput();
                        string? key = null;
                        bool isRead = fileInput.Read(ref cipher, ref key);
                        cipher.Key = key;
                        if (isRead) {
                            Console.WriteLine("Key is read.");
                            Console.WriteLine($"Key is {key}");
                        } else {
                            continue;
                        }
                        CipherOperationInterface(cipher);
                        break;

                    case MenuChoices.Random: {
                        Console.WriteLine("Your choice is RANDOM");
                        cipher.SetKey(true);
                        Console.WriteLine($"Key is {cipher.Key}");
                        CipherOperationInterface(cipher);
                    }
                        break;
                    default:
                        Console.WriteLine($"Please, enter a number between {(int) MenuChoices.Exit} and {(int) MenuChoices.Random}");
                        continue;
                }


            } while (isRestart);
        }

        public void CipherChoiceInterface(string? message) {
            bool isRestart = true;
            do {
                PrintMenuForChoice();
                CipherChoice cipherChoice = (CipherChoice) Input.GetNumber();
                ICipher cipher;
                FileOutput fo = new FileOutput();
                switch (cipherChoice) {
                    case CipherChoice.Back:
                        Console.WriteLine("The data will be lost!");
                        fo.SaveData(message, "message");
                        isRestart = false;
                        break;
                    case CipherChoice.AES:
                        Console.WriteLine("Your choice is AES");
                        cipher = new AES(message);
                        KeyChoiceInterface(cipher);
                        break;
                    case CipherChoice.Caesar:
                        Console.WriteLine("Your choice is Caesar");
                        cipher = new CaesarСipher(message);
                        KeyChoiceInterface(cipher);
                        break;
                    default:
                        Console.WriteLine("Please, enter a number between " +
                                          $"{(int) CipherChoice.Back} and {(int) CipherChoice.Caesar}");
                        continue;


                }
            } while (isRestart);
        }
        
        public void InterfaceMenu() {
            bool isRestart = true;
            do {
                PrintMenu("string");
                MenuChoices choice = (MenuChoices) Input.GetNumber();
                string? message = "";
                switch (choice) {
                    case MenuChoices.Exit:
                        Console.WriteLine("Your choice is EXIT");
                        Console.WriteLine("The program will be closed");
                        isRestart = false;
                        break;

                    case MenuChoices.Console: {
                        Console.WriteLine("Your choice is CONSOLE");
                        do {
                            message = Input.GetString();}
                        while (!Input.IsGoodMessage(message));
                        Console.WriteLine($"Message is {message}");
                        CipherChoiceInterface(message);
                    }
                        break;

                    case MenuChoices.Files: {
                        Console.WriteLine("Your choice is FILES");
                        FileInput fileInput = new FileInput();
                        bool isRead = fileInput.Read(ref message);
                        if (isRead) {
                            Console.WriteLine("Message is read");
                            Console.WriteLine($"Message is: {message}");
                        } else {
                            continue;
                        }

                        CipherChoiceInterface(message);
                    }
                        break;

                    case MenuChoices.Random: {
                        Console.WriteLine("Your choice is RANDOM");
                        message = Data.GetRandomString();
                        Console.WriteLine(message);
                        CipherChoiceInterface(message);
                    }
                        break;
                    default:
                        Console.WriteLine($"Please, enter a number between {(int) MenuChoices.Exit} and {(int) MenuChoices.Random}");
                        continue;
                }
            } while (isRestart);
        }
    }
}