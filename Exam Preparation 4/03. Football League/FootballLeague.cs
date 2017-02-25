using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Football_League
{
    public class FootballLeague
    {
        public static void Main()
        {
            var key = Console.ReadLine();
            key = Regex.Escape(key);
            var regex = new Regex($@"{key}(?<firstTeamName>.*?){key}.+?{key}(?<secondTeamName>.*S?){key}.+?(?<firstTeamScore>\d+):(?<secondTeamScore>\d+)");
            var line = Console.ReadLine();
            var scores = new Dictionary<string, long>();
            var goals = new Dictionary<string, long>();
            while (line != "final")
            {
                var match = regex.Match(line);
                var firstTeam = new string(match.Groups["firstTeamName"].Value.Reverse().ToArray()).ToUpper();
                var secondTeam = new string(match.Groups["secondTeamName"].Value.Reverse().ToArray()).ToUpper();
                var firstTeamScore = int.Parse(match.Groups["firstTeamScore"].Value);
                var secondTeamScore = int.Parse(match.Groups["secondTeamScore"].Value);

                if (!scores.ContainsKey(firstTeam))
                {
                    scores[firstTeam] = 0;
                }
                if (!scores.ContainsKey(secondTeam))
                {
                    scores[secondTeam] = 0;
                }
                if (!goals.ContainsKey(firstTeam))
                {
                    goals[firstTeam] = 0;
                }
                if (!goals.ContainsKey(secondTeam))
                {
                    goals[secondTeam] = 0;
                }

                goals[firstTeam] += firstTeamScore;
                goals[secondTeam] += secondTeamScore;

                if (firstTeamScore > secondTeamScore)
                {
                    scores[firstTeam] += 3;
                }
                else if (firstTeamScore < secondTeamScore)
                {
                    scores[secondTeam] += 3;
                }
                else
                {
                    scores[firstTeam] += 1;
                    scores[secondTeam] += 1;
                }
                
                line = Console.ReadLine();
            }

            Console.WriteLine("League standings:");
            int place = 1;

            foreach (var kvp in scores.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{place}. {kvp.Key} {kvp.Value}");
                place++;
            }

            Console.WriteLine("Top 3 scored goals:");
            var topCount = 0;

            foreach (var kvp in goals.OrderByDescending(kvp => kvp.Value).ThenBy(kvp =>kvp.Key))
            {
                Console.WriteLine($"- {kvp.Key} -> {kvp.Value}");
                topCount++;
                if (topCount == 3)
                {
                    break;
                }
            }

        }

    }
}
