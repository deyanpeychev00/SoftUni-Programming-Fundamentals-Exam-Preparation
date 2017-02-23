using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Charity_Marathon
{
    public class CharityMarathon
    {
        public static void Main()
        {
            var marathonDays = double.Parse(Console.ReadLine());
            var numOfRunners = double.Parse(Console.ReadLine());
            var averageLaps = double.Parse(Console.ReadLine());
            var trackLength = double.Parse(Console.ReadLine()); // in meters
            var trackCapacity = double.Parse(Console.ReadLine());
            var moneyPerKilometer = double.Parse(Console.ReadLine());

            var maxRunners = trackCapacity * marathonDays;

            if (numOfRunners >= maxRunners)
            {
                numOfRunners = maxRunners;
            }
            var totalMeters = numOfRunners * averageLaps * trackLength;
            var totalKilometers = totalMeters / 1000.0;
            var totalMoneyRaised = totalKilometers * moneyPerKilometer;

            Console.WriteLine($"Money raised: {totalMoneyRaised:f2}");

        }
    }
}
