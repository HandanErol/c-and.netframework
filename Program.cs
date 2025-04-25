using System;

// Main program class that serves as the entry point
class Program
{
    // Constants for validation
    private const double MaxWeight = 50;
    private const double MaxDimensions = 50;

    static void Main(string[] args)
    {
        try
        {
            ProcessShippingQuote();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Main method to process the shipping quote
    static void ProcessShippingQuote()
    {
        // Display welcome message
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Get and validate package weight
        double weight = GetValidatedInput("Please enter the package weight:");
        if (weight > MaxWeight)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }

        // Get package dimensions
        double width = GetValidatedInput("Please enter the package width:");
        double height = GetValidatedInput("Please enter the package height:");
        double length = GetValidatedInput("Please enter the package length:");

        // Validate total dimensions
        double totalDimensions = width + height + length;
        if (totalDimensions > MaxDimensions)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }

        // Calculate and display shipping quote
        double quote = CalculateShippingQuote(weight, width, height, length);
        DisplayQuote(quote);
    }

    // Helper method to get and validate numeric input
    static double GetValidatedInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            if (double.TryParse(Console.ReadLine(), out double value))
            {
                if (value <= 0)
                {
                    Console.WriteLine("Please enter a positive number.");
                    continue;
                }
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }

    // Calculate shipping quote based on package dimensions and weight
    static double CalculateShippingQuote(double weight, double width, double height, double length)
    {
        return (width * height * length * weight) / 100;
    }

    // Display the calculated shipping quote
    static void DisplayQuote(double quote)
    {
        Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
        Console.WriteLine("Thank you!");
    }
}