using System;
using System.Collections.Generic;

namespace ProgTask1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var calculator = new Calc();
            var quizGame = new Quiz();
            var TrueorFalse = new TrueFalse();
            var Floater = new Floater();
            var Age = new Age();

            Console.WriteLine("--- Starting Calculator ---");
            Console.WriteLine("Enter two numbers:");
            calculator.Run();

            Console.WriteLine("\n--- Starting Quiz Game ---");
            quizGame.Run();

            Console.WriteLine("\n--- Starting True or False ---");
            TrueorFalse.Run();

            Console.WriteLine("\n--- Starting Floating Check ---");
            Console.WriteLine("Enter a decimal (e.g., 4.5):");
            Floater.Run();

            Console.WriteLine("\n--- Age Checking ---");
            Console.WriteLine("Enter your age:");
            Age.Run();
        }
    }

    internal class Calc 
    {
        public void Run()
        {
            try 
            {
                string number = Console.ReadLine();
                string number1 = Console.ReadLine();
                int value = int.Parse(number);
                int value2 = int.Parse(number1);

                Add2Numbers(value, value2);
                Console.WriteLine($"Subtraction: {value - value2}");
                Console.WriteLine($"Division: {(value2 != 0 ? (value / (float)value2).ToString() : "Cannot divide by zero")}");
                Console.WriteLine($"Multiplication: {value * value2}");
            }
            catch { Console.WriteLine("Invalid input. Please enter integers."); }
        }

        public void Add2Numbers(int number1, int number2)
        {
            Console.WriteLine($"Sum: {number1 + number2}");
        }
    }

    internal class Quiz
    {
        public void Run()
        {
            Console.WriteLine("Welcome to quiz with 3 questions");
            Console.WriteLine("Number 1: Which answer is true about Napoleon Bonaparte");
            Console.WriteLine("A: He was French");
            Console.WriteLine("B: He was Italian");
            Console.WriteLine("C: He was German");
            Console.WriteLine("--------------------------------------------------------------------------");          

            string input = Console.ReadLine()?.ToLower();
            Console.WriteLine("--------------------------------------------------------------------------");
            if (input == "b")           
            {
                Console.WriteLine("You are indeed correct! Even if he was born in Corsica, he had Italian roots.");
            }
            else
            {
                Console.WriteLine("Incorrect. B is the valid answer.");
            }
        }
    }

    internal class TrueFalse
    {
        public void Run()
        {
            int score = 0;
            Console.WriteLine("True or False Quiz");
            
            Console.WriteLine("Platypus is a mammal (true/false):");
            if (Console.ReadLine()?.ToLower() == "true") {
                Console.WriteLine("Correct! Even though it lays eggs, it's a mammal.");
                score++;
            } else { Console.WriteLine("Incorrect."); }

            Console.WriteLine("Was Petersburg named after Peter the First? (true/false):");
            if (Console.ReadLine()?.ToLower() == "true") {
                Console.WriteLine("Correct!");
                score++;
            } else { Console.WriteLine("Incorrect."); }

            Console.WriteLine("Was Queen Victoria 170cm tall? (true/false):");
            if (Console.ReadLine()?.ToLower() == "false") {
                Console.WriteLine("Correct! She was only 147cm tall.");
                score++;
            } else { Console.WriteLine("Incorrect."); }

            Console.WriteLine($"Total score: {score}");
        }
    }

    internal class Floater
    {
        public void Run()
        {
            try {
                string input = Console.ReadLine();
                float leaf = float.Parse(input);       
                Console.WriteLine($"Value: {leaf}");
                Console.WriteLine($"Type: {leaf.GetType().Name} (Single means Float)");
            } catch { Console.WriteLine("Invalid float input."); }
        }
    }

    internal class Age
    {
        public void Run()
        {
            try {
                int value1 = int.Parse(Console.ReadLine());
                if (value1 < 13)
                    Console.WriteLine("Naudi oma lapsepõlve!");
                else if (value1 <= 19)
                    Console.WriteLine("Need on mõned mässulised teismeliseaastad!");
                else if (value1 < 65)
                    Console.WriteLine("Tere tulemast täiskasvanud elu!");
                else
                    Console.WriteLine("Haara kinni oma kuldaastate tarkusest!");
            } catch { Console.WriteLine("Invalid age input."); }
        }
    }
}