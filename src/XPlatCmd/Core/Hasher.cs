using System;
using System.Collections.Generic;
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
            var outDir = Files.GetFullDir(o.OutputDir);
            Console.WriteLine($"Scanning => {root}");
            Console.WriteLine($"Writing  => {outDir}");

            var cFile = Path.Combine(outDir, "hashes.csv");
            var jFile = Path.Combine(outDir, "hashes.json");
            var results = new List<HashResult>();

            const SearchOption so = SearchOption.AllDirectories;
            foreach (var file in Directory.EnumerateFiles(root, "*.*", so))
            {
                if (file.Equals(cFile) || file.Equals(jFile)) continue;
                var hash = Hashing.Compute(file);
                Console.WriteLine($" * {hash.Md5,12} {hash.Size,8} {hash.Path}");
                results.Add(hash);
            }

            CsvTool.ToFile(cFile, results);
            JsonTool.ToFile(jFile, results);

            Console.WriteLine($"Done with {results.Count} files.");
            return Task.CompletedTask;
        }
    }
}