using System;
using System.Collections.Generic;
using System.Threading;

namespace MID_PROJ
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {  
                Data.Call_Data(); 
                Log_Views.Home_Page();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("A critical error occurred: an object was not initialized.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid argument provided.");
                Console.WriteLine($"Details: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Error type: {ex.GetType()}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("\nApplication has terminated. Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
