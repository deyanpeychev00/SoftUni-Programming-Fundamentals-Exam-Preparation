using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUni_Karaoke
{
    public class SoftUniKaraoke
    {
        public static void Main()
        {
            var participantsInput = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();
            var songsInput = Console.ReadLine().Split(',').Select(s => s.Trim()).ToList();

            var result = new Dictionary<string, List<string>>();

            var line = Console.ReadLine();
            while (line != "dawn")
            {
                var performance = line.Split(',').Select(p => p.Trim()).ToList();

                var participant = performance[0];
                var song = performance[1];
                var award = performance[2];

                if (participantsInput.Contains(participant) && songsInput.Contains(song))
                {
                    if (!result.ContainsKey(participant))
                    {
                        result[participant] = new List<string>();
                    }
                    var awards = result[participant];
                    if (!awards.Contains(award))
                    {
                        awards.Add(award);
                    }
                }
                line = Console.ReadLine();
            }
            if (result.Any())
            {
                foreach (var keyValuePair in result.OrderByDescending(p => p.Value.Count).ThenBy(n=>n.Key))
                {
                    if (keyValuePair.Key.Any())
                    {
                        var participant = keyValuePair.Key;
                        var awards = keyValuePair.Value;
                        Console.WriteLine($"{participant}: {awards.Count} awards");
                        foreach (var award in awards.OrderBy(n => n))
                        {
                            Console.WriteLine($"--{award}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
