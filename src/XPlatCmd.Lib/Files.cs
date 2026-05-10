using System;
using System.IO;

namespace XPlatCmd.Lib
{
    public static class Files
    {
        public static string GetFullDir(string? dir)
        {
            var root = dir?.TrimOrNull() ?? Directory.GetCurrentDirectory();
            root = Environment.ExpandEnvironmentVariables(root);
            root = Path.GetFullPath(root);
            if (!Directory.Exists(root))
                throw new InvalidOperationException($"Directory not found => {root}");
            return root;
        }
    }
}