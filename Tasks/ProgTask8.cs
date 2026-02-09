using System.Reflection.Emit;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main()
        {
            var normalBall = new Normal("Addidas");
            var youthBall = new Youth("Nike");

            Random random = new Random();


            int normalGoals = 0, normalMisses = 0;
            int youthGoals = 0, youthMisses = 0;
            int normalOut = 0,  youthOut = 0;
            
            for (int i = 0; i < 20; i++)
            {
                double randomCoordinate = random.Next(-50, 50);
                double ballRadius = normalBall.Diameter / 2;

                if (normalBall.IsGoal(randomCoordinate, 45, ballRadius))
                    normalGoals++;
                else
                    normalMisses++;

                if (randomCoordinate < -45.7)
                normalOut++;
                if (randomCoordinate > 45.7)
                normalOut++;



                ballRadius = youthBall.Diameter / 2;

                if (youthBall.IsGoal(randomCoordinate, 45, ballRadius))
                    youthGoals++;
                else
                    youthMisses++;

                if (randomCoordinate  < -45.7)
                    youthOut++;
                if (randomCoordinate > 45.7)
                    youthOut++;

            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Normal Ball - Goals: {normalGoals}, Misses: {normalMisses}, Out:{normalOut} ");
            Console.WriteLine($"Youth Ball - Goals: {youthGoals}, Misses: {youthMisses}, Out {youthOut} ");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");


            for (int i = 0; i < 10; i++)
            {
                double start = random.Next(-45, 46);
                double end = random.Next(-45, 46);
                double time = random.Next(1, 11);
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Normal Ball Speed: {normalBall.CalculateAverageSpeed(start, end, time):F2} m/s");
                Console.WriteLine($"Youth Ball Speed: {youthBall.CalculateAverageSpeed(start, end, time):F2} m/s");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            }


            for (int velocity = 1; velocity <= 5; velocity++)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Normal Ball Kinetic Energy (v={velocity}): {normalBall.CalculateKineticEnergy(velocity):F2} J");
                Console.WriteLine($"Youth Ball Kinetic Energy (v={velocity}): {youthBall.CalculateKineticEnergy(velocity):F2} J");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Normal Ball Code: {normalBall.GenerateUniqueCode()}");
            Console.WriteLine($"Youth Ball Code: {youthBall.GenerateUniqueCode()}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
public abstract class Football
    {
        protected string SponsorName;
        public double Diameter { get; protected set; }
        protected double Weight;
        protected double GoalDepth;
        protected static Random RandomGenerator = new Random();

        protected Football(string sponsorName)
        {
            SponsorName = sponsorName;
        }

        public double CalculateAverageSpeed(double startPos, double finalPos, double time)
        {
            if (time <= 0)
                throw new ArgumentException("it should be bigger than 0 itself");

            double distance = Math.Abs(finalPos - startPos);
            return distance / time;
        }

        public bool IsGoal(double ballCoordinate, double goalCoordinate, double ballRadius)
        {
            return ballCoordinate - ballRadius >= goalCoordinate - GoalDepth;
        }

        public abstract string GenerateUniqueCode();

        public double CalculateKineticEnergy(double velocity)
        {
            return (Weight * Math.Pow(velocity, 2)) / 2;
        }
  
}


    public class Normal : Football
    {
        public Normal(string sponsorName) : base(sponsorName)
        {
            Diameter = 0.7; 
            Weight = 0.45; 
            GoalDepth = 1.7; 
        }

        public override string GenerateUniqueCode()
        {
            if (SponsorName.Length < 4)
                throw new ArgumentException("please insert atleast 4 numbers to sponsor");

            string code = SponsorName.Substring(0, 4).ToUpper();
            for (int i = 0; i < 5; i++)
            {
                code += RandomGenerator.Next(0, 10);
            }
            return code;
        }
    }

    
    public class Youth : Football
    {
        public Youth(string sponsorName) : base(sponsorName)
        {
            Diameter = 0.56; 
            Weight = 0.38;  
            GoalDepth = 1.4; 
        }

        public override string GenerateUniqueCode()
        {
            if (SponsorName.Length < 3)
                throw new ArgumentException("it should have atleast three ");

            string code = SponsorName.Substring(0, 3).ToUpper();
            for (int i = 0; i < 3; i++)
            {
                code += RandomGenerator.Next(0, 10);
            }
            return code;
        }
    }

    
