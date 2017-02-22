using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;
namespace _01.Sino_The_Walker
{
    public class SinoTheWalker
    {
        public static void Main()
        {
            var timeOfLeaving = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            var steps = int.Parse(Console.ReadLine());
            var secondsPerStep = int.Parse(Console.ReadLine());
            ulong secondsToAdd = (ulong)steps * (ulong)secondsPerStep;
            long initialSeconds = (timeOfLeaving.Hour * 60 * 60) + (timeOfLeaving.Minute * 60) + timeOfLeaving.Second;
            ulong totalSeconds = (ulong)initialSeconds + secondsToAdd;
            var seconds = totalSeconds % 60;
            var totalMinutes = totalSeconds / 60;
            var minutes = totalMinutes % 60;
            var totalHours = totalMinutes / 60;
            var hours = totalHours % 24;

            Console.WriteLine($"Time Arrival: {hours:d2}:{minutes:d2}:{seconds:d2}");
        }
    }
}
