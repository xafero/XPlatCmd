using System;
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

            Console.WriteLine("Done.");
        }
    }
}