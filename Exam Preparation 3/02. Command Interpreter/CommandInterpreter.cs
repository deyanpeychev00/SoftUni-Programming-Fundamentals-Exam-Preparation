using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Command_Interpreter
{
    public class CommandInterpreter
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = Console.ReadLine();
            while (command != "end")
            {
                var tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var arrComand = tokens[0];
                switch (arrComand)
                {
                    case "reverse":
                        {
                            var start = int.Parse(tokens[2]);
                            var count = int.Parse(tokens[4]);

                            if (isValid(start, count, input))
                            {
                                input.Reverse(start, count);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input parameters.");
                            }
                            break;
                        }
                    case "sort":
                        {
                            var start = int.Parse(tokens[2]);
                            var count = int.Parse(tokens[4]);

                            if (isValid(start, count, input))
                            {
                                input.Sort(start, count, StringComparer.InvariantCulture);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input parameters.");
                            }
                            break;
                        }
                    case "rollLeft":
                        {
                            var count = int.Parse(tokens[1]);

                            if (count >= 0)
                            {
                                RollLeft(count, input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input parameters.");
                            }

                            break;
                        }
                    case "rollRight":
                        {
                            var count = int.Parse(tokens[1]);

                            if (count >= 0)
                            {
                                RollRight(count, input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input parameters.");
                            }
                            break;                 
                        }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", input)}]");
        }

        private static void RollRight(int count, List<string> input)
        {
            count = count % input.Count;
            for (int i = 0; i < count; i++)
            {
                string lastElem = input[input.Count - 1];
                input.RemoveAt(input.Count - 1);
                input.Insert(0, lastElem);
            }
        }

        private static void RollLeft(int count, List<string> input)
        {
           count = count % input.Count;

            for (int i = 0; i < count; i++)
            {
                string firstElem = input[0];
                for (int j = 0; j < input.Count - 1; j++)
                {
                    input[j] = input[j + 1];
                }
                input[input.Count - 1] = firstElem;
            }
        }

        private static bool isValid(int start, int count, List<string> input)
        {
            if (start >= 0 && start < input.Count && count >=0 && (count+start) <= input.Count)
            {
                return true;
            }
                return false;
        }
    }
}
