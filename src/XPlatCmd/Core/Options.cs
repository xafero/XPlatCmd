using CommandLine;

// ReSharper disable ClassNeverInstantiated.Global

namespace XPlatCmd.Core
{
	public class Options
	{
		[Option('h', "hash", HelpText = "Create hashes for checking.")]
		public bool Hash { get; set; }

		[Option('i', "input", HelpText = "Set input directory.")]
		public string? InputDir { get; set; }
	}
}