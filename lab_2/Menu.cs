using System.Data;

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
            Console.WriteLine("This is the second laboratory task of the first variation. " +
                              Environment.NewLine +
                              "The author is Levon Abramyan, Group 404, Course 2nd");

            Console.WriteLine("The problem is:");
            Console.WriteLine("Implement Caesar cipher and AES");
            Console.WriteLine();
        }

        public void PrintMenu() {
            Console.WriteLine("");
            Console.WriteLine("Enter 1 to read data from console.");
            Console.WriteLine("Enter 2 to read data from file.");
            Console.WriteLine("Enter 3 to set random number.");
            Console.WriteLine("Enter 0 to exit.");
        }

        public void PrintMenuForOperation() {
            Console.WriteLine("");
            Console.WriteLine("Enter 1 to encode data");
            Console.WriteLine("Enter 2 to decode data");
            Console.WriteLine("Enter 3 to save encoding data");
            Console.WriteLine("Enter 4 to save decoding data");
            Console.WriteLine("Enter 0 to back.");
        }

        public void PrintMenuForChoice() {
            Console.WriteLine("");
            Console.WriteLine("Enter 1 to choose AES cipher");
            Console.WriteLine("Enter 2 to choose Caesar cipher");
            Console.WriteLine("Enter 0 to back.");
        }

        public void CipherOperationInterface(ICipher cipher, Data data) {
            bool isRestart = true;
            do {
                PrintMenuForOperation();
                CipherOperationChoice cipherOperationChoice = (CipherOperationChoice) Input.GetNumber();
                switch (cipherOperationChoice) {
                    case CipherOperationChoice.Back:
                        Console.WriteLine("The data will be lost!");
                        isRestart = false;
                        break;
                    case CipherOperationChoice.Encode: {
                        Console.WriteLine(cipher.Encode(data));
                        break;
                    }
                    case CipherOperationChoice.Decode:
                        //Console.WriteLine("Enter number to delete from the tree");
                        break;
                    case CipherOperationChoice.SaveResult:
                        break;
                    default:
                        Console.WriteLine("Please, enter a number between" +
                                                 $"{(int) CipherOperationChoice.Back} and {(int) CipherOperationChoice.SaveResult}");
                        break;
                }
            } while (isRestart);
        }

        public void CipherChoiceInterface(Data data) {
            bool isRestart = true;
            do {
                PrintMenuForChoice();
                CipherChoice cipherChoice = (CipherChoice) Input.GetNumber();
                ICipher cipher;
                switch (cipherChoice) {
                    case CipherChoice.Back:
                        Console.WriteLine("The data will be lost!");
                        isRestart = false;
                        break;
                    case CipherChoice.AES:
                        break;
                    case CipherChoice.Caesar:
                        cipher = new CaesarСipher();
                        CipherOperationInterface(cipher, data);
                        break;
                    default:
                        Console.WriteLine("Please, enter a number between" +
                                          $"{(int) CipherChoice.Back} and {(int) CipherChoice.Caesar}");
                        continue;


                }
            } while (isRestart);
        }
        public void InterfaceMenu() {
            bool isRestart = true;
            do {
                PrintMenu();
                MenuChoices choice = (MenuChoices) Input.GetNumber();
                switch (choice) {
                    case MenuChoices.Exit:
                        Console.WriteLine("Your choice is EXIT");
                        Console.WriteLine("The program will be closed");
                        isRestart = false;
                        break;

                    case MenuChoices.Console:
                        Console.WriteLine("Your choice is CONSOLE");
                        Data data = Input.getData();
                        CipherChoiceInterface(data);
                        break;

                    case MenuChoices.Files:
                        Console.WriteLine("Your choice is FILES");
                        break;

                    case MenuChoices.Random:
                        Console.WriteLine("Your choice is RANDOM");
                        break;
                    default:
                        Console.WriteLine($"Please, enter a number between {(int) MenuChoices.Exit} and {(int) MenuChoices.Random}");
                        continue;
                }


            } while (isRestart);
        }
    }
}
