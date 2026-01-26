public class Input_Handler
{
    public static string Read_Non_Empty_String(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Print_Error("Input cannot be empty");
        }
    }

    public static double Read_Double(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double value))
                return value;

            Print_Error("Please enter a valid number (decimal allowed)");
        }
    }


    public static int Read_Int_In_Range(string prompt, int min, int max)
    {
        while (true)
        {
            int value = ReadInt(prompt);

            if (value >= min && value <= max)
                return value;

            Print_Error($"Enter a number between {min} and {max}");
        }
    }
    public static void Print_Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }


}