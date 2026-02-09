using System;
using System.Collections.Generic; 

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var Lister = new List();
            var Perc = new Per();
            var Rand = new moon();
            var Doter = new Sun();
            var Guess = new Jupiter();
            Console.WriteLine("Starting Percentage:");
            Perc.Percentage();
            Console.WriteLine("\nStarting List:");
            Lister.Apple();
            Console.WriteLine("\nStarting List:");
            Rand.Random();
            Console.WriteLine("\nStarting List:");
            Doter.Dot();
            Console.WriteLine("\nStarting List:");
            Guess.Gue();



        }
    }
    internal class List
    {

        public void Apple()
        {

            List<string> lst = new List<string>();


            lst.Add(Console.ReadLine());
            lst.Add(Console.ReadLine());
            lst.Add(Console.ReadLine());
            lst.Sort();
            Console.WriteLine("-----------------------------------------");


            foreach (string word in lst)
            {
                Console.WriteLine(word);




            }
        }
    }
        internal class Per
        {

            public void Percentage()
            {
                var Perc = new Per();

                Console.WriteLine("Insert Number");
                string tree = Console.ReadLine();
                double value1 = int.Parse(tree);
                Console.WriteLine("Insert Percentage");
                string grass = Console.ReadLine();
                double value2 = int.Parse(grass);
                Console.WriteLine("Result");
                Console.WriteLine(value1 * value2 / 100);












            }

        }
    }
       internal class moon
{
     public void Random()
    {

        int size = 10;
        int result = CreateRandomListAndSum(size);
        Console.WriteLine("Sum of all items: " + result);
    }

    static int CreateRandomListAndSum(int size)
    {

        Random rand = new Random();


        List<int> randomNumbers = new List<int>();


        for (int i = 0; i < size; i++)
        {
            randomNumbers.Add(rand.Next(1, 101));
        }


        Console.WriteLine("Generated Random Numbers:");
        foreach (int number in randomNumbers)
        {
            Console.WriteLine(number);
        }


        int sum = 0;
        foreach (int number in randomNumbers)
        {
            sum += number;
        }

        return sum;



    }
}
        

    internal class Sun
    {
        public void Dot()
        {

            for (int i = 7; i >= 1; --i)
            {
                for (int j = 1; j <= i; ++j)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }


        }



    }
internal class Jupiter
{
    public void Gue()
    {
             
            Random random = new Random();

            int returnValue = random.Next(1, 11);

            int Guess = 0;

            Console.WriteLine("I am thinking of a number between 1-10. Can you guess what it is?");

            while (Guess != returnValue)
            {
               
                string input = Console.ReadLine();

                
                if (int.TryParse(input, out Guess))
                {
                    if (Guess < returnValue)
                    {
                        Console.WriteLine("No, the number I am thinking of is higher than " + Guess + ". Try again!");
                    }
                    else if (Guess > returnValue)
                    {
                        Console.WriteLine("No, the number I am thinking of is lower than " + Guess + ". Try again!");
                    }
                    else
                    {
                        Console.WriteLine("Well done! The answer was " + returnValue);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }


























