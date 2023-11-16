using System;
using System.Data;
using System.Globalization;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;



//Create Action Class Of The Calculator.
public class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b != 0)
        {
            return (double) a / b;
        }
        else
        {
            throw new ArgumentException("Cannot Divide By Zero.");
        }
    }

}


//Create User Input Class.
public class UserInput
{
    public static double GetEnteredNumber(string userPrompt)
    {
        string[] quitSignals = { "q", "Q" };

        Console.Write(userPrompt);
        string input = Console.ReadLine();

        if (quitSignals.Contains(input, StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("Calculator Is Exiting");
            Environment.Exit(0); // Exit the application
        }

        if (double.TryParse(input, out double number))
        {
            return number;
        }
        else
        {
            Console.WriteLine("Invalid Input, Please Enter A Valid Number");
            return GetEnteredNumber(userPrompt);
        }
    }

    public static string GetEnteredOperator()
    {
        Console.Write("Choose An Operation (+, -, *, /): ");
        return Console.ReadLine();
    }
}





class Program
{
    static void Main()
    {
        Console.WriteLine("Simple Console Calculator \n\nEnter Digit Or 'q' To Exit.\n");
        
        Calculator calculator = new Calculator();


        string[] quitSignals = { "q", "Q" };


        double firstNumber;
        double secondNumber;



        while (true)
        {

            firstNumber = UserInput.GetEnteredNumber("First Digit: ");
            secondNumber = UserInput.GetEnteredNumber("Second Digit: ");
            string operation = UserInput.GetEnteredOperator();



            if (quitSignals.Contains(firstNumber.ToString()) || quitSignals.Contains(secondNumber.ToString()))
            {
                Console.WriteLine("Calculator Is Exiting");
                break;
            }
            switch (operation)
            {
                case "+":
                    Console.WriteLine($"Result: {calculator.Add(firstNumber, secondNumber)}");
                    break;

                case "-":
                    Console.WriteLine($"Result: {calculator.Subtract(firstNumber, secondNumber)}");
                    break;

                case "*":
                    Console.WriteLine($"Result: {calculator.Multiply(firstNumber, secondNumber)}");
                    break;

                case "/":
                    try
                    {
                        Console.WriteLine($"Result: {calculator.Divide(firstNumber, secondNumber)}");
                    }
                    catch (ArgumentException ExErr)
                    {
                        Console.WriteLine($"Error: {ExErr.Message}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Operation");
                    break;

            }
        }
    }
}

