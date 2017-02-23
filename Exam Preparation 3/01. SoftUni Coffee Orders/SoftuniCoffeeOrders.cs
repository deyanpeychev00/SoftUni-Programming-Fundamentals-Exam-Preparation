using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftUni_Coffee_Orders
{
    public class SoftuniCoffeeOrders
    {
        public static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var coffeePrices = new List<decimal>();
            for (int i = 0; i < N; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsulesCount = decimal.Parse(Console.ReadLine());
                var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                decimal price = ((daysInMonth * capsulesCount) * pricePerCapsule);
                coffeePrices.Add(price);
            }
            foreach (var price in coffeePrices)
            {
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }
            Console.WriteLine($"Total: ${coffeePrices.Sum():f2}");
        }
    }
}
