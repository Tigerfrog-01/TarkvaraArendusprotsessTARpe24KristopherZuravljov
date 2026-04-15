using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {


            var regular = new Regular();
            var premium = new Premium();
            var linen = new Linen();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            regular.TurnOn();
            regular.Iron(120);
            regular.Steam();
            regular.ProgramName("Linen");
            regular.ProgramName("Silk");
            regular.Iron(320);
            regular.Descale();
            regular.ProgramName("Silk");
            regular.TurnOff();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            premium.TurnOn();
            premium.Iron(150);
            premium.Steam();
            premium.Iron(50);
            premium.Iron(170);
            premium.Iron(180);
            premium.TurnOff();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            linen.TurnOn();
            linen.ProgramName("Linen");
            linen.Iron(210);
            linen.Descale();
            linen.Iron(200);
            linen.TurnOff();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
    }

    public interface IIroningMachine
    {
        void Descale();
        void Iron(int temperature);
        void ProgramName(string program);
        void Steam();
        void TurnOn();
        void TurnOff();

    }

    public abstract class IroningMachine : IIroningMachine
    {
        protected string MachineType;
        protected int UsageCounter = 0;
        protected bool NeedsCleaning => UsageCounter >= 3;
        protected bool SteamOn = false;

        protected Dictionary<string, (int Min, int Max)> Programs = new()
    {
        { "Linen", (200, 230) },
        { "Cotton", (150, 199) },
        { "Silk", (120, 149) },
        { "Synthetics", (90, 119) }
    };

        public void TurnOn() => Console.WriteLine($"{MachineType} is now turned on");

        public void TurnOff() => Console.WriteLine($"{MachineType} is now turned off");

        public void Steam()
        {
            if (SteamOn)
            {
                Console.WriteLine("Steam is already on");
            }
            else
            {
                SteamOn = true;
                Console.WriteLine("Steam is turned on");
            }
        }

        public abstract void Descale();

        public void Iron(int temperature)
        {
            if (NeedsCleaning)
            {
                Console.WriteLine("The machine has already been used 3 times and needs cleaning");
                return;
            }

            string program = null;
            foreach (var prog in Programs)
            {
                if (temperature >= prog.Value.Min && temperature <= prog.Value.Max)
                {
                    program = prog.Key;
                    break;
                }
            }

            if (program == null)
            {
                Console.WriteLine("Invalid temperature range for ironing");
                return;
            }

            PerformIroning(program, temperature);
        }

        public void ProgramName(string program)
        {
            if (NeedsCleaning)
            {
                Console.WriteLine("The machine has already been used 3 times and needs cleaning");
                return;
            }

            if (!Programs.ContainsKey(program))
            {
                Console.WriteLine($"We do not have a program for ironing '{program}'.");
                return;
            }

            var range = Programs[program];
            var random = new Random();
            int randomTemp = random.Next(range.Min, range.Max + 1);

            PerformIroning(program, randomTemp);
        }

        protected virtual void PerformIroning(string program, int temperature)
        {
            Console.WriteLine($"{MachineType} is ironing with {program} program at {temperature} degrees");
            if (SteamOn)
            {
                Console.WriteLine("Ironing with steam");
                SteamOn = false;
            }
            UsageCounter++;
        }
    }

    public class Regular : IroningMachine
    {
        public Regular() => MachineType = "Regular machine";

        public override void Descale()
        {
            UsageCounter = 0;
            Console.WriteLine("Machine is cleaned");
        }

        protected override void PerformIroning(string program, int temperature)
        {
            if (program == "Linen")
            {
                Console.WriteLine("This machine cannot perform the Linen program");
                return;
            }

            base.PerformIroning(program, temperature);
        }
    }

    public class Premium : IroningMachine
    {
        private int SteamUsageCounter = 0;
        private bool WaterIndicator => SteamUsageCounter >= 2;

        public Premium() => MachineType = "Premium machine";

        protected override void PerformIroning(string program, int temperature)
        {
            if (program == "Linen")
            {
                Console.WriteLine("This machine cannot perform the Linen program");
                return;
            }

            base.PerformIroning(program, temperature);

            if (SteamOn)
            {
                SteamUsageCounter++;
                if (WaterIndicator)
                {
                    Console.WriteLine("Water indicator light is on, please add water to it");
                }
            }

            if (NeedsCleaning)
            {
                Descale();
            }
        }

        public override void Descale()
        {
            UsageCounter = 0;
            Console.WriteLine("Machine is cleaned automatically");
        }
    }

    public class Linen : IroningMachine
    {
        public Linen() => MachineType = "Linen machine";

        protected override void PerformIroning(string program, int temperature)
        {
            if (program == "Linen")
            {
                SteamOn = true;
            }

            base.PerformIroning(program, temperature);
        }

        public override void Descale()
        {
            UsageCounter = 0;
            Console.WriteLine("Machine is cleaned");
        }
    }
}

