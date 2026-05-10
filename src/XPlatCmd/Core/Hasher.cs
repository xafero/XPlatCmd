using System;
using System.IO;
using System.Threading.Tasks;
using XPlatCmd.Lib;

namespace XPlatCmd.Core
{
    public static class Hasher
    {
        public static async Task Run(Options o)
        {
            var root = Files.GetFullDir(o.InputDir);
            Console.WriteLine($"Scanning => {root}");

            const SearchOption so = SearchOption.AllDirectories;
            foreach (var file in Directory.EnumerateFiles(root, "*.*", so))
            {
                var hash = Hashing.Compute(file);
                Console.WriteLine(hash);
            }

            Console.WriteLine("Done.");
        }
    }
}