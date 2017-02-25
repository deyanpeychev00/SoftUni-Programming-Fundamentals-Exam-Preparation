using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Array_Manipulator
{
    public class ArrayManipulator
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var line = Console.ReadLine();
            while (line != "end")
            {
                var commandParts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandParts[0])
                {
                    case "exchange":
                        arr = Exchange(arr, int.Parse(commandParts[1]));
                        break;
                    case "max":
                    case "min":
                        MaxAndMin(arr, commandParts[0], commandParts[1]);
                        break;
                    case "first":
                    case "last":
                        FirstAndLast(arr, commandParts[0], int.Parse(commandParts[1]), commandParts[2]);
                        break;


                }
                line = Console.ReadLine();
            }
            PrintArray(arr);
        }
        private static void PrintArray(int[] arr)
        {
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }
        private static IEnumerable<int> FilterEvenOrOdd(int[] arr, string evenOrOdd)
        {
            return arr
                .Where(n => evenOrOdd == "even" /*condition*/
                    ? n % 2 == 0 /*true*/
                    : n % 2 == 1 /*false*/);
        }

        private static void FirstAndLast(int[] arr, string firstOrLast, int count, string evenOrOdd)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            var filter = FilterEvenOrOdd(arr, evenOrOdd);
            int[] result;
            if (firstOrLast == "first")
            {
                result = filter.Take(count).ToArray();
            }
            else
            {
                result = filter.Reverse().Take(count).Reverse().ToArray();
            }
            PrintArray(result);
        }

        private static void MaxAndMin(int[] arr, string command, string evenOrOdd)
        {
            var filter = FilterEvenOrOdd(arr, evenOrOdd);
            if (!filter.Any())
            {
                Console.WriteLine("No matches");
                return;
            }
            var result = command == "max"
                ? filter.Max()
                : filter.Min();
            Console.WriteLine(Array.LastIndexOf(arr,result));   
        }

        private static int[] Exchange(int[] arr, int index)
        {
            if(index <0 || index >= arr.Length)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }
            var left = arr.Take(index + 1);
            var right = arr.Skip(index + 1);

            return right.Concat(left).ToArray();
        }
    }
}
