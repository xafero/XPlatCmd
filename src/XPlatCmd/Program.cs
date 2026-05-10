using System.Threading.Tasks;
using CommandLine;
using XPlatCmd.Core;

namespace XPlatCmd
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var parser = Parser.Default;
            await parser.ParseArguments<Options>(args).WithParsedAsync(async o =>
            {
                if (o.Hash)
                {
                    await Hasher.Run(o);
                }
            });
        }
    }
}