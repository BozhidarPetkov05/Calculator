using System.Text;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<string> numbers = new List<string>();
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Do you want to calculate something? y/n");
            string decision = Console.ReadLine();
            if (decision == "y")
            {
                Console.WriteLine("Enter an equation");
                Console.WriteLine("Put space between numbers and symbols");
                while ((input = Console.ReadLine()) != "n")
                {
                    numbers.Clear();
                    string[] arguments = input.Split();
                    for (int i = 0; i < arguments.Length; i++)
                    {
                        string current = arguments[i];
                        numbers.Add(current);
                    }
                    if (IsValidInput(numbers) == true)
                    {
                        while (numbers.Contains("/"))
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == "/")
                                {
                                    decimal currentNum = decimal.Parse(numbers[i - 1]) / decimal.Parse(numbers[i + 1]);
                                    numbers.RemoveRange(i - 1, 3);
                                    numbers.Insert(i - 1, currentNum.ToString());
                                }
                            }
                        }
                        while (numbers.Contains("*"))
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == "*")
                                {
                                    decimal currentNum = decimal.Parse(numbers[i - 1]) * decimal.Parse(numbers[i + 1]);
                                    numbers.RemoveRange(i - 1, 3);
                                    numbers.Insert(i - 1, currentNum.ToString());
                                }
                            }
                        }
                        while (numbers.Contains("+"))
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == "+")
                                {
                                    decimal currentNum = decimal.Parse(numbers[i - 1]) + decimal.Parse(numbers[i + 1]);
                                    numbers.RemoveRange(i - 1, 3);
                                    numbers.Insert(i - 1, currentNum.ToString());
                                }
                            }
                        }
                        while (numbers.Contains("-"))
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == "-")
                                {
                                    decimal currentNum = decimal.Parse(numbers[i - 1]) - decimal.Parse(numbers[i + 1]);
                                    numbers.RemoveRange(i - 1, 3);
                                    numbers.Insert(i - 1, currentNum.ToString());
                                }
                            }
                        }
                        
                        Console.WriteLine("Your answer is:");
                        Console.Write(numbers[0]);
                        Console.WriteLine("");
                        Console.WriteLine("Do you want to calculate again? y/n");
                        string option = Console.ReadLine();
                        if (option == "y")
                        {
                            Console.WriteLine("Enter an equation");
                            Console.WriteLine("Put space between numbers and symbols");
                            continue;
                        }
                        else if (option == "n")
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("Goodbye!");
                Console.WriteLine("-------------------------------------------------------------------------");
            }
            else if (decision == "n")
            {
                Console.WriteLine("Goodbye!");
                Console.WriteLine("-------------------------------------------------------------------------");
            }
            
            
        }

        public static bool IsValidInput(List<string> numbers)
        {
            bool isValid = true;
            if (numbers[0] == "*" | numbers[0] == "/" | numbers[0] == "-" | numbers[0] == "+")
            {
                Console.WriteLine("You need to start with a digit!");
                isValid = false;
            }
            if (numbers[numbers.Count - 1] == "*" | numbers[numbers.Count - 1] == "/" | numbers[numbers.Count - 1] == "-" | numbers[numbers.Count - 1] == "+")
            {
                Console.WriteLine("You cannot end the equation with \"*\" or \"/\" or \"+\" or \"-\" !");
                isValid = false;
            }
            if (numbers.Count < 3)
            {
                Console.WriteLine("You need atleast 3 symbols!");
                isValid = false;
            }
            return isValid;
        }
    }
}