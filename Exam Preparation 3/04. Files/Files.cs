using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Files
{
    public class Files
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var filesByRoot = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                var root = Console.ReadLine().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var rootName = root[0];
                var fileWithSize = root[root.Count - 1].Split(';');

                var fileName = fileWithSize[0];
                var fileSize = long.Parse(fileWithSize[1]);

                if (!filesByRoot.ContainsKey(rootName))
                {
                    filesByRoot.Add(rootName, new Dictionary<string, long>());
                }
                if (!filesByRoot[rootName].ContainsKey(fileName))
                {
                    filesByRoot[rootName].Add(fileName, fileSize);
                }
                else
                {
                    filesByRoot[rootName][fileName] = fileSize;
                }
            }

            var queryParams = Console.ReadLine().Split().ToList();
            var queryExtension = queryParams[0];
            var queryRoot = queryParams[2];
            var hasExtension = false;
            if (filesByRoot.ContainsKey(queryRoot))
            {
                var foundFiles = filesByRoot[queryRoot];
                foreach (var file in foundFiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (file.Key.EndsWith(queryExtension))
                    {
                        Console.WriteLine($"{file.Key} - {file.Value} KB");
                        hasExtension = true;
                    }
                }
            }
            if (!hasExtension)
            {
                Console.WriteLine("No");
            }

        }
    }
}
