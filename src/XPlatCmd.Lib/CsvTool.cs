using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace XPlatCmd.Lib
{
    public static class CsvTool
    {
        private static readonly CultureInfo Cult = CultureInfo.InvariantCulture;

        public static void ToFile<T>(string file, IEnumerable<T> items)
        {
            using var writer = File.CreateText(file);
            using var csv = new CsvWriter(writer, Cult);
            csv.WriteRecords(items);
            csv.Flush();
            writer.Flush();
        }
    }
}