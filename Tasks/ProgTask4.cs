namespace ProgTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {

           var money = new Interest();

           var code = new Prank();

           var med = new MedAri();

           var bank = new Bankcalc();

           var sal = new Salarycalc();

           Console.WriteLine("Starting calculate interest rate:");
           money.First();

           Console.WriteLine("\nStarting to fix the damage done trough prank");
           code.Second();

           Console.WriteLine("\nStarting find Median and Arithemetic");
           med.Third();

           Console.WriteLine("\nStarting calculate bank stuff:");
           bank.Fourth();

           Console.WriteLine("\nStarting to cook salary:");
           sal.Fifth();

        }
    }
}
internal class Interest
{
    public void First()
    {

        double principal = 2200;
        double interestRate = 0.021;
        int years = 1;

        double finalAmount = FindCompoundInterest(principal, interestRate, years);

        Console.WriteLine($"The final amount after {years} years is {finalAmount:F2}");
    }

    static double FindCompoundInterest(double principal, double interestRate, int years)
    {
        for (int i = 0; i < years; i++)
        {
            double interest = principal * interestRate;
            principal += interest;
        }
        return principal;
    }
}

internal class Prank
{
    public void Second()
    {
        string beginningsFile = "file.txt";
        string endingsFile = "half.txt";
        string resultFile = "full.txt";


        List<string> beginnings = new List<string>();
        List<string> endings = new List<string>();
        List<string> fullIds = new List<string>();


        using (StreamReader srBeginnings = new StreamReader(beginningsFile))
        {
            string line;
            while ((line = srBeginnings.ReadLine()) != null)
            {
                beginnings.Add(line.Trim());
            }
        }


        using (StreamReader srEndings = new StreamReader(endingsFile))
        {
            string line;
            while ((line = srEndings.ReadLine()) != null)
            {
                endings.Add(line.Trim());
            }
        }


        foreach (string beginning in beginnings)
        {
            int requiredEndingLength = 11 - beginning.Length;


            foreach (string ending in endings)
            {
                if (ending.Length == requiredEndingLength)
                {
                    string fullId = beginning + ending;
                    fullIds.Add(fullId);
                    endings.Remove(ending);
                    break;
                }
            }
        }


        using (StreamWriter sw = new StreamWriter(resultFile))
        {
            foreach (string fullId in fullIds)
            {
                sw.WriteLine(fullId);
            }
        }

        Console.WriteLine("ID codes have been restored and saved to " + resultFile);

    }
}
internal class MedAri
{
    public void Third()
    {

        var list = new int[] { 3, 3, 5, 9, 11 };


        FindMedianAndMean(list);
    }


    static void FindMedianAndMean(int[] numbers)
    {

        var sortedNumbers = numbers.OrderBy(n => n).ToArray();


        double median;
        int length = sortedNumbers.Length;

        if (length % 2 == 1)

        {

            median = sortedNumbers[length / 2];
        }

        else
        {

            median = (sortedNumbers[length / 2 - 1] + sortedNumbers[length / 2]) / 2.0;
        }


        double mean = sortedNumbers.Average();


        Console.WriteLine($"List: {string.Join(", ", numbers)}");

        Console.WriteLine($"Median: {median}");

        Console.WriteLine($"Arithmetic Mean: {mean}");

    }
}
internal class Bankcalc
{
    public void Fourth()

    {
        {

            Console.WriteLine(GetMoneyInfo("207"));
        }

        static string GetMoneyInfo(string amount)
        {

            int euros = 0, cents = 0;

            if (amount.Length == 3)

            {
                euros = int.Parse(amount.Substring(0, 1));

                cents = int.Parse(amount.Substring(1, 2));

            }
            else if (amount.Length == 2)
            {

                cents = int.Parse(amount);

            }
            else if (amount.Length == 1)
            {
                cents = int.Parse(amount);
            }


            string result = "";


            if (euros > 0)
            {
                if (euros == 1)
                    result += "1 euro";
                else
                    result += euros + " eurot";
            }


            if (cents > 0)
            {
                if (euros > 0)

                    result += " ja ";

                if (cents == 1)

                    result += "1 sent";

                else

                    result += cents + " senti";
            }


            if (euros == 0 && cents == 0)


            {
                result = "0 senti";

            }

            return result;
        }
        }
}
internal class Salarycalc
{
    public void Fifth()
    {
        string inputFilePath = "raw.txt";

        string outputFilePath = "cooked.txt";

        try
        {

            var inputLines = File.ReadAllLines(inputFilePath);

            var outputLines = new System.Collections.Generic.List<string>();

            decimal totalNetSalary = 0;



            foreach (var line in inputLines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmedLine))
                    continue;

                if (trimmedLine.StartsWith("G") && trimmedLine.Length > 1)
                {

                    if (decimal.TryParse(trimmedLine.Substring(1).Trim(), out decimal grossSalary))
                    {
                        decimal netSalary = grossSalary - (grossSalary * 0.25M);
                        outputLines.Add(netSalary.ToString());
                        totalNetSalary += netSalary;

                    }
                    else

                    {
                        outputLines.Add("invalid: " + trimmedLine);

                    }
                }
                else if (trimmedLine.StartsWith("N") && trimmedLine.Length > 1)

                {

                    if (decimal.TryParse(trimmedLine.Substring(1).Trim(), out decimal netSalary))


                    {
                        outputLines.Add(netSalary.ToString());

                        totalNetSalary += netSalary;
                    }
                    else
                    {
                        outputLines.Add("invalid: " + trimmedLine);

                    }
                }
                else
                {

                    outputLines.Add("invalid: " + trimmedLine);

                }
            }


            outputLines.Add("Sum is: " + totalNetSalary.ToString());



            File.WriteAllLines(outputFilePath, outputLines);


            Console.WriteLine("Salary data processing is cooked. Check the cooked file.");
        }
        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }
}          