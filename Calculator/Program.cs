using System.Reflection.Emit;
using System.Security;
using System.Text;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<string> numbers = new List<string>();
            Dictionary<string, decimal> history = new Dictionary<string, decimal>();
            WelcomeMessage();

            while ((input = Console.ReadLine()) != "Exit")
            {
                numbers.Clear();
                if (input == "History")
                {
                    if (history.Count == 0)
                    {
                        Console.WriteLine("Your history is empty!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Your history is:");
                        Console.WriteLine("");
                        HistoryChecker(history);
                    }
                }
                else if (input == "Help")
                {
                    Help();
                }
                else if (input == "Clear History")
                {
                    if (history.Count > 0)
                    {
                        history.Clear();
                        Console.WriteLine("Your history has been cleaned succsesfully!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Your history is empty!");
                    }
                }
                else
                {
                    string[] arguments = input.Split();
                    for (int i = 0; i < arguments.Length; i++)
                    {
                        string current = arguments[i];
                        numbers.Add(current);
                    }
                    if (IsValidInput(numbers) == true)
                    {
                        try
                        {
                            while (numbers.Contains("*") || numbers.Contains("/"))
                            {
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] == "*")
                                    {
                                        Multiplying(numbers);
                                        break;
                                    }
                                    else if (numbers[i] == "/")
                                    {
                                        Dividing(numbers);
                                        break;
                                    }
                                    
                                }
                            }
                            while (numbers.Contains("+") || numbers.Contains("-"))
                            {
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] == "+")
                                    {
                                        Addition(numbers);
                                        break;
                                    }
                                    else if (numbers[i] == "-")
                                    {
                                        Subraction(numbers);
                                        break;
                                    }
                                }
                            }
                            history.Add(input, decimal.Parse(numbers[0]));

                            Console.WriteLine("Your answer is:");
                            Console.Write(numbers[0]);
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("Do not write letters or different symbols!");
                            Console.WriteLine("");
                            continue;
                        }
                    }
                }
            }
            Console.WriteLine("Goodbye!");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.ReadLine();
        }

        public static void Help()
        {
            Console.WriteLine("");
            Console.WriteLine("======================================= Help ========================================");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Only type numbers and symbols!");
            Console.WriteLine("2. Do not enter symbols different from: * / + -");
            Console.WriteLine("3. If you want to enter a number with more than one digits do not put space!");
            Console.WriteLine("Example:");
            Console.WriteLine("Correct: 22 + 9 / 2");
            Console.WriteLine("Incorrect: 2 2 + 9 / 2");
            Console.WriteLine("4. When you enter the equation put space between every character");
            Console.WriteLine("Example: 1 + 2 * 7");
            Console.WriteLine("5. If you want to enter a number with digital point, use the digital point selected");
            Console.WriteLine("in you regional settings");
            Console.WriteLine("6. To check your calculation history type \"History\"");
            Console.WriteLine("7. To clear your calculation history type \"Clear History\"");
            Console.WriteLine("8. To check the instructions you can scroll or type \"Help\"");
            Console.WriteLine("9. To exit type \"Exit\"");
            Console.WriteLine("=====================================================================================");
            return;
        }

        public static void HistoryChecker(Dictionary<string, decimal> history)
        {
            foreach (KeyValuePair<string, decimal> equation in history)
            {
                Console.WriteLine("Equation:");
                Console.WriteLine(equation.Key);
                Console.WriteLine("Answer:");
                Console.WriteLine(equation.Value);
                Console.WriteLine("----------------------------------");
            }
            return;
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("==================================== Calculator =====================================");
            Console.WriteLine("");
            Console.WriteLine("Welcome to Calculator!");
            Console.WriteLine("");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Only type numbers and symbols!");
            Console.WriteLine("2. Do not enter symbols different from: * / + -");
            Console.WriteLine("3. If you want to enter a number with more than one digits do not put space!");
            Console.WriteLine("Example:");
            Console.WriteLine("Correct: 22 + 9 / 2");
            Console.WriteLine("Incorrect: 2 2 + 9 / 2");
            Console.WriteLine("4. When you enter the equation put space between every character");
            Console.WriteLine("Example: 1 + 2 * 7");
            Console.WriteLine("5. If you want to enter a number with digital point, use the digital point selected");
            Console.WriteLine("in you regional settings");
            Console.WriteLine("6. To check your calculation history type \"History\"");
            Console.WriteLine("7. To clear your calculation history type \"Clear History\"");
            Console.WriteLine("8. To check the instructions you can scroll or type \"Help\"");
            Console.WriteLine("9. To exit type \"Exit\"");
            Console.WriteLine("");
            Console.WriteLine("=====================================================================================");
            return;
        }

        public static void Subraction(List<string> numbers)
        {
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
            return;
        }

        public static void Addition(List<string> numbers)
        {
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
            return;
        }

        public static void Multiplying(List<string> numbers)
        {
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
            return;
        }

        public static void Dividing(List<string> numbers)
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
            return;
        }

        public static bool IsValidInput(List<string> numbers)
        {
            bool isValid = true;
            if (numbers[0] == "*" | numbers[0] == "/" | numbers[0] == "-" | numbers[0] == "+")
            {
                Console.WriteLine("You need to start with a digit!");
                Console.WriteLine("");
                isValid = false;
            }
            if (numbers[numbers.Count - 1] == "*" | numbers[numbers.Count - 1] == "/" | numbers[numbers.Count - 1] == "-" | numbers[numbers.Count - 1] == "+")
            {
                Console.WriteLine("You cannot end the equation with \"*\" or \"/\" or \"+\" or \"-\" !");
                Console.WriteLine("");
                isValid = false;
            }
            if (numbers.Count < 3)
            {
                Console.WriteLine("You need atleast 3 symbols!");
                Console.WriteLine("");
                isValid = false;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (DivisionValidation(numbers, i, isValid) == false)
                {
                    isValid = false;
                    break;
                }
                else if (MultiplicationValidation(numbers, i, isValid) == false)
                {
                    isValid = false;
                    break;
                }
                else if (AdditionValidation(numbers, i, isValid) == false)
                {
                    isValid = false;
                    break;
                }
                else if (SubractionValidation(numbers, i, isValid) == false)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        private static bool SubractionValidation(List<string> numbers, int i, bool isValid)
        {
            if (numbers[i] == "-")
            {
                if (numbers[i - 1] == "*" || numbers[i + 1] == "*")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "/" || numbers[i + 1] == "/")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "+" || numbers[i + 1] == "+")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "-" || numbers[i + 1] == "-")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
            }
            return isValid;
        }

        public static bool AdditionValidation(List<string> numbers, int i, bool isValid)
        {
            if (numbers[i] == "+")
            {
                if (numbers[i - 1] == "*" || numbers[i + 1] == "*")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "/" || numbers[i + 1] == "/")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "+" || numbers[i + 1] == "+")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "-" || numbers[i + 1] == "-")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
            }
            return isValid;
        }

        public static bool DivisionValidation(List<string> numbers, int i, bool isValid)
        {
            if (numbers[i] == "/")
            {
                if (numbers[i - 1] == "*" || numbers[i + 1] == "*")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "/" || numbers[i + 1] == "/")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "+" || numbers[i + 1] == "+")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "-" || numbers[i + 1] == "-")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
            }
            return isValid;
        }

        public static bool MultiplicationValidation(List<string> numbers, int i, bool isValid)
        {
            if (numbers[i] == "*")
            {
                if (numbers[i - 1] == "*" || numbers[i + 1] == "*")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "/" || numbers[i + 1] == "/")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "+" || numbers[i + 1] == "+")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
                else if (numbers[i - 1] == "-" || numbers[i + 1] == "-")
                {
                    Console.WriteLine("Do not enter 2 symbols one after another!");
                    Console.WriteLine("");
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}