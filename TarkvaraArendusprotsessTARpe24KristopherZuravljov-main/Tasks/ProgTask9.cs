
using System;

namespace ConsoleApp1

{
    internal class Program
    {
        static void Main(string[] args)
        {


            VATCalc VAT = new VATCalc();
            VAT.FindVATFromPrice(20);
            VAT.FindPrice(true, 20);
            VAT.FindPriceBasedOnTax(4);
            VAT.IsTaxPercent20(true);

          
        }


    }
    public class VATCalc
    {
        public double _VATPerc = 20.0;
        public double _Value;
        
        public VATCalc()
        {
        }

        public VATCalc(double VATPercentage, double Price)
        {
            this._VATPerc = VATPercentage;
            this._Value = Price;
        }

        public double FindVATFromPrice(double price)
        {
            double VATPercentage = _VATPerc;
            double Transfrom = VATPercentage / 100;
            double VATprice = Transfrom * price;
            double WithoutVat = price - VATprice;
            Console.WriteLine("VAT is:" + VATprice);
            return price;
        }
        public bool FindPrice(bool YesorNo, double price)
        {

            if (YesorNo)
            {
                
                double tax = 1 + _VATPerc / 100;

                double result = (price / tax);

                result = Math.Ceiling(result * 100) / 100;

                Console.WriteLine(result);

                return true;
            }

            else

            {
                double Transfrom = -_VATPerc / 100;

                double VATprice = Math.Abs(Transfrom * price);

                double PriceWithVat = price + VATprice;   
                
                Console.WriteLine("With tax is: " + PriceWithVat);

                return false;
            }

        }
        public double FindPriceBasedOnTax(double tax)
        {

            double FindPrice = 0.166667;
            double WithVAT = tax / FindPrice;


            Console.WriteLine("Price is: " + (Math.Round(WithVAT, 2) - tax));
            return tax;
        }
        public bool IsTaxPercent20(bool sure)
        {
            if (sure)
            {
                Console.WriteLine(Math.Abs(_VATPerc - 20.0)
                     < 0.0001);
                return true;
            }
            else
            {

                Console.WriteLine("Its not 20 percents apparently ");
                return false;
               
            }



        }
    }
}


    public class Cat()
    {
        public bool CatIsPlaying(bool isSummer, int temp)
        {


            if (isSummer)
            {
                return temp >= 25 && temp <= 45;
            }
            else
            {

                return temp >= 25 && temp <= 35;

            }


        }


    }



    
    


 

