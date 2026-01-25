public class Input_Handler
{
    static string Read_Non_Empty_String(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            PrintError("Input cannot be empty");
        }
    }

    static double Read_Double(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double value))
                return value;

            PrintError("Please enter a valid number (decimal allowed)");
        }
    }


    static int Read_Int_In_Range(string prompt, int min, int max)
    {
        while (true)
        {
            int value = ReadInt(prompt);

            if (value >= min && value <= max)
                return value;

            PrintError($"Enter a number between {min} and {max}");
        }
    }
    static void Print_Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }


}