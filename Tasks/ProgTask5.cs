using System;
using System.IO;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {


           
            var Checktwice = new FILEIDCHECKER();


            Console.WriteLine("Starting ID checking trough file");
            Checktwice.Run();
            Checktwice.ProcessIDCode("39912222746");
        }
    }
}
internal class FILEIDCHECKER
{

    public void Run()
    {


        string filePath = "IDcode.txt";


        using (StreamReader reader = new StreamReader(filePath))
        {
            string IDcode;
            int count = 1;
            while ((IDcode = reader.ReadLine()) != null)
            {
                Console.WriteLine($"Processing ID Code {count}: {IDcode}");
                ProcessIDCode(IDcode);
                Console.WriteLine("---------------------------------------------------------------------------------------");
                count++;
            }
        }
    }
    public string FindMonth(int result3)
    {
  
        string result = "";
        if (result3 == 1)
        {
            result = ".January";
        }
        else if (result3 == 2)
        {
            result = ".February";
        }
        else if (result3 == 3)
        {
            result = ".March";
        }
        else if (result3 == 4)
        {
            result = ".April";
        }
        else if (result3 == 5)
        {
            result = ".May";
        }
        else if (result3 == 6)
        {
            result = ".June";
        }
        else if (result3 == 7)
        {
            result = ".July";
        }
        else if (result3 == 8)
        {
            result = ".August";
        }
        else if (result3 == 9)
        {
            result = ".September";
        }
        else if (result3 == 10)
        {
            result = ".October";
        }
        else if (result3 == 11)
        {
            result = ".November";
        }
        else if (result3 == 12)
        {
            result = ".December";
        }
        return result;
    }
    public string FindYear(int result2)
    {
        string result = "";
        if (result2 == 1)
        {
            result = "18";
        }
        else if (result2 == 2)
        {
            result = "18";
        }
        else if (result2 == 3)
        {
            result = "19";
        }
        else if (result2 == 4)
        {
            result = "19";
        }
        else if (result2 == 5)
        {
            result = "20";
        }
        else if (result2 == 6)
        {
            result = "20";
        }
        else if (result2 == 7)
        {
            result = "21";
        }
        else if (result2 == 8)
        {
            result = "21";
        }
        return result;

    }


    public string FindHospital(int value)
    {
        string result = "";
        if (value >= 421 & value <= 470)
        {
            result = "Hospital is Pärnu";
        }
        else if (value >= 371 & value <= 420)
        {
            result = "Hospital is Narva";
        }
        else if (value >= 271 & value <= 370)
        {
            result = "Maarjamõisa kliinikum (Tartu), Jõgeva haigla";
        }
        else if (value >= 221 & value <= 270)
        {
            result = "Ida-Viru keskhaigla (Kohtla-Järve, endine Jõhvi)";
        }
        else if (value >= 161 & value <= 220)
        {
            result = "Rapla haigla, Loksa haigla, Hiiumaa haigla (Kärdla)";
        }
        else if (value >= 151 & value <= 160)
        {
            result = "Keila haigla";
        }
        else if (value >= 021 & value <= 150)
        {
            result = "Ida-Tallinna keskhaigla, Pelgulinna sünnitusmaja (Tallinn)";
        }
        else if (value >= 011 & value <= 019)
        {
            result = "Tartu Ülikooli Naistekliinik";
        }
        else if (value >= 001 & value <= 010)
        {
            result = "Kuressaare haigla";
        }
        else if (value >= 471 & value <= 490)
        {
            result = "Haapsalu haigla";
        }
        else if (value >= 491 & value <= 520)
        {
            result = "Järvamaa haigla";
        }
        else if (value >= 521 & value <= 570)
        {
            result = "Rakvere haigla, Tapa haigla";
        }
        else if (value >= 571 & value <= 600)
        {
            result = " Valga haigla";
        }
        else if (value >= 601 & value <= 650)
        {
            result = "Viljandi haigla";
        }
        else if (value >= 651 & value <= 700)
        {
            result = "Lõuna-Eesti haigla (Võru), Põlva haigla";
        }
        return result;

    }
    

    public void ProcessIDCode(string IDcode)
    {
        // Checking control Nr
        string change = IDcode.Substring(10);
        Console.WriteLine("Control Nr: " + change);

        // Checking birth nr
        string change1 = IDcode.Substring(9,1);    
        Console.WriteLine("Birth nr: " + change1);

        // Checking hospital location
        string change3 = IDcode.Substring(7,2);        
        int value = int.Parse(change3);
        string hospitalLoc = FindHospital(value);
        Console.WriteLine(hospitalLoc);

        // Checking gender
        string change5 = IDcode.Substring(0,1);         
        int result = int.Parse(change5);
        switch (result)
        {
            case 1:
            case 3:
            case 5:
            case 7:
                Console.WriteLine("He is man");
                break;
            case 2:
            case 4:
            case 6:
            case 8:
                Console.WriteLine("She is woman");
                break;
        }

        // Checking Birthdate

        // Year first
      
        string year = IDcode.Substring(1,2);       
        int result1 = int.Parse(year);
        int result2 = int.Parse(change5);
        string BirthYear = FindYear(result2);
        Console.Write(BirthYear);
        Console.Write(result1 + ".");

        // Extract day
        string change9 = IDcode.Substring(5,2);     
        Console.Write(change9);

        // Determine month
        string change11 = IDcode.Substring(3,1);      
        int result3 = int.Parse(change11);
        string MonthDate = FindMonth(result3);
        Console.WriteLine(MonthDate);  
    }
}