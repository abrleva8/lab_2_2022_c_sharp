namespace lab_2 {
    class ConsoleInput : Input {
        public static bool IsChoiceYes() {
            string? save = Console.ReadLine();
            while (save != null && save.CompareTo("y") != 0 && save.CompareTo("n") != 0) {
                Console.WriteLine("Wrong input. Try again.");
                save = Console.ReadLine();
            }
            return save != null && save.CompareTo("y") == 0;
        }
    }
}