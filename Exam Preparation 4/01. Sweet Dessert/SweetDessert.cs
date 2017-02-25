using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sweet_Dessert
{
    public class SweetDessert
    {
        public static void Main()
        {
            var cashAmount = double.Parse(Console.ReadLine());
            var guestsNum = int.Parse(Console.ReadLine());
            var bananasPrice = double.Parse(Console.ReadLine());
            var eggsPrice = double.Parse(Console.ReadLine());
            var berriesPrice = double.Parse(Console.ReadLine());

            var portionSets = Math.Ceiling(guestsNum / 6.0);
            //Console.WriteLine(portionSets);

            var neededBananas = bananasPrice * 2;
            var neededEggs = eggsPrice * 4;
            var berriesNeeded = berriesPrice * 0.2;

            var totalSum = (portionSets * neededBananas) + (portionSets * neededEggs) + (portionSets * berriesNeeded);

            if (totalSum <= cashAmount)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalSum-cashAmount:f2}lv more.");
            }
        }
    }
}