namespace ProgTask6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Doing bank exercise");

            BankCard card1 = new BankCard();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Adding money");
            card1.AddMoney(1000);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Substracting money");
            card1.SubtractMoney(100);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Printng out card number");
            card1.SetCardNumber("40559075");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            card1.PrintAccountBalance();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Printing out card type ");
            card1.PrintCardType();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Finding diameter and radius now");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Circle 1 is:");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Circle circle1 = new Circle();
            circle1.PrintInfo();
            circle1.SetRadius(5);
            circle1.CalculateArea();
            circle1.CalculateCircumference();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Circle 2 is");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Circle circle2 = new Circle(3);
            circle2.PrintInfo();
            circle2.SetDiameter(10);
            circle2.CalculateArea();
            circle2.CalculateCircumference();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

        }
    }
}
        class BankCard
    {

        private double _accountBalance;
        private string _cardType;
        private string _cardNumber;


        public BankCard()
        {
            _accountBalance = 0;

            _cardType = "Visa";
        }


        public BankCard(double balance, string cardType)
        {

            this._accountBalance = balance;
            this._cardType = cardType;
        }

        public void SetCardNumber(string cardNumber)
        {
            if (cardNumber.Length != 8)
            {
                Console.WriteLine("Invalid value, the length has to be 8!");
            }
            else
            {
                this._cardNumber = cardNumber;
                Console.WriteLine($"Card number is: {cardNumber}");

            }
        }

        public void PrintCardType()
        {
            Console.WriteLine($"Card type: {_cardType}");
        }

        public void PrintAccountBalance()
        {
            Console.WriteLine($"Account balance: {_accountBalance}");
        }


        public double GetAccountBalance()
        {
            return _accountBalance;
        }

        public void AddMoney(double amount)
        {
            _accountBalance += amount;
            Console.WriteLine($"Added {amount} to account. New balance: {_accountBalance}");
        }


        public void SubtractMoney(double amount)

        {
            if (_accountBalance - amount < 0)
            {
                Console.WriteLine("Cannot do this operation, insufficient funds");
            }
            else
            {
                _accountBalance -= amount;
                Console.WriteLine($"Subtracted {amount} from account. New balance: {_accountBalance}");




            }
        }
    }
public class Circle
{

    private double _radius;
    private double _diameter;


    public Circle()
    {

        _radius = 10;
        _diameter = 5;

    }

    public Circle(double radius)
    {
        SetRadius(radius);
    }

    public void PrintInfo()
    {
        if (_radius == 0 && _diameter == 0)
        {
            Console.WriteLine("Values are not set!");
        }
        else
        {

            Console.WriteLine($"Circle radius is {_radius} and circle diameter is {_diameter}");
        }
    }
    public void SetRadius(double radius)
    {
        this._radius = radius;
        this._diameter = radius * 2;
    }


    public void SetDiameter(double diameter)
    {

        this._diameter = diameter;
        this._radius = diameter / 2;
    }


    public void CalculateArea()
    {
        double area = Math.PI * Math.Pow(_radius, 2);
        Console.WriteLine($"Circle area is {Math.Round(area, 2)}");
    }


    public void CalculateCircumference()
    {
        double circumference = 2 * Math.PI * _radius;

        Console.WriteLine($"Circle circumference is {Math.Round(circumference, 2)}");
    }
}
