using System;
using System.IO;
using System.Threading.Tasks;
using XPlatCmd.Lib;

namespace XPlatCmd.Core
{
    public static class Hasher
    {
        public static Task Run(Options o)
        {
            var root = Files.GetFullDir(o.InputDir);
            Console.WriteLine($"Scanning => {root}");

            const SearchOption so = SearchOption.AllDirectories;
            foreach (var file in Directory.EnumerateFiles(root, "*.*", so))
            {
                var hash = Hashing.Compute(file);
                Console.WriteLine($" * {hash.Md5,12} {hash.Size,8} {hash.Path}");
            }

            Console.WriteLine("Done.");
            return Task.CompletedTask;
        }
    }
}