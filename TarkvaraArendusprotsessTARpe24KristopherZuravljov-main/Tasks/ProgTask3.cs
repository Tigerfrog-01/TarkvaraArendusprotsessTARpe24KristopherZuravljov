using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProgTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var Lister = new Shorterener();
            var Perc = new Listing();
            var Rand = new ReverseFile();
            var Doter = new LibaryBook();
            
            Console.WriteLine("Starting remove every 2 words:");
            Lister.Apple();
            Console.WriteLine("\nStarting randomise");
            Perc.Pear();
            Console.WriteLine("\nStarting Reversing");
            Rand.Grape();
            Console.WriteLine("\nStarting calculate:");
            Doter.Banana();           
        }
    }
}
internal class Shorterener
{
    public void Apple()
    {

        Console.WriteLine(Word("Auto"));

    }

    static string Word(string word)
    {
        if (word.Length < 2)
        {
            return "too short word!";
        }

        string result = string.Empty;

        for (int i = 0; i < word.Length; i += 2)
        {

            result += word[i];

        }

        Console.WriteLine("-------------------");

        return result;
    }
}
internal class Listing
{
    public void Pear()
    {


        {
            string input = "5"; 

            if (int.TryParse(input, out int number))
            {
               
                PrintSquarePattern(number, "answer1.txt");
            }
        }

        static void PrintSquarePattern(int number, string filePath)
        {
            string row = new string(number.ToString()[0], number);

           
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < number; i++)
                {
                    writer.WriteLine(row); 
                }
            }
        }
    }
}
                     
internal class ReverseFile
{
    public void Grape()
    {       
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader("test.txt"))
            using (StreamWriter writer = new StreamWriter("Answer.txt", true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
                list.Reverse();
            writer.WriteLine("Reversed items are:");
                for (int i = 0; i < list.Count; i++)                    
                    writer.WriteLine($"{i + 1}. {list[i]}");

            }
     }
}  
    internal class LibaryBook
    {
        public void Banana()
        {
        Console.WriteLine("Enter amount of books (max 5):");
        string tree = Console.ReadLine();

        int books = int.Parse(tree);

        if (books > 5)
        {
            Console.WriteLine("You can only borrow a maximum of 5 books.");
            return;
        }

        Console.WriteLine("Enter number of days:");
        string sun = Console.ReadLine();
        Console.WriteLine("-------------------------------------------");

        int value = int.Parse(sun);

        if (value <= 21)
        {
            Console.WriteLine("No fine");
        }
        else if (value >= 22 && value <= 30)
        {
            int extraDays = value - 21;
            double fine = extraDays * 0.50 * books;
            Console.WriteLine($"Your fine is {fine:C}");
        }
        else
        {
            int extraDays = value - 21;
            double fine = extraDays * 0.80 * books;
            Console.WriteLine($"Your fine is {fine:C}");
            Console.WriteLine("Membership cancelled");
        }

    }


}

    


